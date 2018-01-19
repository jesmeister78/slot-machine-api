using Microsoft.EntityFrameworkCore;

namespace SlotMachineDomain
{
    public class SlotMachineContext : DbContext
    {
        public SlotMachineContext(DbContextOptions<SlotMachineContext> options)
            : base((DbContextOptions) options)
        { }

        public DbSet<BetRecord> BetRecords { get; set; }
    }
}