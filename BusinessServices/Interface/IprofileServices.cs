using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface IprofileServices
    {
        profileEntities GetProfileById(int personIDV);
        IEnumerable<profileEntities> GetAllProfiles();
        IEnumerable<profileEntities> GetAllOrgProfiles(int orgID);
        int CreateProfile(profileEntities personEntity);
        bool UpdateProfile(int personID, profileEntities personEntity);
        bool DeleteProfile(int personIDV, int vUpdatedBy);
    }
}
