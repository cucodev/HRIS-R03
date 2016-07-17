using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface IMasterData
    {
    }

    public interface IroleBased
    {
        IEnumerable<listEntities> getAll();
        int Create(listEntities listEntities);
        bool Update(int ID, listEntities listEntities);
    }
}
