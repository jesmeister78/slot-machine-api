using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SlotMachineApiNetCore2.Config;
using SlotMachineApiNetCore2.ViewModels;
using SlotMachineDomain;

namespace SlotMachineApiNetCore2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBetService _betService;
        private readonly Params _options;
        private readonly IBetRecordRepo _repo;
        private readonly ISpinService _spinService;

        public ValuesController(IOptions<Params> options, IBetService betService, ISpinService spinService,
            IBetRecordRepo repo)
        {
            _options = options.Value;
            _betService = betService;
            _spinService = spinService;
            _repo = repo;
        }

        // GET api/values
        // get the initial symbol map
        // no win result needed
        [HttpGet]
        public InitViewModel Get()
        {
            // use max rows if not specified by user
            var numRows = _options.MaxRows;

            // call the ISpinService to get the random Player Group
            var playerGroup = _spinService.GetPlayerGroup();

            // call ISpinService to get the spin result
            var spinResult = _spinService.GetSpinResult(numRows, _options.MaxCols);

            var result = new InitViewModel();
            result.PlayerGroup = playerGroup;
            result.ResultMap = spinResult.ResultMap;
            result.InitialBalance = _options.InitialBalance;
            result.TimerInterval = _options.TimerInterval;

            return result;
        }

        // GET api/values/5
        [HttpGet("{userBet}/{userNumRows}")]
        public BetResultViewModel Get(double? userBet, int? userNumRows)
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

            var result = new BetResultViewModel
            {
                ResultMap = spinResult.ResultMap,
                SymbolScores = scores,
                WinAmount = winAmount
            };

            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] IEnumerable<BetRecordViewModel> bets)
        {
            foreach (var value in bets)
            {
                var bet = new BetRecord
                {
                    PlayerId = value.PlayerId,
                    Balance = value.Balance,
                    BetAmount = value.BetAmount,
                    NumRows = value.NumRows,
                    Timestamp = DateTime.Now,
                    WinAmount = value.WinAmount
                };

                _repo.AddBetRecord(bet);
            }

            _repo.Commit();
        }
        
    }
}