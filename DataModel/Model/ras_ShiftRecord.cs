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
    
    public partial class ras_ShiftRecord
    {
        public int ID { get; set; }
        public int UID { get; set; }
        public System.DateTime DutyDay { get; set; }
        public string ShiftId { get; set; }
        public Nullable<int> CreateUID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdatedUID { get; set; }
    
        public virtual ras_Users ras_Users { get; set; }
    }
}
