using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface IdataSetup
    {
    }

    public interface IroleBased
    {
        IEnumerable<roleBasedEntities> getRoleBased(int IDV);
        int CreateRoleBased(roleBasedEntities EroleBased);
        bool UpdateRoleBased(roleBasedEntities EroleBased);
    }
}
