using System;
using System.Collections.Generic;

namespace SlotMachineApiNetCore2.Model
{
    public interface IBetService
    {
        double GetWinResult(Dictionary<SymbolType, int> spinResult, double betAmount, int numRows, double payoutRatio);
        BetRecord CreateBetRecord(Guid sessionId, double bet, int numRows, double winAmount, double prevBalance);
    }
}
