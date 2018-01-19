using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachineDomain
{
    public interface ISpinService
    {
        SpinResult GetSpinResult(int numRows, int numCols);
        Dictionary<SymbolType, int> CalculateScore(SpinResult spinResult);

        PlayerGroup GetPlayerGroup();
    }
}
