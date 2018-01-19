using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachineDomain
{
    public interface IBetRecordRepo
    {
        void AddBetRecord(BetRecord bet);

        void Commit();

    }
}
