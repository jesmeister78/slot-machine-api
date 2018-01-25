namespace SlotMachineApiNetCore2.Config
{
    public class Params
    {
        public int MaxRows { get; set; }
        public int MaxCols { get; set; }
        public int DefaultBetAmount { get; set; }
        public double PayoutRatio { get; set; }
        public double InitialBalance { get; set; }
        public int TimerInterval { get; set; }
    }
}