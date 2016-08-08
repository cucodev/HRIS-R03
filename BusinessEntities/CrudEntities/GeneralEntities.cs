using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    public class generalEntities
    {
    }

    public class classificationEntities
    {
        public int catID { get; set; }
        public Nullable<int> catParentID { get; set; }
        public string catCode { get; set; }
        public string catName { get; set; }

        public virtual classificationEntities category { get; set; }
        public virtual ICollection<categoryEntities> categories { get; set; }
    }

    public class categoryEntities
    {
        public int catID { get; set; }
        public Nullable<int> catParentID { get; set; }
        public string catCode { get; set; }
        public string catName { get; set; }
    }


}
