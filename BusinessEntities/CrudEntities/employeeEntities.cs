using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    public class employeeEntities
    {
    }


    //define each employee rolebase
    public class employeeRoleBasedEntities
    {
        public int IDV { get; set; }
        public Nullable<int> catCode { get; set; }
        public Nullable<int> valueType { get; set; }
        public string value { get; set; }
        public string balance { get; set; }
    }



}
