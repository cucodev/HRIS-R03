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

        //GENERAL
        //Get catCode by ID from ParentsCategory
        private string getCatCode(int ID)
        {
            var get = _u.categoryParentRepository.GetByID(ID);
            return (get.catCode).Trim();
        }

        //Get ID by catCode from ParentsCategory
        private int getCatID(string catCode)
        {
            var get = _u.categoryParentRepository.GetByCode(b=>(b.catCode).Trim()  == catCode.Trim());
            return get.catID;
        }

        private int calculateDays(DateTime StartDate)
        {
            //Calculate Years and Days
            var EndDate = DateTime.Now;
            //var sYear = ((EndDate - StartDate).TotalDays) / 365.242199;
            var sDay = (EndDate - StartDate).Days;
            return (int)sDay;
        }

        private double calculateYears(DateTime StartDate)
        {
            //Calculate Years and Days
            var EndDate = DateTime.Now;
            var sYear = ((EndDate - StartDate).TotalDays) / 365.242199;
            //var sDay = (EndDate - StartDate).Days;
            return (double)sYear;
        }

        //Update employee service duration data
        //tbl: employee
        public int updateEmployeeServiceYear(int IDV)
        {
            var EmpID = _u.employeeRepository.GetMany(b => b.IDV == IDV);
            using (var scope = new TransactionScope())
            {
                foreach (employee e in EmpID)
                {
                    
                    //Save                
                    e.serviceDay = calculateDays(e.joinDate);
                    e.serviceYear = calculateYears(e.joinDate);
                    e.updateTime = DateTime.Now;
                    //e.vUpdatedBy =
                    _u.employeeRepository.Update(e);
                    _u.Save();
                    scope.Complete();
                }
            }
            return 0;
        }


        //NEED TO ADD FILTER VALID YEARS
        private bool isAnnualExist(int IDV, int Years)
        {
            var policyID = _u.roleBasedMatrixRepository.GetAll().ToList();
            if (policyID.Any())
            {
                foreach (roleBasedMatrix role in policyID)
                {
                    string annualCatCode = getCatCode(role.PolicyType);
                    if ((GlobalVariable.policyTypeAnnual).Trim() == annualCatCode.Trim())
                    {
                        var isOK = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == IDV && b.policyType == role.ID && (b.validDateStart.Value.Year) == Years);
                        if (isOK.Any())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool isRegularRoleExist(int IDV, int policyID)
        {
            var isOK = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == IDV && b.ID == policyID);
            if (isOK.Any())
            {
                return true;
            }
            return false;
        }


        private employeeRoleBased mapUpdateField(employeeRoleBased ph, roleBasedMatrix role, string Level)
        {
            //employeeRoleBased ph = new employeeRoleBased();

            ph.policyType = role.ID;
            ph.roleBasedValue = roleBasedValueByLevel(Level, role.ID);
            ph.valueType = role.ValueType.HasValue ? role.ValueType.Value : 0;
            ph.updateTime = DateTime.Now;

            return ph;
        }

        private employeeRoleBased mapInsertField(roleBasedMatrix role, string Level)
        {
            return null;
        }

        //Update empployeeRoleMatrix data
        //tbl: employeeRoleBased
        public bool updateEmployeeRoleBased(int IDV, int IDVUpdate)
        {
            employeeRoleBased mp = new employeeRoleBased();

            //GET ALL EMPLOYEE
            //TBL: EMPLOYEE
            #region LOOPING EMPLOYEE
            var EmpID = _u.employeeRepository.GetMany(b => b.IDV == IDV);
            if (EmpID.Any())
            {
                using (var scope = new TransactionScope())
                {
                    foreach (employee p in EmpID)
                    {
                        #region LOOPING YEARS TO NOW // STRICT TO LAST 5 YEARS BACKWARDS ONLY 
                        int CurrentYears = DateTime.Now.Year;
                        int EmpYears = p.joinDate.Year;
                        int YearLoop = CurrentYears - EmpYears;
                        if (YearLoop >= 5) YearLoop = 5;

                        while (YearLoop >= 1)
                        {
                            System.Diagnostics.Debug.WriteLine(" -------------------- Years Loop: " + YearLoop + " : " + (CurrentYears - 1));

                            var Current = (p.joinDate).Month + "/" + (p.joinDate).Day + "-" + CurrentYears;
                            var Next = (p.joinDate).Month + "/" + (p.joinDate).Day + "/" + (CurrentYears + 1);
                            //System.Diagnostics.Debug.WriteLine("Next: {0}", Next);
                            DateTime validStart = Convert.ToDateTime(Current);
                            DateTime validEnd = Convert.ToDateTime(Next);

                            int matchFound = 0;

                            #region LOOPING ROLEBASED CATEGORY 
                            var policyRole = _u.roleBasedMatrixRepository.GetAll().ToList();
                            foreach (roleBasedMatrix role in policyRole)
                            {
                                //LOOPING CATEGORY ROLEBASED

                                //Get Job Level of each IDV
                                #region GET EMPLOYEE JOBLEVEL
                                var empJob = _u.personJobRepository.GetByCode(b => b.IDV == p.IDV);
                                if (empJob.JobLevel != null)
                                {
                                    //get Level of IDV
                                    string Level = getCatCode(empJob.JobLevel.HasValue ? empJob.JobLevel.Value : 0);

                                    //Get Current policyType Code (not policyID in employeeRoleBased) from categoryParent
                                    string annualCatCode = getCatCode(role.PolicyType);

                                    //Get Current policyType ID from categoryParent
                                    int annualCatID = getCatID(annualCatCode);

                                    #region LOOPING employeeRoleBased
                                    //Find PolicyID with each IDV, empRole below policyType = policyID
                                    var empRole = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == p.IDV && b.policyType == role.ID && (b.validDateStart.Value.Year) == CurrentYears);
                                    #region DATA EXIST, DO UPDATE THIS
                                    if (empRole.Any())
                                    {

                                        foreach (employeeRoleBased ph in empRole)
                                        {
                                            #region UPDATE EmployeeRoleBased
                                            #region IF ANNUAL EXIST, THEN UPDATE THIS
                                            if (isAnnualExist(p.IDV, CurrentYears))
                                            {
                                                double value = (Math.Round(calculateYears(p.joinDate)));
                                                int empServiceYears = Convert.ToInt32(value);
                                                int roleLimit = role.Value.HasValue ? role.Value.Value : 0;
                                                int x = empServiceYears + roleLimit;
                                                if ((x <= 0))
                                                {
                                                    System.Diagnostics.Debug.WriteLine("UPDATE ANNUAL LEAVE " + p.IDV);

                                                    matchFound = 1;

                                                    _u.employeeRoleBasedRepository.Update(mapUpdateField(ph, role, Level));
                                                    _u.Save();
                                                }
                                            }
                                            #endregion
                                            #region IF ANNUAL NOT EXIST, THEN UPDATE GENERAL EXCEPTS ANNUAL
                                            else
                                            {
                                                System.Diagnostics.Debug.WriteLine("UPDATE GENERAL: " + p.IDV);
                                                _u.employeeRoleBasedRepository.Update(mapUpdateField(ph, role, Level));
                                                _u.Save();
                                            }
                                            #endregion
                                            #endregion
                                        }
                                    }
                                    #endregion
                                    #region DATA NOT EXIST, DO INSERT BELOW
                                    else
                                    {
                                        //DO INSERT REGULAR ROLE
                                        //IF ROLE IS NOT ANNUAL ROLE, DO INSERT REGULAR ROLE
                                        #region INSERT REGULAR ROLE
                                        #region IF ROLE NOT ANNUAL
                                        if (role.PolicyType != getCatID(GlobalVariable.policyTypeAnnual))
                                        {
                                            if (!isRegularRoleExist(p.IDV, role.ID)) { 
                                                var px = new employeeRoleBased
                                                {
                                                    IDV = IDV,
                                                    policyType = role.ID,
                                                    roleBasedValue = roleBasedValueByLevel(Level, role.ID),
                                                    valueType = role.ValueType.HasValue ? role.ValueType.Value : 0,
                                                    validDateStart = validStart,
                                                    validDateStop = validEnd,
                                                    createTime = DateTime.Now
                                                };
                                                _u.employeeRoleBasedRepository.Insert(px);
                                                _u.Save();
                                                System.Diagnostics.Debug.WriteLine("INSERT GENERAL: ", p.IDV);
                                            }
                                        }
                                        #endregion
                                        #endregion
                                        #region INSERT ANNUAL ROLE
                                        #region IF ROLE ANNUAL
                                        else
                                        {
                                            #region IF ANNUAL EXIST
                                            //DO INSERT ANNUAL ROLE
                                            //IF ANNUAL LEAVE NOT EXIST YET THEN DO INSERT ANNUAL ROLE

                                            if (!isAnnualExist(p.IDV, CurrentYears))
                                            {
                                                double value = (Math.Round(calculateYears(p.joinDate)));
                                                int empServiceYears = Convert.ToInt32(value);

                                                //Define Annual Year based on employee services year
                                                //get Annual Years basis limit
                                                int roleLimit = role.Value.HasValue ? role.Value.Value : 0;
                                                // Employee Service Years + (negatif roleLimit)
                                                int x = empServiceYears + roleLimit;

                                                //IF X is Negatif Value = in Role Limit Range 
                                                if ((x <= 0) && matchFound == 0)
                                                {
                                                    System.Diagnostics.Debug.WriteLine("INSERT ANNUAL LEAVE ", p.IDV);
                                                    matchFound = 1;
                                                    var px = new employeeRoleBased
                                                    {
                                                        IDV = IDV,
                                                        policyType = role.ID,
                                                        roleBasedValue = roleBasedValueByLevel(Level, role.ID),
                                                        valueType = role.ValueType.HasValue ? role.ValueType.Value : 0,
                                                        validDateStart = validStart,
                                                        validDateStop = validEnd,
                                                        createTime = DateTime.Now
                                                    };
                                                    _u.employeeRoleBasedRepository.Insert(px);
                                                    _u.Save();
                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion
                                        #endregion
                                    }
                                    #endregion

                                    #endregion
                                }
                                #endregion
                            }
                            #endregion

                            CurrentYears--;
                            YearLoop--;
                        }

                        #endregion



                    }
                    scope.Complete();
                }
            }
            #endregion
            return false;
        }

        //Switch case for job level, used in updateServiceType to get value by joblevel
        private int roleBasedValueByLevel(string JobLevelCode, int PolicyID)
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

        public double checkServiceYearDuration(int IDV)
        {
            var Emp = _u.employeeRepository.GetSingle(b => b.IDV == IDV);
            return Emp.serviceYear.HasValue ? Emp.serviceYear.Value : 0;
        }

        public int checkServiceDayDuration(int IDV)
        {
            var Emp = _u.employeeRepository.GetSingle(b => b.IDV == IDV);
            return Emp.serviceDay.HasValue ? Emp.serviceDay.Value : 0;
        }

        public int getBalance(int IDV, int policyID)
        {
            throw new NotImplementedException();
        }

        public int getRoleBasedBalance(int IDV, int policyID)
        {
            throw new NotImplementedException();
        }

        public int getRemainingBalance(int IDV, int policyID)
        {
            throw new NotImplementedException();
        }

        public int isValid(int IDV, int policyID)
        {
            throw new NotImplementedException();
        }

        public bool isLeaveCarryOver(int IDV)
        {
            throw new NotImplementedException();
        }

        public int isAnnualLeave(int policyID)
        {
            throw new NotImplementedException();
        }
    }
}
