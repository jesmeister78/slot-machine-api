using System;

namespace SlotMachineApiNetCore2.Model
{
    public interface ISlotMachineRepo
    {
        void AddBetRecord(BetRecord bet);
        BetRecord GetPreviousBetRecordForSession(Guid sessionId);
        void AddGamblingSession(GamblingSession session);
        void AddGrcsResponse(GrcsResponse response);

        void Add<TEntity>(TEntity entity)
            where TEntity : class;
        void Commit();

    }
}
