using BusinessEntities.CrudEntities;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
    public interface IUser
    {
        IEnumerable<UserEntities> getUsers();
        user getUser(int IDV);
        bool putUser(user px);
        bool postUser(int IDV);
        bool deleteUser(int IDV);
    }
}
