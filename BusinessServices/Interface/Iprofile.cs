using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    //Maintain Matrix Role of Employee
    public interface IprofileRoleBased
    {
        IEnumerable<roleBasedEntities> getRoleBased(int IDV);
        int CreateRoleBased(roleBasedEntities EroleBased);
        bool UpdateRoleBased(roleBasedEntities EroleBased);
    }

    public interface Iprofile
    {
        profileEntities GetProfileById(int personIDV);
        IEnumerable<profileEntities> GetAllProfiles();
        IEnumerable<profileEntities> GetAllOrgProfiles(int orgID);
        int CreateProfile(profileEntities personEntity);
        bool UpdateProfile(int personID, profileEntities personEntity);
        bool DeleteProfile(int personIDV, int vUpdatedBy);
    }

    public interface IprofileIdentity
    {
        profileEntities getIdentityByIDV(int profileIDV);
        int addIdentity(int profileIDV, profileEntities personIdentityEntity);
        bool UpdateIdentity(int profileIDV, profileEntities personIdentityEntity);
        bool DeleteIdentity(int profileIDV, profileEntities personIdentityEntity);
    }

    public interface IprofileDependent
    {
        profileEntities getDependentByIDV(int parentIDV);
        int addDependent(int parentIDV, profileEntities personDependentEntity);
        bool UpdateDependent(int parentIDV, profileEntities personDependentEntity);
    }

    public interface IprofileJobServices
    {
        profileJobEntities getJobByIDV(int parentIDV);
        int addJob(int parentIDV, profileJobEntities personJobEntity);
        bool UpdateJob(int parentIDV, profileJobEntities personJobEntity);
    }
}
