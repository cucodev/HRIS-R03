using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.CrudEntities
{
    public class profileEntities
    {
        //Global mostly same on all table
        public int IDV { get; set; }
        public Nullable<int> OrganizationID { get; set; }

        //All Table
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<int> isDeleted { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }

        //personDetailEntities
        public int personDetailID { get; set; }
        public string NIP { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public Nullable<int> Nationality { get; set; }
        public string Birthplace { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<int> Marital { get; set; }
        public Nullable<int> Religion { get; set; }
        public Nullable<int> Gender { get; set; }

        //employee
        public int employeeID { get; set; }
        public Nullable<int> UID_ABSENCE { get; set; }
        public Nullable<int> employmentStatus { get; set; }
        public Nullable<System.DateTime> joinDate { get; set; }
        public Nullable<System.DateTime> resignDate { get; set; }
        public Nullable<System.DateTime> contract1Start { get; set; }
        public Nullable<System.DateTime> contract1End { get; set; }
        public Nullable<System.DateTime> contract2Start { get; set; }
        public Nullable<System.DateTime> contract2End { get; set; }
        public Nullable<System.DateTime> contract3Start { get; set; }
        public Nullable<System.DateTime> contract3End { get; set; }
        public Nullable<int> active { get; set; }

        //personJob
        public int personJobID { get; set; }
        public Nullable<int> parentIDV { get; set; }
        public string jobName { get; set; }
        public Nullable<int> JobDivision { get; set; }
        public Nullable<int> JobDepartement { get; set; }
        public Nullable<int> JobPosition { get; set; }
        public Nullable<int> JobLevel { get; set; }
        public string JobLocation { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public string Note { get; set; }


        //personEdu
        public int personEduID { get; set; }
        public Nullable<int> eduLevel { get; set; }
        public string eduMajor { get; set; }
        public Nullable<System.DateTime> eduGraduate { get; set; }
        public Nullable<double> eduValue { get; set; }
        public Nullable<int> eduCountry { get; set; }

        //personWorkExperiences
        public int personWorkExperienceID { get; set; }
        public string companyName { get; set; }
        public string lastPosition { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> Stop { get; set; }
        public string reason { get; set; }

        //personLanguage
        public int personLanguageID { get; set; }
        public string languageName { get; set; }
        public Nullable<int> spoken { get; set; }
        public Nullable<int> written { get; set; }

        //personSkill
        public int personSkillID { get; set; }
        public string skillName { get; set; }
        public Nullable<int> skillLevel { get; set; }

        //personCertification
        public int personCertificationID { get; set; }
        public string certificationName { get; set; }
        public Nullable<int> issuedCountry { get; set; }
        public Nullable<int> issuedCity { get; set; }
        public Nullable<System.DateTime> issuedDate { get; set; }
        public Nullable<System.DateTime> issuedExpiredDate { get; set; }

        //personTraining
        public int personTrainingID { get; set; }
        public string TrainingName { get; set; }
        public string TrainingSponsor { get; set; }
        public Nullable<int> TrainingCertificate { get; set; }
        public Nullable<System.DateTime> TrainingStartDate { get; set; }
        public Nullable<System.DateTime> TrainingEndDate { get; set; }

        //personIdentity
        public virtual ICollection<personIdentityEntities> personIdentities { get; set; }

        //personDependant
        public virtual ICollection<personDependentEntities> personDependent { get; set; }
        





    }

    public class profileDependentEntities
    {

    }

}
