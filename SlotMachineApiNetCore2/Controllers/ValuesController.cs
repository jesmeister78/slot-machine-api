using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SlotMachineApiNetCore2.Config;
using SlotMachineApiNetCore2.Model;
using SlotMachineApiNetCore2.ViewModels;

namespace SlotMachineApiNetCore2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBetService _betService;
        private readonly Params _options;
        private readonly ISlotMachineRepo _repo;
        private readonly ISpinService _spinService;

        public ValuesController(IOptions<Params> options, IBetService betService, ISpinService spinService,
            ISlotMachineRepo repo)
        {
            _options = options.Value;
            _betService = betService;
            _spinService = spinService;
            _repo = repo;
        }

        // GET api/values
        // get the initial symbol map
        // no win result needed
        [HttpGet("{playerId}")]
        public InitViewModel Get(string playerId)
        {
            // call the ISpinService to get the random Player Group
            var playerGroup = _spinService.GetPlayerGroup();

            var sessionId = StartSession(playerId, playerGroup);

            // use max rows if not specified by user - always max rows for init
            var numRows = _options.MaxRows;

            // call ISpinService to get the spin result
            var spinResult = _spinService.GetSpinResult(numRows, _options.MaxCols);

            var result = new InitViewModel();
            result.SessionId = sessionId;
            result.PlayerGroup = playerGroup;
            result.ResultMap = spinResult.ResultMap;
            result.InitialBalance = _options.InitialBalance;
            result.TimerInterval = _options.TimerInterval;

            return result;
        }

        private Guid StartSession(string playerId, PlayerGroup playerGroup)
        {
            // start a new gambling session
            var session = new GamblingSession();
            session.SessionId = new Guid();
            session.PlayerId = playerId;
            session.PlayerGroup = playerGroup;
            session.InitialBalance = _options.InitialBalance;
            session.SessionStart = DateTime.Now;
            session.TimerInterval = _options.TimerInterval;
            _repo.AddGamblingSession(session);
            _repo.Commit();
            return session.SessionId;
        }

        // GET api/values/5
        [HttpGet("{userBet}/{userNumRows}/{sessionId}")]
        public BetResultViewModel Get(double? userBet, int? userNumRows, Guid sessionId)
        {
            // use max rows if not specified by user
            var numRows = userNumRows ?? _options.MaxRows;
            // use default bet amount from config if no bet amount provided by user
            var bet = userBet ?? _options.DefaultBetAmount;

            // call ISpinService to get the spin result
            var spinResult = _spinService.GetSpinResult(numRows, _options.MaxCols);
            var scores = _spinService.CalculateScore(spinResult);
            // get payout ratio from config
            var payoutRatio = _options.PayoutRatio;

            // call IBetService to get the result for the bet amount
            var winAmount = _betService.GetWinResult(scores, bet, numRows, payoutRatio);
            var prevBet = _repo.GetPreviousBetRecordForSession(sessionId);
            var prevBalance = prevBet?.Balance ?? _options.InitialBalance;

            // create a bet record
            var betRecord = _betService.CreateBetRecord(sessionId, bet, numRows, winAmount, prevBalance);
            // add to db
            _repo.AddBetRecord(betRecord);
            _repo.Commit();

            var result = new BetResultViewModel
            {
                ResultMap = spinResult.ResultMap,
                SymbolScores = scores,
                WinAmount = betRecord.GetWinResult()
            };

            return result;
        }

       
        // POST api/values
        [HttpPost]
        [Route("grcs")]
        public void Post([FromBody] IEnumerable<NewGrcsResponseCommand> createResponseCommands)
        {
            foreach (var cmd in createResponseCommands)
            {
                var response = new GrcsResponse
                {
                    GrcsResponseId = Guid.NewGuid(),
                    QuestionId = cmd.QuestionId,
                    SessionId = cmd.SessionId,
                    Answer = cmd.Answer,
                    NumMinutesPlayed = cmd.NumMinutesPlayed
                };

                _repo.Add(response);
            }

            _repo.Commit();
        }
        
    }
}