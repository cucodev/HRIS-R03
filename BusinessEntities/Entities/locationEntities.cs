using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Entities
{
    public class locationEntities
    {
        public long codeNum { get; set; }
        public Nullable<long> codeNumParent { get; set; }
        public string codeISOParent { get; set; }
        public string codeISO { get; set; }
        public string codeUN { get; set; }
        public string dialingCode { get; set; }
        public string locationName { get; set; }

        public virtual categoryEntities category { get; set; }
    }
}
