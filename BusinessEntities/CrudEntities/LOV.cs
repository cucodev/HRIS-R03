using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    public class LOV
    {
        public int value { get; set; }
        public string label { get; set; }

        public virtual IEnumerable<LOV> child { get; set; }
    }
}
