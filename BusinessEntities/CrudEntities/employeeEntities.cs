using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
   
    //define each employee rolebase
    public class employeeRoleBasedEntities
    {
        public int ID { get; set; }
        public int IDV { get; set; }
        public int serviceYears { get; set; }
        public int serviceDays { get; set; }
        public int policyType { get; set; }
        public int valueType { get; set; }
        public Nullable<int> roleBasedValue { get; set; }
        public Nullable<int> currentValue { get; set; }
        public Nullable<int> balanceValue { get; set; }
        public Nullable<int> remainingValue { get; set; }
        public Nullable<System.DateTime> validDateStart { get; set; }
        public Nullable<System.DateTime> validDateStop { get; set; }
        public string decription { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    }

    public class employeeLeaveEntities
    {
        //null
    }

    public class employeeApprovalEntities
    {
        //null
    }

}
