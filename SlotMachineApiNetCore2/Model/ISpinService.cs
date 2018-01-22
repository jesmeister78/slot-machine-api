using System.Collections.Generic;

namespace SlotMachineApiNetCore2.Model
{
    public interface ISpinService
    {
        SpinResult GetSpinResult(int numRows, int numCols);
        Dictionary<SymbolType, int> CalculateScore(SpinResult spinResult);

        PlayerGroup GetPlayerGroup();
    }
}
