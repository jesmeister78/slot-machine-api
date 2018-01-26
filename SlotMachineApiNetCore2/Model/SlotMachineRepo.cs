using System;
using System.Linq;

namespace SlotMachineApiNetCore2.Model
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
            _context.BetRecords.Add(bet);
        }

        public BetRecord GetPreviousBetRecordForSession(Guid sessionId)
        {
            var betRecord = _context.BetRecords.Where(x => x.SessionId == sessionId)
                .OrderByDescending(t => t.Timestamp).Take(1).FirstOrDefault();
            return betRecord;
        }

        public void AddGamblingSession(GamblingSession session)
        {
            _context.GamblingSessions.Add(session);
        }

        public void AddGrcsResponse(GrcsResponse response)
        {
            _context.GrcsResponses.Add(response);
        }

        public TEntity Get<TEntity, TKey>(TKey key)
            where TEntity : class
        {
            var entity = _context.Set<TEntity>().Find(key);
            return entity;
        }

        public void Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}