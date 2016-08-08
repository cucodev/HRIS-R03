using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.DataEntities
{
    
    public class purpose
    {
        //Purpose
        public int purposeID { get; set; }
        public string purposeName { get; set; }
        public string purposeDescription { get; set; }
    }

    public class transactionMaster
    {
        //transaction
        public int txID { get; set; }
        public Nullable<int> purposeID { get; set; }
        public Nullable<int> purposeStatus { get; set; }
        public Nullable<int> idvRequest { get; set; }
        public Nullable<int> idvApproval { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdateBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }

        public virtual purpose C_purpose { get; set; }
    }


    public class transactionLeave
    {
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
