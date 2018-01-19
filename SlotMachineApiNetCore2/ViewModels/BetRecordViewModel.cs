using System;

namespace SlotMachineApiNetCore2.ViewModels
{
    public class BetRecordViewModel
    {
        public string PlayerId { get; set; }
        public int NumRows { get; set; }
        public double BetAmount { get; set; }
        public double WinAmount { get; set; }
        public double Balance { get; set; }
        public DateTime Timestamp { get; set; }
    }
}