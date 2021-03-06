﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
   
    //define each employee rolebase
    public class employeeRoleBasedEntities
    {
        public int ID { get; set; }
        public int IDV { get; set; }
        public Nullable<int> serviceYears { get; set; }
        public Nullable<int> serviceDays { get; set; }
        public int policyType { get; set; }
        public int valueType { get; set; }
        public Nullable<int> roleBasedValue { get; set; }
        public Nullable<int> currentValue { get; set; }
        public Nullable<int> balanceValue { get; set; }
        public Nullable<int> remainingValue { get; set; }
        public Nullable<System.DateTime> validDateStart { get; set; }
        public Nullable<System.DateTime> validDateStop { get; set; }
        public string decription { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }

        
    }

    public class employeeStructure
    {
        public int ID { get; set; }
        public int IDV { get; set; }
        public string NIP { get; set; }
        public string IDVName { get; set; }
        public string IDVImagePath { get; set; }
        public int parentIDV { get; set; }
        public string parentName { get; set; }
    }

    public partial class employeeDetail
    {
        public int ID { get; set; }
        public Nullable<int> IDV { get; set; }
        public string NIP { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Nationality { get; set; }
        public string Birthplace { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public string Marital { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public string vCreatedBy { get; set; }
        public string vUpdatedBy { get; set; }
        public Nullable<int> isDeleted { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    }

    public class employeeLeaveEntities
    {
        //null
    }

    public class employeeApprovalEntities
    {
        //null
    }

}
