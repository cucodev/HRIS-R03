using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface IprofileIdentity
    {
        profileEntities getIdentityByIDV(int profileIDV);
        int addIdentity(int profileIDV, profileEntities personIdentityEntity);
        bool UpdateIdentity(int profileIDV, profileEntities personIdentityEntity);
        bool DeleteIdentity(int profileIDV, profileEntities personIdentityEntity);
    }
}
