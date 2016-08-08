using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessEntities.DataEntities;

namespace BusinessServices.Interface
{
    public interface IEmail
    {
        string createLeaveEmailBody(string Name, string policyTypeName, List<leaveSummaryEntities> appliedDates, int Balance, string template);

    }
}
