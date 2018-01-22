using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlotMachineApiNetCore2.Model;

namespace SlotMachineApiNetCore2.ViewModels
{
    public class BetResultViewModel
    {
        public SymbolType[,] ResultMap { get; set; }
        public Dictionary<SymbolType, int> SymbolScores { get; set; }
        public double WinAmount { get; set; }
    }
}
