using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachineDomain
{
    public class BetService : IBetService
    {
        public double GetWinResult(Dictionary<SymbolType, int> spinResult, double betAmount, int numRows, double payoutRatio)
        {
            double winTotal = 0;
            var numSymbols = Enum.GetNames(typeof(SymbolType)).Length;
            var denominator = numSymbols / (double)numRows;

            var initialDebit = betAmount * numRows;
            // add up win result for each symbol
            foreach (SymbolType symbol in Enum.GetValues(typeof(SymbolType)))
            {
                var numMatches = !spinResult.ContainsKey(symbol) ? 0 : spinResult[symbol];
                winTotal += Math.Pow(denominator, numMatches - 1) * payoutRatio;
            }

            // reduce balance by bet amount * num rows
            winTotal -= initialDebit;

            return Math.Round(winTotal, 2);
        }
    }
}
