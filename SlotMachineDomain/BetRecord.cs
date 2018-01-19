using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SlotMachineDomain
{
    public class BetRecord
    {
        [Key]
        public Guid BetId { get; set; }
        public Guid SessionId { get; set; }
        public string PlayerId { get; set; }
        public int NumRows { get; set; }
        public double BetAmount { get; set; }
        public double WinAmount { get; set; }
        public double Balance { get; set; }
        public DateTime Timestamp { get; set; }
        [ForeignKey("SessionId")]
        public GamblingSession Session { get; set; }
    }
}
