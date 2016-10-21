using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    public class AnnualLeave
    {
        public int ID { get; set; }
        public int policyType { get; set; }
        public bool isCarryOver { get; set; }
        public Nullable<int> roleBasedValue { get; set; }
        public Nullable<int> currentValue { get; set; }
        public Nullable<int> balanceValue { get; set; }
        public Nullable<System.DateTime> validDateStart { get; set; }
        public Nullable<System.DateTime> validDateStop { get; set; }
    }

    public class Annual
    {
        public int IDV { get; set; }
        public int Years { get; set; }
        public int IDVSuperior { get; set; }
        public string SuperiorName { get; set; }
        public virtual ICollection<AnnualLeave> AnnualData { get; set; }
    }
}
