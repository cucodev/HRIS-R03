using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.DataEntities;
using DataModel.UnitOfWork;
using System.Transactions;
using DataModel;
using BusinessEntities;

namespace BusinessServices.InterfaceMethod
{
    public class LeaveServices : ILeave
    {
        private readonly UnitOfWork _u;
        private readonly TransactionServices trx;

        public LeaveServices()
        {
            _u = new UnitOfWork();
            trx = new TransactionServices();
        }


        //Process Leaves Summary from Web
        public int PostLeaveSummary(int IDV, int policyID, List<leaveSummaryEntities> tx)
        {
            
            //Generate Transaction
            int txID = trx.createTX(IDV,IDV, GlobalVariable.purposeLeave);

            if (txID != 0)
            {
                System.Diagnostics.Debug.WriteLine("leaveSummary : ", tx);
                foreach (leaveSummaryEntities summaryE in tx)
                {
                    transactionLeave leaveE = new transactionLeave();
                    leaveE.txID = txID;
                    leaveE.policyID = policyID;
                    leaveE.vCreatedBy = IDV;

                    leaveE.startDate = summaryE.Date;
                    leaveE.endDate = summaryE.Date;
                    leaveE.dayDuration = summaryE.Duration;

                    Create(leaveE);
                    System.Diagnostics.Debug.WriteLine("Looping Insert Date: ", summaryE.Date);
                }
            }
            return txID;
        }

        
        public int Create(transactionLeave tx)
        {
            using (var scope = new TransactionScope())
            {
                var px = new dataLeave
                {
                    txID = tx.txID,
                    policyID = tx.policyID,
                    startDate = tx.startDate,
                    endDate = tx.endDate,
                    dayDuration = tx.dayDuration,
                    vCreatedBy = tx.vCreatedBy,
                    createTime = DateTime.Now
                };
                _u.dataLeaveRepository.Insert(px);
                _u.Save();
                scope.Complete();
                return px.ID;
            }
        }

        public bool Delete(int ID, transactionLeave tx)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<transactionLeave> getAllLeave()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<transactionLeave> getALLLeaveByIDV(int IDV)
        {
            throw new NotImplementedException();
        }

        public transactionLeave getLeaveByID(int ID)
        {
            throw new NotImplementedException();
        }

        

        public bool Update(int ID, transactionLeave tx)
        {
            throw new NotImplementedException();
        }
    }
}
