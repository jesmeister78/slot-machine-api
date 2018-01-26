using System;

namespace SlotMachineApiNetCore2.Model
{
    public interface ISlotMachineRepo
    {
        void AddBetRecord(BetRecord bet);
        BetRecord GetPreviousBetRecordForSession(Guid sessionId);
        void AddGamblingSession(GamblingSession session);
        void AddGrcsResponse(GrcsResponse response);

        TEntity Get<TEntity, TKey>(TKey key)
            where TEntity : class;
        void Add<TEntity>(TEntity entity)
            where TEntity : class;
        void Commit();

    }
}
