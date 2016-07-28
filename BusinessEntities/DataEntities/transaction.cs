using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.DataEntities
{
    
    public class transaction
    {
        //Purpose
        public int purposeID { get; set; }
        public string purposeName { get; set; }
        public string purposeDescription { get; set; }
    }

    public class transactionApproval
    {
        //transaction
        public int txID { get; set; }
        public Nullable<int> purposeID { get; set; }
        public Nullable<int> purposeStatus { get; set; }
        public Nullable<int> idvRequest { get; set; }
        public Nullable<int> idvApproval { get; set; }

        public virtual transaction tx { get; set; }
    }


    public class transactionLeave
    {
        public virtual transactionApproval txApproval { get; set; }

        public int ID { get; set; }
        public Nullable<int> txID { get; set; }
        public Nullable<int> policyID { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<int> dayDuration { get; set; }
        public string noteHeader { get; set; }
        public string noteContent { get; set; }
        public Nullable<int> isDeleted { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdateBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    }
}
