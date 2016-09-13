
using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.CrudEntities;
using DataModel.UnitOfWork;
using DataModel.Model;

namespace BusinessServices.InterfaceMethod
{
    public class UserServices : IUser
    {
        private readonly UnitOfWork _u;

        public UserServices()
        {
            _u = new UnitOfWork();
        }


        public bool deleteUser(int IDV)
        {
            throw new NotImplementedException();
        }

        public user getUser(int IDV)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntities> getUsers()
        {
            List<UserEntities> p = new List<UserEntities>();
            var pL = _u.userRepository.GetAll().ToList();
            if (pL.Any())
            {
                foreach (user px in pL)
                {
                    UserEntities x = new UserEntities();
                    x.ID = px.ID;
                    x.IDV = px.IDV;
                    x.IDVMAIL = px.IDVMAIL;
                    x.IDVMAILPASSWORD = px.IDVMAILPASSWORD;
                    x.IDVROLE = px.IDVROLE;
                    p.Add(x);
                }
            }
            return p.AsEnumerable();
        }

        public bool postUser(int IDV)
        {
            throw new NotImplementedException();
        }

        public bool putUser(user px)
        {
            throw new NotImplementedException();
        }
    }
}
