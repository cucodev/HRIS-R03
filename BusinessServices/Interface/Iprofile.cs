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

    

    public interface IprofileEdu
    {
        IEnumerable<profileEduEntities> getEduByIDV(int profileIDV);
        int addEdu( profileEduEntities personIdentityEntity);
        bool UpdateEdu(int profileIDV, profileEduEntities personIdentityEntity);
        bool DeleteEdu(int profileIDV, profileEduEntities personIdentityEntity);
    }

    public interface IprofileSkill
    {
        IEnumerable<profileSkillEntities> getSkillByIDV(int profileIDV);
        int addSkill(profileSkillEntities personIdentityEntity);
        bool UpdateSkill(int profileIDV, profileSkillEntities personIdentityEntity);
        bool DeleteSkill(int profileIDV, profileSkillEntities personIdentityEntity);
    }

    public interface IprofileLanguage
    {
        IEnumerable<profileLanguageEntities> getLanguageByIDV(int profileIDV);
        int addLanguage(profileLanguageEntities personIdentityEntity);
        bool UpdateLanguage(int profileIDV, profileLanguageEntities personIdentityEntity);
        bool DeleteLanguage(int profileIDV, profileLanguageEntities personIdentityEntity);
    }

    public interface IprofileTraining
    {
        IEnumerable<profileTrainingEntities> getTrainingByIDV(int profileIDV);
        int addTraining(profileTrainingEntities personIdentityEntity);
        bool UpdateTraining(int profileIDV, profileTrainingEntities personIdentityEntity);
        bool DeleteTraining(int profileIDV, profileTrainingEntities personIdentityEntity);
    }

    public interface IprofileCertification
    {
        IEnumerable<profileCertificationEntities> getCertificationByIDV(int profileIDV);
        int addCertification(profileCertificationEntities personIdentityEntity);
        bool UpdateCertification(int profileIDV, profileCertificationEntities personIdentityEntity);
        bool DeleteCertification(int profileIDV, profileCertificationEntities personIdentityEntity);
    }

    public interface IprofileIdentity
    {
        IEnumerable<profileIdentityEntities> getIdentityByIDV(int profileIDV);
        int addIdentity(profileIdentityEntities personIdentityEntity);
        bool UpdateIdentity(int profileIDV, profileIdentityEntities personIdentityEntity);
        bool DeleteIdentity(int profileIDV, profileIdentityEntities personIdentityEntity);
    }

    public interface IprofileDependent
    {
        IEnumerable<profileDependentEntities> getDependentByIDV(int parentIDV);
        int addDependent(profileDependentEntities personDependentEntity);
        bool UpdateDependent(int parentIDV, profileDependentEntities personDependentEntity);
        bool DeleteDependent(int parentIDV, profileDependentEntities personDependentEntity);
    }

    public interface IprofileJob
    {
        IEnumerable<profileJobEntities> getJobByIDV(int IDV);
        int addJob(profileJobEntities personJobEntity);
        bool UpdateJob(int parentIDV, profileJobEntities personJobEntity);
        bool DeleteJob(int parentIDV, profileJobEntities personJobEntity);
    }
}
