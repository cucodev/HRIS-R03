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
    
    //Maintain Matrix Role of Employee
    public interface IEmployee
    {
        IEnumerable<employeeStructure> getStructure();
        IEnumerable<employeeRoleBasedEntities> GetRoleBased(int IDV);
        IEnumerable<employeeRoleBasedEntities> getCurrentRoleBasedAnnual(int IDV);
        IEnumerable<employeeRoleBasedEntities> getCurrentRoleBasedLeave(int IDV);
        IEnumerable<employeeRoleBasedEntities> getCurrentRoleBasedMedical(int IDV);
        IEnumerable<employeeRoleBasedEntities> getCurrentRoleBased(int IDV);
        profileEntities GetEmployee(int IDV);
        IEnumerable<employeeDetail> getEmployeeByOrg(int OrgID);
        employeeRoleBasedEntities getRoleBasedValue(int IDV, int policyType);
        employeeRoleBasedEntities getRoleBasedAnnualValue(int IDV);
        Annual getAnnual(int IDV);
        //int CreateRoleBased(roleBasedEntities EroleBased);
        //bool UpdateRoleBased(roleBasedEntities EroleBased);

        int getApprovalIDV(int IDV);
    }

}
