using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.UnitOfWork;
using BusinessEntities;
using BusinessServices.Interface;
using BusinessEntities.CrudEntities;

namespace BusinessServices.InterfaceMethod
{
    public class LevelServices : IcategoryLevel
    {

    }

    public class RoleBasedServices : IRoleBased
    {

        private readonly UnitOfWork _unitOfWork;

        public RoleBasedServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int CreateRoleBased(roleBasedEntities roleBasedEntities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<roleBasedEntities> getRoleBased()
        {
            //List<roleBasedEntities> ms = new List<roleBasedEntities>();
            //var vperson = _unitOfWork.personRepository.GetAll().ToList();
            return null;
        }

        public IEnumerable<roleBasedEntities> getRoleBasedBypolicyType(int policyType)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoleBased(int ID, roleBasedEntities roleBasedEntities)
        {
            throw new NotImplementedException();
        }
    }

    public class categoryRoleBasedServices : IcategoryRoleBased
    {
        private readonly UnitOfWork _unitOfWork;

        public categoryRoleBasedServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int CreateRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<classificationEntities> getRoleBased(classificationEntities roleBasedEntities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LOVTree> getRoleBased(LOVTree roleBasedTree)
        {
            
            return null;

            
        }

        public IEnumerable<BusinessEntities.CrudEntities.classificationEntities> getRoleBasedByID(int IDV, BusinessEntities.CrudEntities.classificationEntities roleBasedEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoleBased(BusinessEntities.CrudEntities.classificationEntities roleBasedEntities)
        {
            throw new NotImplementedException();
        }
    }
}
