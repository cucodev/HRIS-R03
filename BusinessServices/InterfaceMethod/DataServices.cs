using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Interface;
using BusinessEntities.CrudEntities;
using System.Transactions;
using DataModel;
using DataModel.UnitOfWork;
using BusinessEntities;

namespace BusinessServices.InterfaceMethod
{
    public class DataServices : IData
    {
        private readonly UnitOfWork _u;

        public DataServices()
        {
            _u = new UnitOfWork();
        }

        public int updateServiceYear(int IDV)
        {
            var EmpID = _u.employeeRepository.GetMany(b => b.IDV == IDV);
            using (var scope = new TransactionScope())
            {
                foreach (employee e in EmpID)
                {
                    //Calculate Years and Days
                    var EndDate = DateTime.Now;
                    var ijoin = e.joinDate;
                    var StartDate = ijoin;
                    var sYear = ((EndDate - StartDate).TotalDays) / 365.242199;
                    var sDay = (EndDate - StartDate).Days;
                    System.Diagnostics.Debug.WriteLine("IDV: " + IDV + ", Name: " + e.joinDate + ", Year: " + sYear.ToString() + ", Days: " + sDay.ToString());

                    //Save
                    e.serviceDay = (int)sDay;
                    e.serviceYear = (double)sYear;
                    e.updateTime = DateTime.Now;
                    //e.vUpdatedBy =


                    _u.employeeRepository.Update(e);
                    _u.Save();
                    scope.Complete();
                }
            }
            return 0;
        }

        //Get catCode by ID from ParentsCategory
        public string getCatCode(int ID)
        {
            var get = _u.categoryParentRepository.GetByID(ID);
            return (get.catCode).Trim();
        }

        //Switch case for job level
        public int selectValue(string JobLevelCode, int PolicyID)
        {
            var get = _u.roleBasedMatrixRepository.GetByID(PolicyID);
            int value;
            switch (JobLevelCode)
            {
                case "L1": value = get.L1.HasValue ? get.L1.Value : 0; break;
                case "L2": value = get.L2.HasValue ? get.L2.Value : 0; break;
                case "L3": value = get.L3.HasValue ? get.L3.Value : 0; break;
                case "L4": value = get.L4.HasValue ? get.L4.Value : 0; break;
                case "L5": value = get.L5.HasValue ? get.L5.Value : 0; break;
                case "L6": value = get.L6.HasValue ? get.L6.Value : 0; break;
                case "L7": value = get.L7.HasValue ? get.L7.Value : 0; break;
                case "L8": value = get.L8.HasValue ? get.L8.Value : 0; break;
                case "L9": value = get.L9.HasValue ? get.L9.Value : 0; break;
                default: value = 0; break;
            }
            return value;
        }

        public bool updateServiceType(int IDV)
        {
            employeeRoleBased mp = new employeeRoleBased();
            var EmpID = _u.employeeRepository.GetMany(b => b.IDV == IDV);
            if (EmpID.Any())
            {
                using (var scope = new TransactionScope())
                {
                    foreach (employee p in EmpID)
                    {
                        //Get All Category
                        var policyRole = _u.roleBasedMatrixRepository.GetAll().ToList();
                        foreach (roleBasedMatrix role in policyRole)
                        {
                            //Get Job Level of each IDV
                            var empJob = _u.personJobRepository.GetByCode(b => b.IDV == p.IDV);
                            if (empJob.JobLevel != null)
                            {
                                //get Level of IDV
                                string Level = getCatCode(empJob.JobLevel.HasValue ? empJob.JobLevel.Value : 0);

                                //Find PolicyType with each IDV
                                var empRole = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == p.IDV && b.policyType == role.ID);
                                
                                if (empRole.Any())
                                {
                                    foreach (employeeRoleBased pg in empRole)
                                    {
                                        pg.policyType = role.ID;
                                        pg.roleBasedValue = selectValue(Level, role.ID);
                                        pg.valueType = role.ValueType.HasValue ? role.ValueType.Value : 0;
                                        pg.updateTime = DateTime.Now;

                                        _u.employeeRoleBasedRepository.Update(pg);
                                        _u.Save();
                                    }
                                        
                                   
                                } else
                                {
                                    var px = new employeeRoleBased
                                    {
                                        IDV = IDV,
                                        policyType = role.ID,
                                        roleBasedValue = selectValue(Level, role.ID),
                                        valueType = role.ValueType.HasValue ? role.ValueType.Value : 0,
                                        updateTime = DateTime.Now
                                    };
                                    _u.employeeRoleBasedRepository.Insert(px);
                                    _u.Save();
                                }
                                
                            }
                        }
                    }
                    scope.Complete();
                }
            }
            return false;
        }
    }
}
