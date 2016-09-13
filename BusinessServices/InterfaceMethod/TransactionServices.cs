using BusinessServices.Interface;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.DataEntities;
using BusinessEntities;
using DataModel;
using System.Transactions;
using DataModel.Model;

namespace BusinessServices.InterfaceMethod
{
    public class TransactionServices : ITx
    {
        private readonly UnitOfWork _u;
        private readonly employeeServices emp;
        
        public TransactionServices()
        {
            _u = new UnitOfWork();
            emp = new employeeServices();
        }

        public int createPurpose(purpose tx)
        {
            throw new NotImplementedException();
        }

        public int getPurposeIDByCode(string purposeCode)
        {
            var purpose = _u.purposeRepository.GetByCode(b => b.purposeName.Trim() == purposeCode.Trim());
            return purpose.purposeID;
        }

        public int createTX(int requestIDV, int vCreatedBy, string purposeName)
        {
            //Get Purpose 
            int purposeID = getPurposeIDByCode(purposeName);

            //Get Approval
            var approvalIDV = emp.getApprovalIDV(requestIDV);

            if (purposeID != 0)
            {
                using (var scope = new TransactionScope())
                {
                    var px = new C_transaction
                    {
                        purposeID = purposeID,
                        idvApproval = approvalIDV,
                        idvRequest = requestIDV,

                        //purposeStatus = tx.purposeStatus,
                        vCreatedBy = vCreatedBy,
                        createTime = DateTime.Now
                    };
                    _u.transactionRepository.Insert(px);
                    _u.Save();
                    scope.Complete();
                    return px.txID;
                }
            }
            return 0;
        }

        public bool Delete(int txID, transactionMaster tx)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<transactionMaster> getAll()
        {
            throw new NotImplementedException();
        }

        public transactionMaster getByID(int purposeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<transactionMaster> getByIDVApproval(int IDVApproval)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<transactionMaster> getByIDVRequest(int IDVRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<transactionMaster> getByIDV(int IDV, int PurposeID)
        {
            List<transactionMaster> ps = new List<transactionMaster>();
            var data = _u.transactionRepository.GetMany(b => (b.idvApproval == IDV || b.idvRequest == IDV) && b.purposeID == PurposeID);
            if (data.Any())
            {
                foreach(C_transaction p in data)
                {
                    transactionMaster ms = new transactionMaster();
                    ms.txID = p.txID;
                    ms.purposeID = p.purposeID;
                    ms.purposeStatus = p.purposeStatus;
                    ms.idvRequest = p.idvRequest;
                    ms.idvApproval = p.idvApproval;
                    ms.vCreatedBy = p.vCreatedBy;
                    ms.vUpdateBy = p.vUpdateBy;
                    ms.createTime = p.createTime;
                    ms.updateTime = p.updateTime;
                    ps.Add(ms);
                }
                return ps.AsEnumerable();
            }
            return null;
            //throw new NotImplementedException();
        }

        public IEnumerable<transactionMaster> getByPurpose(int purposeID)
        {
            throw new NotImplementedException();
        }

        public bool Update(int txID, transactionMaster tx)
        {
            throw new NotImplementedException();
        }
    }
}
