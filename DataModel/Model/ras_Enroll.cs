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
    
    public partial class ras_Enroll
    {
        public int ID { get; set; }
        public long DIN { get; set; }
        public byte BackupNumber { get; set; }
        public Nullable<byte> Privilege { get; set; }
        public string Password { get; set; }
        public string Fingerprint { get; set; }
        public Nullable<bool> Enable { get; set; }
        public Nullable<byte> AccessTimeZone { get; set; }
        public System.DateTime ValidDate { get; set; }
        public System.DateTime InvalidDate { get; set; }
        public Nullable<byte> UnlockGroup { get; set; }
    }
}
