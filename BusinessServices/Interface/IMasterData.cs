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

    //Maintain RoleBased Data, tree type, unused
    public interface IRoleBased
    {
        IEnumerable<roleBasedEntities> getRoleBased();
        IEnumerable<roleBasedEntities> getRoleBasedBypolicyType(int policyType);
        int CreateRoleBased(roleBasedEntities roleBasedEntities);
        bool UpdateRoleBased(int ID, roleBasedEntities roleBasedEntities);
        bool DeleteRoleBased(int id);
    }

    //For Manage Catagory only
    public interface IManageRoleBasedMatrix
    {
        IEnumerable<roleBasedMatrixEntities> getMatrix();
        roleBasedMatrixEntities getMatrixByID(int ID);
        int CreateMatrix(roleBasedMatrixEntities roleBasedMatrixEntities);
        bool UpdateMatrix(int ID, roleBasedMatrixEntities roleBasedMatrixEntities);
        bool UpdateMatrixCategory(int ID, roleBasedMatrixEntities roleBasedMatrixEntities);
        bool DeleteMatrix(int ID);
        bool CalculateMatrix();
    }

    //For Manage Content Data
    public interface IDataRoleBasedMatrix
    {
        IEnumerable<roleBasedMatrixEntities> getMatrix();
        int CreateMatrix(roleBasedMatrixEntities roleBasedMatrixEntities);
        bool UpdateMatrix(int ID, roleBasedMatrixEntities roleBasedMatrixEntities);
        bool DeleteMatrix(int ID);
    }

    //Maintain Category Matrix Role, unused
    public interface IcategoryRoleBased
    {
        IEnumerable<BusinessEntities.CrudEntities.classificationEntities> getRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
        IEnumerable<BusinessEntities.CrudEntities.classificationEntities> getRoleBasedByID(int IDV, BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
        int CreateRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
        bool UpdateRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities);
    }
}
