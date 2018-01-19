namespace SlotMachineDomain
{
    public class SlotMachineRepo : ISlotMachineRepo
    {
        private readonly SlotMachineContext _context;

        public SlotMachineRepo(SlotMachineContext context)
        {
            _context = context;
        }

        public void AddBetRecord(BetRecord bet)
        {
            using (var context = _context)
            {
                context.BetRecords.Add(bet);
            }
        }

        public void AddGamblingSession(GamblingSession session)
        {
            using (var context = _context)
            {
                context.GamblingSessions.Add(session);
            }
        }

        public void AddGrcsResponse(GrcsResponse response)
        {
            using (var context = _context)
            {
                context.GrcsResponses.Add(response);
            }
        }

        public void Commit()
        {
            using (var context = _context)
            {
                context.SaveChanges();
            }
        }
    }
}