using AutoMapper;
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

    //Manage Category Implementation
    public class RoleBasedMatrixServices : IManageRoleBasedMatrix
    {
        private readonly UnitOfWork _u;

        public RoleBasedMatrixServices()
        {
            _u = new UnitOfWork();
        }

        public int CreateMatrix(roleBasedMatrixEntities p)
        {

            using (var scope = new TransactionScope())
            {
                var px = new roleBasedMatrix
                {
                    PolicyType = p.PolicyType,
                    PolicyName = p.PolicyName,
                    ValueType = p.ValueType,

                    vCreatedBy = p.vCreatedBy,
                    createTime = DateTime.Now
                };
                _u.roleBasedMatrixRepository.Insert(px);
                _u.Save();
                scope.Complete();
                return px.ID;
            }
        }

        public bool DeleteMatrix(int ID)
        {
            var success = false;
            if (ID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var p = _u.roleBasedMatrixRepository.GetByID(ID);
                    if (p != null)
                    {
                        _u.roleBasedMatrixRepository.Delete(p);
                        _u.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<roleBasedMatrixEntities> getMatrix()
        {
            var p = _u.roleBasedMatrixRepository.GetAll().ToList();
            if (p.Any())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<List<roleBasedMatrix>, List<roleBasedMatrixEntities>>();
                });

                IMapper mapper = config.CreateMapper();
                var source = new List<roleBasedMatrix>();
                var dest = mapper.Map<List<roleBasedMatrix>, List<roleBasedMatrixEntities>>(source);
               return dest;
            }
            return null;
        }

        public roleBasedMatrixEntities getMatrixByID(int ID)
        {
            var p = _u.roleBasedMatrixRepository.GetByID(ID);
            if (p != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<roleBasedMatrix, roleBasedMatrixEntities>();
                });

                IMapper mapper = config.CreateMapper();
                var source = new roleBasedMatrix();
                var dest = mapper.Map<roleBasedMatrix, roleBasedMatrixEntities>(source);
                return dest;
            }
            return null;
        }

        public bool UpdateMatrix(int ID, roleBasedMatrixEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.roleBasedMatrixRepository.GetByID(ID);
                    if (px != null)
                    {
                        px.PolicyType = p.PolicyType;
                        px.PolicyName = p.PolicyName;
                        px.ValueType = p.ValueType;

                        px.vUpdatedBy = p.vUpdatedBy;
                        px.updateTime = DateTime.Now;

                        _u.roleBasedMatrixRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }


    //Tree Type, unused
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

    //Add Category Rolebased in category, Unsused
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
