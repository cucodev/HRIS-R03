using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
namespace BusinessServices
{
    public interface IpersonServices
    {
        personEntities GetPersonById(int personIDV);
        IEnumerable<personEntities> GetAllPersons();
        int CreatePerson(personEntities personEntity);
        bool UpdatePerson(int personIDV, personEntities personEntity);
        bool DeletePerson(int personIDV, int vUpdatedBy);
    }
}
