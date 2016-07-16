using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface Isecurity
    {
        int isExist(LogOnModel model);
        bool AuthenticateLocal(LogOnModel model);
        bool AuthenticateLDAP(LogOnModel model);
        void UserSession();
        profileEntities getProfile(int id);
    }
}
