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
    
    public partial class ras_Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ras_Roles()
        {
            this.ras_RoleResources = new HashSet<ras_RoleResources>();
            this.ras_UserRoles = new HashSet<ras_UserRoles>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Remark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_RoleResources> ras_RoleResources { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_UserRoles> ras_UserRoles { get; set; }
    }
}
