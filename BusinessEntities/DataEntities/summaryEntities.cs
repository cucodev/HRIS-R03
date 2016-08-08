using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.DataEntities
{
    class summaryEntities
    {
    }

    public class leaveSummaryEntities
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public bool DurationLabel { get; set; }
        public int vCreatedBy { get; set; }
        public DateTime createTime { get; set; }
        public int policyID { get; set; }
        public int IDV { get; set; }
    }
}
