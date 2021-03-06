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
    
    public partial class ras_AccessControlSettings
    {
        public int ID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> Wiegand { get; set; }
        public Nullable<int> FireAlarm { get; set; }
        public Nullable<int> Lock2Control { get; set; }
        public Nullable<int> Lock1OpenDelay { get; set; }
        public Nullable<int> CheckDoor1Status { get; set; }
        public Nullable<int> Lock1OpenOvertimeAlarm { get; set; }
        public Nullable<int> Lock1IllegalOpenAlarm { get; set; }
        public Nullable<int> Lock2OpenDelay { get; set; }
        public Nullable<int> CheckDoor2Status { get; set; }
        public Nullable<int> Lock2OpenOvertimeAlarm { get; set; }
        public Nullable<int> Lock2IllegalOpenAlarm { get; set; }
        public Nullable<int> Unlock1PassGroup { get; set; }
        public Nullable<int> Unlock2PassGroup { get; set; }
        public Nullable<int> EnableAntiHijack { get; set; }
        public Nullable<int> HijackOpen { get; set; }
        public Nullable<int> HijackAlarm { get; set; }
        public string HijackPassword { get; set; }
        public Nullable<int> HijackFpNo { get; set; }
        public Nullable<int> AntiPassback { get; set; }
        public Nullable<int> MultOpen { get; set; }
        public Nullable<int> LinkageOpen { get; set; }
        public Nullable<int> LinkageAlarm { get; set; }
        public Nullable<int> EnableRelayAlarm { get; set; }
        public Nullable<int> VerifyMode { get; set; }
        public Nullable<int> Res1 { get; set; }
        public Nullable<int> Res2 { get; set; }
    }
}
