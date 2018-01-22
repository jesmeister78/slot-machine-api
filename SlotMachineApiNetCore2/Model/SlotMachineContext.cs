using Microsoft.EntityFrameworkCore;

namespace SlotMachineApiNetCore2.Model
{
    public class SlotMachineContext : DbContext
    {
        public SlotMachineContext(DbContextOptions<SlotMachineContext> options)
            : base(options)
        {
        }

        public DbSet<GamblingSession> GamblingSessions { get; set; }
        public DbSet<GrcsResponse> GrcsResponses { get; set; }
        public DbSet<BetRecord> BetRecords { get; set; }
    }
}