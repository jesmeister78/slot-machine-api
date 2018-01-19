using Microsoft.EntityFrameworkCore;

namespace SlotMachineDomain
{
    public class SlotMachineContext : DbContext
    {
        public SlotMachineContext(DbContextOptions<SlotMachineContext> options)
            : base((DbContextOptions) options)
        { }

        public DbSet<GamblingSession> GamblingSessions { get; set; }
        public DbSet<GrcsResponse> GrcsResponses { get; set; }
        public DbSet<BetRecord> BetRecords { get; set; }
    }
}