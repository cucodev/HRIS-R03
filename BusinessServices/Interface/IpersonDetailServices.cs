using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    interface IpersonDetailServices
    {
        personDetailEntities GetPersonDetailById(int personIDV);
        IEnumerable<personDetailEntities> GetAllPersonsDetail();
        int CreatePersonDetail(personDetailEntities personDetailEntity);
        bool UpdatePersonDetail(int personIDV, personDetailEntities personDetailEntity);
        bool DeletePersonDetail(int personIDV);
    }
}
