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
    
    public partial class ras_Rule
    {
        public int ID { get; set; }
        public string RuleId { get; set; }
        public string Item { get; set; }
        public string ItemValue { get; set; }
        public bool IsValid { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdatedUID { get; set; }
    
        public virtual ras_RuleList ras_RuleList { get; set; }
    }
}
