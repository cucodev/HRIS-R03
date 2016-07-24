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
                            //Find PolicyType with each IDV
                            var empRole = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == p.IDV && b.policyType == role.PolicyType);
                            if (empRole.Any())
                            {
                                //Update
                            } else
                            {
                                mp.IDV = IDV;
                                mp.policyType = role.PolicyType;
                                mp.valueType = role.ValueType.HasValue ? role.ValueType.Value : 0;
                                mp.updateTime = DateTime.Now;
                                //mp.vUpdatedBy = 
                                System.Diagnostics.Debug.WriteLine("Data: ", mp);
                                _u.employeeRoleBasedRepository.Insert(mp);
                                _u.Save();
                                scope.Complete();
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
