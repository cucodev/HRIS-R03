using BusinessEntities.CrudEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessEntities
{
    

    public static class  GlobalVariable
    {
        public const string UserCred = "UserCred";


        public const string pathImage = "\\\\HLSCP\\\\sqlserver\\\\HRIS\\\\personImage\\\\";
        public const string pathImageURL = "\\\\HLSCP\\sqlserver\\HRIS\\personImage\\";
        public const string fileWebTempImage = "~/Content/photo/temp/person.png";
        public const string pathWebImage = "~/Content/photo";

        //Purpose
        public const string purposeLeave = "txLeave";

        //General
        public const string lov_valueType = "valueType";
        public const string lov_relationTypeFamily = "relationFamily";


        //Category Medical & Leave
        public const string policyType = "policyType";
        public const string policyTypeRoot = "policyTypeRoot";
        public const string policyTypeAnnual = "policyTypeAnnual";
        public const string policyTypeLeave = "policyTypeLeave";
        public const string policyTypeMedical = "policyTypeMedical";

        //Employee Level
        public const string lov_level = "empLevel";
        public const string lov_levelRoot = "empLevelRoot";

        public const string lov_skillLevel = "pSkillLevel";
        public const string lov_marital = "pMarital";
        public const string lov_gender = "pGender";
        public const string lov_religion = "pReligion";
        public const string lov_ID = "pID";
        public const string lov_employeeStatus = "empStatus";
        public const string lov_country = "pCountry";
        public const string lov_province = "pProv";
        public const string lov_kabupaten = "pKab";
        public const string lov_kecamatan = "pKec";
        public const string lov_relationType = "pRelType";
        public const string lov_orgDivision = "empDiv";
        public const string lov_orgDepartemen = "empDep";
        public const string lov_orgPosition = "empPos";
        public const string lov_edu = "pEdu";
    }

    public static class UserVariable
    {
        static UserCredModel _User;

        public static UserCredModel User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
            }
        }
    }
   
}
