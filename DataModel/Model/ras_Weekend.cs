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
    
    public partial class ras_Weekend
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ras_Weekend()
        {
            this.ras_Users = new HashSet<ras_Users>();
        }
    
        public int ID { get; set; }
        public string WeekendId { get; set; }
        public string WeekendName { get; set; }
        public Nullable<bool> MonAm { get; set; }
        public Nullable<bool> MonPm { get; set; }
        public Nullable<bool> TueAm { get; set; }
        public Nullable<bool> TuePm { get; set; }
        public Nullable<bool> WedAm { get; set; }
        public Nullable<bool> WedPm { get; set; }
        public Nullable<bool> ThurAm { get; set; }
        public Nullable<bool> ThurPm { get; set; }
        public Nullable<bool> FriAm { get; set; }
        public Nullable<bool> FriPm { get; set; }
        public Nullable<bool> SatAm { get; set; }
        public Nullable<bool> SatPm { get; set; }
        public Nullable<bool> SunAm { get; set; }
        public Nullable<bool> SunPm { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdatedUID { get; set; }
        public string Remark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ras_Users> ras_Users { get; set; }
    }
}
