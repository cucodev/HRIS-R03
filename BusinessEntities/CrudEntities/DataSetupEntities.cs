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

}
