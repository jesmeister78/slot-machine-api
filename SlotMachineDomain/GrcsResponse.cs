using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlotMachineDomain
{
    public class GrcsResponse
    {
        public int QuestionId { get; set; }
        public Guid SessionId { get; set; }
        public int Answer { get; set; }
        public int NumMinutesPlayed { get; set; }
        [ForeignKey("SessionId")]
        public GamblingSession Session { get; set; }
    }
}