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
    
    public partial class personEdu
    {
        public int ID { get; set; }
        public Nullable<int> IDV { get; set; }
        public Nullable<int> eduLevel { get; set; }
        public string eduMajor { get; set; }
        public Nullable<System.DateTime> eduGraduate { get; set; }
        public Nullable<double> eduValue { get; set; }
        public Nullable<int> eduCountry { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<int> isDeleted { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    
        public virtual person person { get; set; }
    }
}