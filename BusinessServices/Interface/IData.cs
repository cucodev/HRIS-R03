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
        int updateServiceYear(int IDV);

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
    
    public interface ILeave
    {
        //IEnumerable<employeeLeaveEntities>
        IEnumerable<transactionLeave> getAllLeave();
        transactionLeave getLeaveByID(int ID);
        IEnumerable<transactionLeave> getALLLeaveByIDV(int IDV);
        int Create(transactionLeave tx);
        bool Update(int ID, transactionLeave tx);
        bool Delete(int ID, transactionLeave tx);
        
    }

    public interface IApproval
    {
        IEnumerable<transactionApproval> getAllApproval();
        transactionApproval getApprovalByID(int ID);
        IEnumerable<transactionApproval> getALLApprovalByRequestor(int IDV);
        IEnumerable<transactionApproval> getALLApprovalBySuperior(int IDV);
        int Create(transactionApproval tx);
        bool Update(int ID, transactionApproval tx);
        bool Delete(int ID, transactionApproval tx);
    }


    //Unused
    public interface calculateServiceYear
    {
        //int getServiceYear(int IDV);
    }

}
