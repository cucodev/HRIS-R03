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
    
    public partial class dataMail
    {
        public int ID { get; set; }
        public Nullable<int> txID { get; set; }
        public Nullable<int> emailStatus { get; set; }
        public Nullable<int> emailRequest { get; set; }
        public Nullable<int> emailApproval { get; set; }
        public Nullable<int> emailSendingCount { get; set; }
        public Nullable<int> isDeleted { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    }
}
