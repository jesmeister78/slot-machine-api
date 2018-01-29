using System;
using System.Collections.Generic;

namespace SlotMachineApiNetCore2.Model
{
    public class BetService : IBetService
    {
       
        public double GetWinResult(Dictionary<SymbolType, int> spinResult, double betAmount, int numRows, double payoutRatio)
        {
            double winTotal = 0;
            var numSymbols = Enum.GetNames(typeof(SymbolType)).Length;
            var denominator = numSymbols; // / (double)numRows; we are only doing matches on 1 row now

            // add up win result for each symbol
            foreach (SymbolType symbol in Enum.GetValues(typeof(SymbolType)))
            {
                var numMatches = !spinResult.ContainsKey(symbol) ? 0 : spinResult[symbol];
                if (numMatches > 0)
                {
                    winTotal += (Math.Pow(denominator, numMatches) * betAmount * payoutRatio);
                }
            }
            
            return Math.Round(winTotal, 2);
        }

        public BetRecord CreateBetRecord(Guid sessionId, double bet, int numRows, double winAmount, double prevBalance)
        {
            var betRecord = new BetRecord();
            betRecord.BetId = Guid.NewGuid();
            betRecord.SessionId = sessionId;
            betRecord.BetAmount = bet;
            betRecord.NumRows = numRows;
            // we record the win amount before subtracting the initial debit
            betRecord.WinAmount = winAmount;
            // update the balance snapshot with the win amount minus the amount spent
            betRecord.UpdateBalance(prevBalance);
            betRecord.Timestamp = DateTime.Now;
            return betRecord;
        }

    }
}
