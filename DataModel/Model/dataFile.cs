//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class dataFile
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
