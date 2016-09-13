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
    
    public partial class ras_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ras_Users()
        {
            this.ras_AttLeaveRecord = new HashSet<ras_AttLeaveRecord>();
            this.ras_AttResultRecord = new HashSet<ras_AttResultRecord>();
            this.ras_ShiftRecord = new HashSet<ras_ShiftRecord>();
            this.ras_UserDepts = new HashSet<ras_UserDepts>();
            this.ras_UserRoles = new HashSet<ras_UserRoles>();
        }
    
        public int UID { get; set; }
        public long DIN { get; set; }
        public string PIN { get; set; }
        public string UserName { get; set; }
        public string Sex { get; set; }
        public string Password { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public string DeptId { get; set; }
        public string AttId { get; set; }
        public string RuleId { get; set; }
        public string WeekendId { get; set; }
        public Nullable<int> LastUpdatedUID { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public string Comment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_AttLeaveRecord> ras_AttLeaveRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_AttResultRecord> ras_AttResultRecord { get; set; }
        public virtual ras_Dept ras_Dept { get; set; }
        public virtual ras_RuleList ras_RuleList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_ShiftRecord> ras_ShiftRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_UserDepts> ras_UserDepts { get; set; }
        public virtual ras_UserEx ras_UserEx { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_UserRoles> ras_UserRoles { get; set; }
        public virtual ras_Weekend ras_Weekend { get; set; }
    }
}
