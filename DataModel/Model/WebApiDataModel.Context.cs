﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C_purpose> C_purpose { get; set; }
        public virtual DbSet<C_transaction> C_transaction { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<categoryParent> categoryParents { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<employeeRoleBased> employeeRoleBaseds { get; set; }
        public virtual DbSet<file> files { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<organization> organizations { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<personAddress> personAddresses { get; set; }
        public virtual DbSet<personBankAccount> personBankAccounts { get; set; }
        public virtual DbSet<personCertification> personCertifications { get; set; }
        public virtual DbSet<personContact> personContacts { get; set; }
        public virtual DbSet<personDependent> personDependents { get; set; }
        public virtual DbSet<personDetail> personDetails { get; set; }
        public virtual DbSet<personEdu> personEdus { get; set; }
        public virtual DbSet<personEmergency> personEmergencies { get; set; }
        public virtual DbSet<personIdentity> personIdentities { get; set; }
        public virtual DbSet<personJob> personJobs { get; set; }
        public virtual DbSet<personLanguage> personLanguages { get; set; }
        public virtual DbSet<personSkill> personSkills { get; set; }
        public virtual DbSet<personTraining> personTrainings { get; set; }
        public virtual DbSet<personWorkExperience> personWorkExperiences { get; set; }
        public virtual DbSet<roleBased> roleBaseds { get; set; }
        public virtual DbSet<roleBasedMatrix> roleBasedMatrices { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<dataLeave> dataLeaves { get; set; }
        public virtual DbSet<dataMail> dataMails { get; set; }
        public virtual DbSet<dataFile> dataFiles { get; set; }
        public virtual DbSet<holiday> holidays { get; set; }
        public virtual DbSet<setting> settings { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<personMap> personMaps { get; set; }
    }
}
