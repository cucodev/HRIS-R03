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
    
    public partial class ras_RoleResources
    {
        public int RoleResourceId { get; set; }
        public int RoleId { get; set; }
        public int ResourceId { get; set; }
        public byte OperLevel { get; set; }
    
        public virtual ras_Resources ras_Resources { get; set; }
        public virtual ras_Roles ras_Roles { get; set; }
    }
}