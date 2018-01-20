using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlotMachineDomain
{
    public class GrcsResponse
    {
        [Key]
        public Guid GrcsResponseId { get; set; }
        public int QuestionId { get; set; }
        public Guid SessionId { get; set; }
        public int Answer { get; set; }
        public int NumMinutesPlayed { get; set; }
        [ForeignKey("SessionId")]
        public GamblingSession Session { get; set; }
    }
}