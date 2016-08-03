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
        IEnumerable<employeeRoleBasedEntities> GetRoleBased(int IDV);
        profileEntities GetEmployee(int IDV);
        //int CreateRoleBased(roleBasedEntities EroleBased);
        //bool UpdateRoleBased(roleBasedEntities EroleBased);
    }

}
