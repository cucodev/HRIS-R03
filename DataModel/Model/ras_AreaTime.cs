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
    
    public partial class ras_AreaTime
    {
        public byte ID { get; set; }
        public short DN { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> Sunday { get; set; }
        public Nullable<int> Monday { get; set; }
        public Nullable<int> Tuesday { get; set; }
        public Nullable<int> Wednesday { get; set; }
        public Nullable<int> Thursday { get; set; }
        public Nullable<int> Friday { get; set; }
        public Nullable<int> Saturday { get; set; }
        public string Remark { get; set; }
    }
}