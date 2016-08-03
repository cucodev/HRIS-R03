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
    }
}
