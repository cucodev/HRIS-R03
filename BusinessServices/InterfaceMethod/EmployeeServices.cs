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

namespace BusinessServices.InterfaceMethod
{
    
    public class employeeServices : IEmployee
    {
        private readonly UnitOfWork _u;
        private readonly Mapping _map;
        private int isDelete = 0;

        public employeeServices()
        {
            _u = new UnitOfWork();
            _map = new Mapping();
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
                            ts.IDVName = emp.Name;
                            string ImagePath = GlobalVariable.pathImageURL + emp.NIP.Trim() + ".png";
                            string curFile = @ImagePath;
                            if (File.Exists(curFile))
                            {
                                System.Diagnostics.Debug.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
                                ts.IDVImagePath = ImagePath;
                            }
                            else
                            {
                                ts.IDVImagePath = GlobalVariable.pathImageURL + "person.png";
                            }

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
                            System.Diagnostics.Debug.WriteLine("Data : " + cx.ID + ':' + px.catCode);
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
