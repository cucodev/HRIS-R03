using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessEntities.CrudEntities
{
    public class fileEntities
    {
        [Key]
        public Guid stream_id { get; set; }
        public byte[] file_stream { get; set; }
        public string name { get; set; }
        public string path_locator { get; set; }
        public string parent_path_locator { get; set; }
        public string file_type { get; set; }
        public double cached_file_size { get; set; }
        public DateTimeOffset creation_time { get; set; }
        public DateTimeOffset last_write_time { get; set; }
        public DateTimeOffset last_access_time { get; set; }
        public bool is_directory { get; set; }
        public bool is_offline { get; set; }
        public bool is_hidden { get; set; }
        public bool is_readonly { get; set; }
        public bool is_archive { get; set; }
        public bool is_system { get; set; }
        public bool is_temporary { get; set; }
    }

    public class FileSummaryEntities
    {
        public List<string> fileName { get; set; }
        public List<string> name { get; set; }
        public List<string> fileType { get; set; }
        public string Description { get; set; }
        public DateTime createTime { get; set; }
        public int vCreatedBy { get; set; }
    }

    public class FileViewModel
    {
        public string Title { get; set; }
        public HttpPostedFileBase File { get; set; }
    }

    public class FileResultEntities
    {
        public List<string> FileNames { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public List<string> ContentTypes { get; set; }
        public List<string> Names { get; set; }
    }


    public class dataFileEntities
    {
        public int ID { get; set; }
        public string stream_id { get; set; }
        public string name { get; set; }
        public string path_locator { get; set; }
        public string parent_path_locator { get; set; }
        public string file_type { get; set; }
        public Nullable<int> cached_file_size { get; set; }
        public Nullable<System.DateTimeOffset> creation_time { get; set; }
        public Nullable<System.DateTimeOffset> last_write_time { get; set; }
        public Nullable<System.DateTimeOffset> last_access_time { get; set; }
        public Nullable<bool> is_directory { get; set; }
        public Nullable<bool> is_offline { get; set; }
        public Nullable<bool> is_hidden { get; set; }
        public Nullable<bool> is_readonly { get; set; }
        public Nullable<bool> is_archieve { get; set; }
        public Nullable<bool> is_system { get; set; }
        public Nullable<bool> is_temporary { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdateBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
        public Nullable<int> isDeleted { get; set; }
    }
}
