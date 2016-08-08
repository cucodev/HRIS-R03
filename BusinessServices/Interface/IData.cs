using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessEntities.DataEntities;

namespace BusinessServices.Interface
{
    public interface IData
    {
        int updateEmployeeServiceYear(int IDV);

        //get returned Employee duraton of Service 
        //tbl: employee
        double checkServiceYearDuration(int IDV);
        int checkServiceDayDuration(int IDV);
        int getBalance(int IDV, int policyID);
        int getRoleBasedBalance(int IDV, int policyID);
        int getRemainingBalance(int IDV, int policyID);
        int isValid(int IDV, int policyID);
        bool isLeaveCarryOver(int IDV);
        int isAnnualLeave( int policyID);
    }

    public interface ITx
    {
        IEnumerable<transactionMaster> getAll();
        transactionMaster getByID(int purposeID);
        IEnumerable<transactionMaster> getByIDV(int IDV, int PurposeID);
        IEnumerable<transactionMaster> getByPurpose(int purposeID);
        IEnumerable<transactionMaster> getByIDVRequest(int IDVRequest);
        IEnumerable<transactionMaster> getByIDVApproval(int IDVApproval);

        int createTX(int requestIDV, int vCreatedBy, string purposeName);
        bool Update(int txID, transactionMaster tx);
        bool Delete(int txID, transactionMaster tx);

        int createPurpose(purpose tx);
        int getPurposeIDByCode(string purposeCode);
    }
    
    public interface ILeave
    {
        //IEnumerable<employeeLeaveEntities>
        int PostLeaveSummary(int IDV, int policyID, List<leaveSummaryEntities> tx);
        IEnumerable<transactionLeave> getAllLeave();
        transactionLeave getLeaveByID(int ID);
        IEnumerable<transactionLeave> getALLLeaveByIDV(int IDV);
        int Create(transactionLeave tx);
        bool Update(int ID, transactionLeave tx);
        bool Delete(int ID, transactionLeave tx);
        
    }

    public interface IMaster
    {
        IEnumerable<transactionMaster> getAllMaster();
        transactionMaster getMasterByID(int ID);
        IEnumerable<transactionMaster> getALLMasterByRequestor(int IDV);
        IEnumerable<transactionMaster> getALLMasterBySuperior(int IDV);
        int Create(transactionMaster tx);
        bool Update(int ID, transactionMaster tx);
        bool Delete(int ID, transactionMaster tx);
    }


    //Unused
    public interface calculateServiceYear
    {
        //int getServiceYear(int IDV);
    }

}
