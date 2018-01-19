using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachineDomain
{
    public class BetRecordRepo :IBetRecordRepo
    {
        private readonly SlotMachineContext _context;

        public BetRecordRepo(SlotMachineContext context )
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

        public void Commit()
        {
            using (var context = _context)
            {
                context.SaveChanges();
            }
        }
    }
}
