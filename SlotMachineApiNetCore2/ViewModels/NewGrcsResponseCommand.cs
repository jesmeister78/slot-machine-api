using System;

namespace SlotMachineApiNetCore2.ViewModels
{
    public class NewGrcsResponseCommand
    {
        public Guid SessionId { get; set; }
        public int QuestionId { get; set; }
        public int Answer { get; set; }
        public int NumMinutesPlayed { get; set; }
    }
}