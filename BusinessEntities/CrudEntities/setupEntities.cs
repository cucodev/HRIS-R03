using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    
    public class roleBasedEntities
    {
        public int ID { get; set; }
        public Nullable<int> policyType { get; set; }
        public Nullable<int> empLevel { get; set; }
        public Nullable<int> valueType { get; set; }
        public Nullable<int> value { get; set; }
    }

    public class roleBasedMatrixEntities
    {
        public int ID { get; set; }
        public int PolicyType { get; set; }
        public string PolicyName { get; set; }
        public Nullable<int> Value { get; set; }
        public Nullable<int> ValueType { get; set; }
        public Nullable<int> L1 { get; set; }
        public Nullable<int> L2 { get; set; }
        public Nullable<int> L3 { get; set; }
        public Nullable<int> L4 { get; set; }
        public Nullable<int> L5 { get; set; }
        public Nullable<int> L6 { get; set; }
        public Nullable<int> L7 { get; set; }
        public Nullable<int> L8 { get; set; }
        public Nullable<int> L9 { get; set; }
        public Nullable<int> L10 { get; set; }
        public Nullable<int> L11 { get; set; }
        public Nullable<int> L12 { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    }

    public class tempEntities
    {
        public int ID { get; set; }
        public int type { get; set; }
        public int value { get; set; }
        public int valueType { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int x3 { get; set; }
        public int x4 { get; set; }
        public int x5 { get; set; }
        public int x6 { get; set; }
        public int x7 { get; set; }
        public int x8 { get; set; }
        public int x9 { get; set; }
        public int x10 { get; set; }
        public int x11 { get; set; }
        public int x12 { get; set; }
        public int x14 { get; set; }
        public int x15 { get; set; }
        public int x16 { get; set; }
        public int x17 { get; set; }
    }

}
