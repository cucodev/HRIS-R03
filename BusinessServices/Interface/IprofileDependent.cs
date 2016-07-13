using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface IprofileDependent
    {
        profileEntities getDependentByIDV(int parentIDV);
        int addDependent(int parentIDV, profileEntities personDependentEntity);
        bool UpdateDependent(int parentIDV, profileEntities personDependentEntity);
        //IEnumerable<profileDependentEntities> GetAllDependentProfiles(int OrgID);
        //bool DeleteProfile(int personIDV, int vUpdatedBy);
    }
}
