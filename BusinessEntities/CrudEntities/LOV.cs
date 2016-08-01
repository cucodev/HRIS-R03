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

    public class LOVFile
    {
        public string value { get; set; }
        public string label { get; set; }
        public string url { get; set; }
    }

    public class LOVFileTree
    {
        public string path_locator { get; set; }
        public string parent_path_locator { get; set; }
        public string name { get; set; }
        public string stream_id { get; set; }
        public string url { get; set; }
    }

    public class LOVLocation
    {
        public long value { get; set; }
        public string label { get; set; }

        public virtual IEnumerable<LOV> child { get; set; }
    }

    public class LOVTree
    {
        public int id { get; set; }
        public int parentid { get; set; }
        public string text { get; set; }
        public int value { get; set; }
    }


    public class DynamicColumn
    {
        public string text { get; set; }
        public int datafield { get; set; }
        public int width { get; set; }
    }

    public class DynamicDatafield
    {
        public string name { get; set; }
        public string type { get; set; }
        public string value { get; set; }

        public virtual IEnumerable<LOV> values { get; set; }
    }



}
