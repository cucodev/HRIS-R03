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
    
    public partial class C_transaction
    {
        public int txID { get; set; }
        public Nullable<int> purposeID { get; set; }
        public Nullable<int> purposeStatus { get; set; }
        public Nullable<int> idvRequest { get; set; }
        public Nullable<int> idvApproval { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdateBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    
        public virtual C_purpose C_purpose { get; set; }
    }
}
