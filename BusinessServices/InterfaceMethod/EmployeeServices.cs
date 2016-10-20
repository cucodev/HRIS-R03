using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.UnitOfWork;
using BusinessServices.Interface;
using BusinessEntities.CrudEntities;
using System.Transactions;
using BusinessEntities;
using System.IO;
using System.Web.Hosting;
using DataModel.Model;

namespace BusinessServices.InterfaceMethod
{
    
    public class employeeServices : IEmployee
    {
        private readonly UnitOfWork _u;
        private readonly Mapping _map;
        private readonly FileDataServices _file;
        private readonly ListServices _list;
        private readonly SettingServices _setting;
        private int isDelete = 0;

        public employeeServices()
        {
            _u = new UnitOfWork();
            _map = new Mapping();
            _file = new FileDataServices();
            _list = new ListServices();
            _setting = new SettingServices();
        }

        public IEnumerable<employeeStructure> getStructure()
        {
            List<employeeStructure> ms = new List<employeeStructure>();
            var empJob = _u.personJobRepository.Get();
            if (empJob.Any())
            {
                foreach (personJob n in empJob)
                {
                    employeeStructure ts = new employeeStructure();
                    var emp = _u.personDetailRepository.GetByCode(a => a.IDV == n.IDV && a.isDeleted.HasValue);
                    var empParent = _u.personDetailRepository.GetByCode(a => a.IDV == n.parentIDV && a.isDeleted.HasValue);
                    if (emp != null)
                    {
                        if (emp.isDeleted == 0 && emp.ID > 0)
                        {
                            ts.ID = n.ID;
                            ts.IDV = n.IDV;
                            ts.NIP = emp.NIP.Trim();
                            ts.IDVName = emp.Name;
                            
                            ts.IDVImagePath = _file.ImagePath(emp.NIP);
                            
                        }
                    }

                    if (empParent != null)
                    {
                        if (empParent.isDeleted == 0 && empParent.ID > 0)
                        {
                            ts.parentIDV = n.parentIDV.HasValue ? n.parentIDV.Value : 0;
                            ts.parentName = empParent.Name;
                        }
                    }

                   
                    ms.Add(ts);
                }
            }

            return ms.AsEnumerable();
        }

        public int getApprovalIDV(int IDV)
        {
            var approvalIDV = _u.personJobRepository.GetByCode(b => b.IDV == IDV && b.isDeleted == 0);
            return approvalIDV.parentIDV.HasValue ? approvalIDV.parentIDV.Value : 0;
        }


        public IEnumerable<employeeDetail> getEmployeeByOrg(int OrgID)
        {
            List<employeeDetail> ms = new List<employeeDetail>();
            var person = _u.personRepository.GetMany(b => b.OrganizationID == OrgID);
            if (person.Any())
            {
                foreach (person p in person)
                {
                    var emp = _u.personDetailRepository.GetByCode(c => c.IDV == p.IDV && p.isDeleted == 0);
                    if (emp != null)
                    {
                        employeeDetail bc = new employeeDetail();
                        bc.ID = emp.ID;
                        bc.IDV = emp.IDV;
                        var xMarital = emp.Marital;
                        bc.Marital = _list.getStringCatName(emp.Marital ?? 0);
                        bc.Name = emp.Name;
                        bc.Nationality = _list.getStringCatName(emp.Nationality ?? 0);
                        bc.NickName = emp.NickName;
                        bc.NIP = emp.NIP;
                        bc.Religion = _list.getStringCatName(emp.Religion ?? 0);
                        bc.updateTime = emp.updateTime;
                        bc.vUpdatedBy = _list.getStringName(emp.vUpdatedBy ?? 0);
                        bc.createTime = emp.createTime;
                        bc.vCreatedBy = _list.getStringName(emp.vCreatedBy ?? 0);
                        bc.Birthdate = emp.Birthdate;
                        bc.Birthplace = emp.Birthplace;
                        bc.isDeleted = emp.isDeleted;
                        ms.Add(bc);
                    }
                }
            }
            return ms.AsEnumerable();
        }

        //MyMatrix
        public IEnumerable<employeeRoleBasedEntities> getCurrentRoleBased(int IDV)
        {
            List<employeeRoleBasedEntities> ms = new List<employeeRoleBasedEntities>();
            var emp = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == IDV && b.validDateStop < DateTime.Now );
            if (emp.Any())
            {
                foreach (employeeRoleBased px in emp)
                {
                    ms.Add(_map.EmployeeRoleBasedFromModel(px));
                }
            }

            return ms.AsEnumerable();
        }

        //Form Leave
        public IEnumerable<employeeRoleBasedEntities> getCurrentRoleBasedLeave(int IDV)
        {
            List<employeeRoleBasedEntities> ms = new List<employeeRoleBasedEntities>();
            var inPolicyType = new int[] { };
            inPolicyType = filterPolicyID(GlobalVariable.policyTypeLeave).ToArray();
            var emp = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == IDV && b.validDateStop >= DateTime.Now && inPolicyType.Contains(b.policyType));
            if (emp.Any())
            {
                foreach (employeeRoleBased px in emp)
                {
                    ms.Add(_map.EmployeeRoleBasedFromModel(px));
                }
            }

            return ms.AsEnumerable();
        }
        
        private List<int> filterPolicyID(string catCode)
        {
            List<int> inPolicyType = new List<int>();
            var list = _u.categoryParentRepository.GetMany(b => b.catCode.Trim() == catCode.Trim());
            if (list.Any())
            {
                foreach (categoryParent px in list)
                {
                    var listRolePolicyID = _u.roleBasedMatrixRepository.GetMany(b => b.PolicyType == px.catID);
                    if (listRolePolicyID.Any())
                    {
                        foreach (roleBasedMatrix cx in listRolePolicyID)
                        {
                            //System.Diagnostics.Debug.WriteLine("Data : " + cx.ID + ':' + px.catCode);
                            inPolicyType.Add(cx.ID);
                        }
                    }
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("Categoryparent NOT Found, code: " + catCode);
            }
            return inPolicyType;
        }

        //Form Medical
        public IEnumerable<employeeRoleBasedEntities> getCurrentRoleBasedMedical(int IDV)
        {
            List<employeeRoleBasedEntities> ms = new List<employeeRoleBasedEntities>();
            var inPolicyType = new int[] { };
            inPolicyType = filterPolicyID(GlobalVariable.policyTypeMedical).ToArray();
            var emp = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == IDV && b.validDateStop >= DateTime.Now  && inPolicyType.Contains(b.policyType));
            if (emp.Any())
            {
                foreach (employeeRoleBased px in emp)
                {
                    ms.Add(_map.EmployeeRoleBasedFromModel(px));
                }
            } 

            return ms.AsEnumerable();
        }

        //Form Annual
        public IEnumerable<employeeRoleBasedEntities> getCurrentRoleBasedAnnual(int IDV)
        {
            List<employeeRoleBasedEntities> ms = new List<employeeRoleBasedEntities>();
            var inPolicyType = new int[] { };
            inPolicyType = filterPolicyID(GlobalVariable.policyTypeAnnual).ToArray();
            var emp = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == IDV 
                                                                && b.validDateStop >= DateTime.Now
                                                                && inPolicyType.Contains(b.policyType));
            if (emp.Any())
            {
                foreach (employeeRoleBased px in emp)
                {
                    ms.Add(_map.EmployeeRoleBasedFromModel(px));
                }
            }

            return ms.AsEnumerable();
        }

        public Annual getAnnual(int IDV)
        {
            //Global
            Annual t = new Annual();
            List<AnnualLeave> ms = new List<AnnualLeave>();
            var inPolicyType = new int[] { };
            inPolicyType = filterPolicyID(GlobalVariable.policyTypeAnnual).ToArray();
            

            //Get Today
            DateTime Today = DateTime.Now;
            Int32 TodayYears = Today.Year;
            Int32 TodayMonth = Today.Month;
            Int32 TodayDay = Today.Day;
            
            //Get CarryOver Setting
            SettingEntities carryOverSetting = new SettingEntities();
            carryOverSetting = _setting.getValue(GlobalVariable.policyTypeAnnualCarry);
            int carryOverYears = Convert.ToInt32(carryOverSetting.value);
            System.Diagnostics.Debug.WriteLine("Carryover Years @ " + carryOverYears);

            //Get Current Leave Date
            var emp = _u.employeeRoleBasedRepository.GetSingle(b => b.IDV == IDV
                                                                && b.validDateStop >= DateTime.Now.AddYears(+1)
                                                                && inPolicyType.Contains(b.policyType));

            //Calculate CarryOver Datetime
            List<DateTime> CarryDateTime = new List<DateTime>();
            var currentLeave = emp.validDateStart ?? DateTime.Now;
            for (int i = carryOverYears; i >= 0; i--)
            {
                CarryDateTime.Add(currentLeave.AddYears(-i));
                System.Diagnostics.Debug.WriteLine(i.ToString() + ':' + DateTime.Now.AddYears(-i));
            }

            
            //Struct Current Leave
            var px = emp;
            AnnualLeave dt = new AnnualLeave();

            t.IDV = IDV;
                dt.ID = px.ID;
                dt.isCarryOver = false;
                dt.policyType = px.policyType;
                dt.roleBasedValue = px.roleBasedValue;
                dt.balanceValue = px.balanceValue;
                dt.currentValue = px.currentValue;
                dt.validDateStart = px.validDateStart;
                dt.validDateStop = px.validDateStop;
            ms.Add(dt);


            /*
            if (emp != null)
            {
                
                foreach (employeeRoleBased px in emp)
                {
                    AnnualLeave dt = new AnnualLeave();
                    dt.ID = px.ID;
                    dt.isCarryOver = false;
                    dt.policyType = px.policyType;
                    dt.roleBasedValue = px.roleBasedValue;
                    dt.balanceValue = px.balanceValue;
                    dt.currentValue = px.currentValue;
                    dt.validDateStart = px.validDateStart;
                    dt.validDateStop = px.validDateStop;
                    ms.Add(dt);
                    //ms.Add(_map.EmployeeRoleBasedFromModel(px));
                }
                t.AnnualData = ms;
            }*/
            return t;
        }

        
        public IEnumerable<employeeRoleBasedEntities> GetRoleBased(int IDV)
        {
            List<employeeRoleBasedEntities> ms = new List<employeeRoleBasedEntities>();
            var emp = _u.employeeRoleBasedRepository.GetMany(b => b.IDV == IDV);
            if (emp.Any())
            {
                foreach (employeeRoleBased px in emp)
                {
                    ms.Add(_map.EmployeeRoleBasedFromModel(px));
                }
            }

            return ms.AsEnumerable();
        }

        public profileEntities GetEmployee(int personIDV)
        {
            //throw new NotImplementedException();

            profileEntities ms = new profileEntities();
            var vperson = _u.personRepository.GetMany(b => b.IDV == personIDV).ToList();//.GetAll().ToList();
            System.Diagnostics.Debug.WriteLine("personIDV: " + personIDV);
            if (vperson.Any())
            {
                profileEntities x = new profileEntities();
                foreach (person n in vperson)
                {
                    System.Diagnostics.Debug.WriteLine("person: " + n.IDV);
                    //person
                    x.IDV = n.IDV;
                    x.OrganizationID = n.OrganizationID;
                    x.isDeleted = n.isDeleted;
                    x.vCreatedBy = n.vCreatedBy;
                    x.vUpdatedBy = n.vUpdatedBy;

                    //employee
                    var vemployee = _u.employeeRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (employee nn in vemployee)
                    {
                        x.employeeID = nn.ID;
                        x.UID_ABSENCE = nn.UID_ABSENCE;
                        x.joinDate = nn.joinDate;
                        x.resignDate = nn.resignDate;
                        x.contract1Start = nn.contract1Start;
                        x.contract1End = nn.contract1End;
                        x.contract2Start = nn.contract2Start;
                        x.contract2End = nn.contract2End;
                        x.contract3Start = nn.contract3Start;
                        x.contract3End = nn.contract3End;
                        x.active = nn.active;
                        x.employmentStatus = nn.employmentStatus;
                    }

                    //personDetail
                    var vpersonDetail = _u.personDetailRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personDetail nn in vpersonDetail)
                    {
                        x.personDetailID = nn.ID;
                        x.NIP = nn.NIP;
                        x.Name = nn.Name;
                        x.NickName = nn.NickName;
                        x.Nationality = nn.Nationality;
                        x.Birthplace = nn.Birthplace;
                        x.Birthdate = nn.Birthdate;
                        x.Marital = nn.Marital;
                        x.Religion = nn.Religion;
                        x.Gender = nn.Gender;
                    }

                    //ms.Add(x);
                }
                return x;
            }
            return null;
        }

        public employeeRoleBasedEntities getRoleBasedValue(int IDV, int policyType)
        {
            var Data = _u.employeeRoleBasedRepository.GetByCode(b => b.IDV == IDV && b.policyType == policyType);
            if (Data.ID != 0)
            {
                
                return _map.EmployeeRoleBasedFromModel(Data);
            }
            return null;
        }

        public employeeRoleBasedEntities getRoleBasedAnnualValue(int IDV)
        {
            throw new NotImplementedException();
        }
    }
}
