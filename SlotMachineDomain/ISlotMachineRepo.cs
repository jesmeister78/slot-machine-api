using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachineDomain
{
    public interface ISlotMachineRepo
    {
        void AddBetRecord(BetRecord bet);

        void AddGamblingSession(GamblingSession session);
        void AddGrcsResponse(GrcsResponse response);
        void Commit();

    }
}
