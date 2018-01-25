using System;
using SlotMachineApiNetCore2.Model;

namespace SlotMachineApiNetCore2.ViewModels
{
    public class InitViewModel
    {
        public Guid SessionId { get; set; }
        public SymbolType[,] ResultMap { get; set; }
        public double InitialBalance { get; set; }
        public int DefaultBetAmount { get; set; }
        public int DefaultNumRows { get; set; }

        public PlayerGroup PlayerGroup { get; set; }

        // number of minutes between each timer tick
        public int TimerInterval { get; set; }
    }
}