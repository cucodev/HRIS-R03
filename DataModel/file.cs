//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class file
    {
        public int fileID { get; set; }
        public string fileName { get; set; }
        public string fileDescription { get; set; }
        public Nullable<System.DateTime> fileUploadTime { get; set; }
        public string ContentType { get; set; }
        public Nullable<int> IDV { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<int> isDeleted { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    
        public virtual person person { get; set; }
    }
}
