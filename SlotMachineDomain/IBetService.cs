using System;
using System.Collections.Generic;

namespace SlotMachineDomain
{
    public interface IBetService
    {
        double GetWinResult(Dictionary<SymbolType, int> spinResult, double betAmount, int numRows, double payoutRatio);
        BetRecord CreateBetRecord(Guid sessionId, double bet, int numRows, double winAmount, double prevBalance);
    }
}
