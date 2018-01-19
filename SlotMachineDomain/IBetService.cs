using System;
using System.Collections.Generic;

namespace SlotMachineDomain
{
    public interface IBetService
    {
        double GetWinResult(Dictionary<SymbolType, int> spinResult, double betAmount, int numRows, double payoutRatio);
    }
}
