using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    public class SettingEntities
    { 
        public int id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string value { get; set; }
        public int vUpdatedBy { get; set; }
        public System.DateTime updateTime { get; set; }
    }
}
