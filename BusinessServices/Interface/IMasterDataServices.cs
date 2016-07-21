using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{

    public interface IcategoryLevel
    {
       
    }

    //Maintain RoleBased Data
    public interface IRoleBased
    {
        IEnumerable<roleBasedEntities> getRoleBased();
        IEnumerable<roleBasedEntities> getRoleBasedBypolicyType(int policyType);
        int CreateRoleBased(roleBasedEntities roleBasedEntities);
        bool UpdateRoleBased(int ID, roleBasedEntities roleBasedEntities);
        bool DeleteRoleBased(int id);
    }

    //Maintain Category Matrix Role
    public interface IcategoryRoleBased
    {
        IEnumerable<BusinessEntities.CrudEntities.classificationEntities> getRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
        IEnumerable<BusinessEntities.CrudEntities.classificationEntities> getRoleBasedByID(int IDV, BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
        int CreateRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
        bool UpdateRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
    }
}
