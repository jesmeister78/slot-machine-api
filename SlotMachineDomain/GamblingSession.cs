using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlotMachineDomain
{
    public class GamblingSession
    {
        [Key]
        public Guid SessionId { get; set; }
        public string PlayerId { get; set; }
        public PlayerGroup PlayerGroup { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }
        public int TimerInterval { get; set; }
        public double InitialBalance { get; set; }
        public double FinalBalance { get; set; }
        public int TotalNumBets { get; set; }
        public ICollection<BetRecord> BetRecords { get; set; }
        public ICollection<GrcsResponse> GrcsResponses { get; set; }
    }
}