//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessEntities
{
    using System;
    using System.Collections.Generic;
    
    public class personBankAccountEntities
    {
        public int ID { get; set; }
        public Nullable<int> IDV { get; set; }
        public string BankName { get; set; }
        public string BankNumber { get; set; }
        public string BankAccount { get; set; }
        public string BankNote { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<int> isDeleted { get; set; }
    
        public virtual personEntities person { get; set; }
    }
}
