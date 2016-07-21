using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BusinessServices.InterfaceMethod
{
    public class LevelServices : IcategoryLevel
    {

    }

    public class RoleBasedServices : IRoleBased
    {

        private readonly UnitOfWork _unitOfWork;
        public int i = 0;

        public RoleBasedServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int CreateRoleBased(roleBasedEntities p)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var u = new roleBased
                    {
                        policyType = p.policyType,
                        empLevel = p.empLevel,
                        valueType = p.valueType,
                        value = p.value
                    };

                    _unitOfWork.roleBasedRepository.Insert(u);
                    _unitOfWork.Save();
                    scope.Complete();
                    i = u.ID;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Error while Insert to roleBasedRepository", e.Message);
                }
            }
            return i;
        }

        public IEnumerable<roleBasedEntities> getRoleBased()
        {
            List<roleBasedEntities> ms = new List<roleBasedEntities>();
            var vData = _unitOfWork.roleBasedRepository.GetAll().ToList();
            if (vData.Any())
            {
                foreach (roleBased v in vData)
                {
                    roleBasedEntities vTemp = new roleBasedEntities();
                    vTemp.ID = v.ID;
                    vTemp.policyType = v.policyType;
                    vTemp.empLevel = v.empLevel;
                    vTemp.valueType = v.valueType;
                    vTemp.value = v.value;
                    ms.Add(vTemp);
                }
                return ms.AsEnumerable();
            }
            return null;
        }

        public IEnumerable<roleBasedEntities> getRoleBasedBypolicyType(int policyType)
        {
            List<roleBasedEntities> ms = new List<roleBasedEntities>();
            var vData = _unitOfWork.roleBasedRepository.GetMany(b=>b.policyType == policyType );//.GetAll().ToList();
            if (vData.Any())
            {
                foreach (roleBased v in vData)
                {
                    roleBasedEntities vTemp = new roleBasedEntities();
                    vTemp.ID = v.ID;
                    vTemp.policyType = v.policyType;
                    vTemp.empLevel = v.empLevel;
                    vTemp.valueType = v.valueType;
                    vTemp.value = v.value;
                    ms.Add(vTemp);
                }
                return ms.AsEnumerable();
            }
            return null;
        }

        public bool UpdateRoleBased(int id, roleBasedEntities p)
        {

            var res = false;
            roleBasedEntities ms = new roleBasedEntities();
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var u = _unitOfWork.roleBasedRepository.GetByID(id);
                    if (u != null)
                    {
                        //u.ID = p.ID;
                        u.policyType = p.policyType;
                        u.empLevel = p.empLevel;
                        u.valueType = p.valueType;
                        u.value = p.value;
                        try
                        {
                            _unitOfWork.roleBasedRepository.Update(u);
                            _unitOfWork.Save();
                            res = true;
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Error while Save to roleBasedRepository", e.Message);
                        }
                    }

                }
            }

            return res;
        }

        public bool DeleteRoleBased(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var p = _unitOfWork.roleBasedRepository.GetByID(id);
                    if (p != null)
                    {

                        _unitOfWork.roleBasedRepository.Delete(p);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
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
