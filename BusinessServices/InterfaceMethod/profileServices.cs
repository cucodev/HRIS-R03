using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using AutoMapper;
using BusinessServices.Interface;
using BusinessEntities.CrudEntities;
using System.Transactions;

namespace BusinessServices.InterfaceMethod
{
    public class ProfileServices : Iprofile
    {
        private readonly UnitOfWork _unitOfWork;
        private int isDelete = 0; // 0 means row is active, not in deleted status

        public ProfileServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<profileEntities> GetAllOrgProfiles(int OrgID)
        {
            //throw new NotImplementedException();
            List<profileEntities> ms = new List<profileEntities>();
            var vperson = _unitOfWork.personRepository.GetMany(b=> b.OrganizationID == OrgID && b.isDeleted == isDelete);//.GetAll().ToList();

            if (vperson.Any())
            {
                foreach (person n in vperson)
                {
                    profileEntities x = new profileEntities();

                    //person
                    x.IDV = n.IDV;
                    x.OrganizationID = n.OrganizationID;
                    x.isDeleted = n.isDeleted;
                    x.vCreatedBy = n.vCreatedBy;
                    x.vUpdatedBy = n.vUpdatedBy;

                    //employee
                    var vemployee = _unitOfWork.employeeRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (employee nn in vemployee)
                    {
                        x.employeeID = nn.ID;
                        x.UID_ABSENCE = nn.UID_ABSENCE;
                        x.joinDate = nn.joinDate;
                        x.resignDate = nn.resignDate;
                        x.contract1Start = nn.contract1Start;
                        x.contract1End = nn.contract1End;
                        x.contract2Start = nn.contract2Start;
                        x.contract2End = nn.contract2End;
                        x.contract3Start = nn.contract3Start;
                        x.contract3End = nn.contract3End;
                        x.active = nn.active;
                        x.employmentStatus = nn.employmentStatus;
                    }

                    //personDetail
                    var vpersonDetail = _unitOfWork.personDetailRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personDetail nn in vpersonDetail)
                    {
                        x.personDetailID = nn.ID; 
                        x.NIP = nn.NIP;
                        x.Name = nn.Name;
                        x.NickName = nn.NickName;
                        x.Nationality = nn.Nationality;
                        x.Birthplace = nn.Birthplace;
                        x.Birthdate = nn.Birthdate;
                        x.Marital = nn.Marital;
                        x.Religion = nn.Religion;
                        x.Gender = nn.Gender;

                    }

                    //personJob
                    var vpersonJob = _unitOfWork.personJobRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personJob nn in vpersonJob)
                    {
                        x.personJobID = nn.ID;
                        x.parentIDV = nn.parentIDV;
                        x.jobName = nn.jobName;
                        x.JobPosition = nn.JobPosition;
                        x.JobDepartement = nn.JobDepartement;
                        x.JobDivision = nn.JobDivision;
                        x.JobLocation = nn.JobLocation;
                        x.startDate = nn.startDate;
                        x.endDate = nn.endDate;
                    }

                    //personEdu
                    var vpersonEdu = _unitOfWork.personEduRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personEdu nn in vpersonEdu)
                    {
                        x.personEduID = nn.ID;
                        x.eduLevel = nn.eduLevel;
                        x.eduMajor = nn.eduMajor;
                        x.eduGraduate = nn.eduGraduate;
                        x.eduValue = nn.eduValue;
                        x.eduCountry = nn.eduCountry;
                    }


                    //personWorkExperience
                    var vpersonWorkExperiences = _unitOfWork.personWorkExperienceRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personWorkExperience nnn in vpersonWorkExperiences)
                    {
                        x.personWorkExperienceID = nnn.ID;
                        x.companyName = nnn.companyName;
                        x.lastPosition = nnn.lastPosition;
                        x.Start = nnn.Start;
                        x.Stop = nnn.Stop;
                    }


                    //personLanguage
                    var vpersonLang = _unitOfWork.personLanguageRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personLanguage nnn in vpersonLang)
                    {
                        x.personLanguageID = nnn.ID;
                        x.languageName = nnn.languageName;
                        x.spoken = nnn.spoken;
                        x.written = nnn.written;
                    }

                    //personSkill
                    var vpersonSkill = _unitOfWork.personSkillRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personSkill nnn in vpersonSkill)
                    {
                        x.personSkillID = nnn.ID;
                        x.skillName = nnn.skillName;
                        x.skillLevel = nnn.skillLevel;
                    }

                    //personCertificate
                    var vpersonCert = _unitOfWork.personCertificationRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personCertification nnn in vpersonCert)
                    {
                        x.personCertificationID = nnn.ID;
                        x.certificationName = nnn.certificationName;
                        x.issuedCountry = nnn.issuedCountry;
                        x.issuedCity = nnn.issuedCity;
                        x.issuedDate = nnn.issuedDate;
                        x.issuedExpiredDate = nnn.issuedExpiredDate;
                    }

                    //personTraining
                    var vpersonTraining = _unitOfWork.personTrainingRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personTraining nnn in vpersonTraining)
                    {
                        x.personTrainingID = nnn.ID;
                        x.TrainingName = nnn.TrainingName;
                        x.TrainingSponsor = nnn.TrainingSponsor;
                        x.TrainingCertificate = nnn.Certificate;
                        x.TrainingStartDate = nnn.startDate;
                        x.TrainingEndDate = nnn.endDate;
                    }


                    //personDependant
                    var vpersonDependent = _unitOfWork.personDependentRepository.GetMany(b => b.IDVDependent == n.IDV && b.isDeleted == isDelete);
                    List<personDependentEntities> PI = new List<personDependentEntities>();
                    foreach (personDependent nnn in vpersonDependent)
                    {
                        personDependentEntities pIX = new personDependentEntities();
                        pIX.IDV = nnn.IDV;
                        pIX.relationType = nnn.relationType;
                        pIX.insuranceCovered = nnn.insuranceCovered;
                        pIX.taxDependent = nnn.taxDependent;
                        PI.Add(pIX);
                    }
                    x.personDependent = PI;

                    //personIdentity
                    var vpersonIdentity = _unitOfWork.personIdentityRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    List<personIdentityEntities> pI = new List<personIdentityEntities>();
                    foreach (personIdentity nnn in vpersonIdentity)
                    {
                        personIdentityEntities pIX = new personIdentityEntities();
                        pIX.ID = nnn.ID;
                        pIX.IDV = nnn.IDV;
                        pIX.idType = nnn.idType;
                        pIX.idNumber = nnn.idNumber;
                        pIX.issuedCountry = nnn.issuedCountry;
                        pIX.expiredDate = nnn.expiredDate;
                        pIX.isDeleted = nnn.isDeleted;
                        pIX.vCreatedBy = nnn.vCreatedBy;
                        pIX.vUpdatedBy = nnn.vUpdatedBy;
                        pI.Add(pIX);
                    }
                    x.personIdentities = pI;
                    ms.Add(x);
                }
                return ms.AsEnumerable();
            }
            return null;
        }

        public IEnumerable<profileEntities> GetAllProfiles()
        {
            //throw new NotImplementedException();
            List<profileEntities> ms = new List<profileEntities>();
            var vperson = _unitOfWork.personRepository.GetAll().ToList();
           
            if (vperson.Any())
            {
                foreach (person n in vperson)
                {
                    var vpersonDetail = _unitOfWork.personDetailRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    var vpersonIdentity = _unitOfWork.personIdentityRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    var vemployee = _unitOfWork.employeeRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    profileEntities x = new profileEntities();
                    x.IDV = n.IDV;
                    x.OrganizationID = n.OrganizationID;
                    x.isDeleted = n.isDeleted;
                    x.vCreatedBy = n.vCreatedBy;
                    x.vUpdatedBy = n.vUpdatedBy;

                    foreach (personDetail nn in vpersonDetail)
                    {
                        x.personDetailID = nn.ID;
                        x.NIP = nn.NIP;
                        x.Name = nn.Name;
                        x.NickName = nn.NickName;
                        x.Nationality = nn.Nationality;
                        x.Birthplace = nn.Birthplace;
                        x.Birthdate = nn.Birthdate;
                        x.Marital = nn.Marital;
                        x.Religion = nn.Religion;
                        x.Gender = nn.Gender;

                    }

                    List<personIdentityEntities> pI = new List<personIdentityEntities>();              
                    foreach (personIdentity nnn in vpersonIdentity)
                    {
                        personIdentityEntities pIX = new personIdentityEntities();
                        pIX.ID = nnn.ID;
                        pIX.IDV = nnn.IDV;
                        pIX.idType = nnn.idType;
                        pIX.idNumber = nnn.idNumber;
                        pIX.issuedCountry = nnn.issuedCountry;
                        pIX.expiredDate = nnn.expiredDate;
                        pIX.isDeleted = nnn.isDeleted;
                        pIX.vCreatedBy = nnn.vCreatedBy;
                        pIX.vUpdatedBy = nnn.vUpdatedBy;
                        pI.Add(pIX);
                    }
                    x.personIdentities = pI;

                    



                    ms.Add(x);
                }
                return ms.AsEnumerable();
            }
            return null;
        }

        public int CreateProfile(profileEntities personEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProfile(int personIDV, int vUpdatedBy)
        {
            throw new NotImplementedException();
        }
  
        public profileEntities GetProfileById(int personIDV)
        {
            //throw new NotImplementedException();
            
            profileEntities ms = new profileEntities();
            var vperson = _unitOfWork.personRepository.GetMany(b => b.IDV == personIDV).ToList();//.GetAll().ToList();
            System.Diagnostics.Debug.WriteLine("personIDV: " + personIDV);
            if (vperson.Any())
            {
                profileEntities x = new profileEntities();
                foreach (person n in vperson)
                {          
                    System.Diagnostics.Debug.WriteLine("person: " + n.IDV);
                    //person
                    x.IDV = n.IDV;
                    x.OrganizationID = n.OrganizationID;
                    x.isDeleted = n.isDeleted;
                    x.vCreatedBy = n.vCreatedBy;
                    x.vUpdatedBy = n.vUpdatedBy;

                    //employee
                    var vemployee = _unitOfWork.employeeRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (employee nn in vemployee)
                    {
                        x.employeeID = nn.ID;
                        x.UID_ABSENCE = nn.UID_ABSENCE;
                        x.joinDate = nn.joinDate;
                        x.resignDate = nn.resignDate;
                        x.contract1Start = nn.contract1Start;
                        x.contract1End = nn.contract1End;
                        x.contract2Start = nn.contract2Start;
                        x.contract2End = nn.contract2End;
                        x.contract3Start = nn.contract3Start;
                        x.contract3End = nn.contract3End;
                        x.active = nn.active;
                        x.employmentStatus = nn.employmentStatus;
                    }

                    //personDetail
                    var vpersonDetail = _unitOfWork.personDetailRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personDetail nn in vpersonDetail)
                    {
                        x.personDetailID = nn.ID;
                        x.NIP = nn.NIP;
                        x.Name = nn.Name;
                        x.NickName = nn.NickName;
                        x.Nationality = nn.Nationality;
                        x.Birthplace = nn.Birthplace;
                        x.Birthdate = nn.Birthdate;
                        x.Marital = nn.Marital;
                        x.Religion = nn.Religion;
                        x.Gender = nn.Gender;

                    }

                    //personJob
                    var vpersonJob = _unitOfWork.personJobRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personJob nn in vpersonJob)
                    {
                        x.personJobID = nn.ID;
                        x.parentIDV = nn.parentIDV;
                        x.jobName = nn.jobName;
                        x.JobPosition = nn.JobPosition;
                        x.JobDepartement = nn.JobDepartement;
                        x.JobDivision = nn.JobDivision;
                        x.JobLocation = nn.JobLocation;
                        x.startDate = nn.startDate;
                        x.endDate = nn.endDate;
                    }

                    //personEdu
                    var vpersonEdu = _unitOfWork.personEduRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personEdu nn in vpersonEdu)
                    {
                        x.personEduID = nn.ID;
                        x.eduLevel = nn.eduLevel;
                        x.eduMajor = nn.eduMajor;
                        x.eduGraduate = nn.eduGraduate;
                        x.eduValue = nn.eduValue;
                        x.eduCountry = nn.eduCountry;
                    }


                    //personWorkExperience
                    var vpersonWorkExperiences = _unitOfWork.personWorkExperienceRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personWorkExperience nnn in vpersonWorkExperiences)
                    {
                        x.personWorkExperienceID = nnn.ID;
                        x.companyName = nnn.companyName;
                        x.lastPosition = nnn.lastPosition;
                        x.Start = nnn.Start;
                        x.Stop = nnn.Stop;
                    }


                    //personLanguage
                    var vpersonLang = _unitOfWork.personLanguageRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personLanguage nnn in vpersonLang)
                    {
                        x.personLanguageID = nnn.ID;
                        x.languageName = nnn.languageName;
                        x.spoken = nnn.spoken;
                        x.written = nnn.written;
                    }

                    //personSkill
                    var vpersonSkill = _unitOfWork.personSkillRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personSkill nnn in vpersonSkill)
                    {
                        x.personSkillID = nnn.ID;
                        x.skillName = nnn.skillName;
                        x.skillLevel = nnn.skillLevel;
                    }

                    //personCertificate
                    var vpersonCert = _unitOfWork.personCertificationRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personCertification nnn in vpersonCert)
                    {
                        x.personCertificationID = nnn.ID;
                        x.certificationName = nnn.certificationName;
                        x.issuedCountry = nnn.issuedCountry;
                        x.issuedCity = nnn.issuedCity;
                        x.issuedDate = nnn.issuedDate;
                        x.issuedExpiredDate = nnn.issuedExpiredDate;
                    }

                    //personTraining
                    var vpersonTraining = _unitOfWork.personTrainingRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    foreach (personTraining nnn in vpersonTraining)
                    {
                        x.personTrainingID = nnn.ID;
                        x.TrainingName = nnn.TrainingName;
                        x.TrainingSponsor = nnn.TrainingSponsor;
                        x.TrainingCertificate = nnn.Certificate;
                        x.TrainingStartDate = nnn.startDate;
                        x.TrainingEndDate = nnn.endDate;
                    }


                    //personDependant
                    var vpersonDependent = _unitOfWork.personDependentRepository.GetMany(b => b.IDVDependent == n.IDV && b.isDeleted == isDelete);
                    List<personDependentEntities> PI = new List<personDependentEntities>();
                    foreach (personDependent nnn in vpersonDependent)
                    {
                        personDependentEntities pIX = new personDependentEntities();
                        pIX.IDV = nnn.IDV;
                        pIX.relationType = nnn.relationType;
                        pIX.insuranceCovered = nnn.insuranceCovered;
                        pIX.taxDependent = nnn.taxDependent;
                        PI.Add(pIX);
                    }
                    x.personDependent = PI;

                    //personIdentity
                    var vpersonIdentity = _unitOfWork.personIdentityRepository.GetMany(b => b.IDV == n.IDV && b.isDeleted == isDelete);
                    List<personIdentityEntities> pI = new List<personIdentityEntities>();
                    foreach (personIdentity nnn in vpersonIdentity)
                    {
                        personIdentityEntities pIX = new personIdentityEntities();
                        pIX.ID = nnn.ID;
                        pIX.IDV = nnn.IDV;
                        pIX.idType = nnn.idType;
                        pIX.idNumber = nnn.idNumber;
                        pIX.issuedCountry = nnn.issuedCountry;
                        pIX.expiredDate = nnn.expiredDate;
                        pIX.isDeleted = nnn.isDeleted;
                        pIX.vCreatedBy = nnn.vCreatedBy;
                        pIX.vUpdatedBy = nnn.vUpdatedBy;
                        pI.Add(pIX);
                    }
                    x.personIdentities = pI;
                    //ms.Add(x);
                }
                return x;
            }
            return null;
        }

        public bool UpdateProfile(int personID, profileEntities p)
        {
            var res = false;
            List<profileEntities> ms = new List<profileEntities>();
            System.Diagnostics.Debug.WriteLine("profileEntities:", p);
            if (p != null )
            {
                using (var scope = new TransactionScope())
                {
                    #region person
                    var Eperson = _unitOfWork.personRepository.GetByID(personID);
                    if (Eperson != null)
                    {
                        Eperson.OrganizationID = p.OrganizationID;
                        Eperson.isDeleted = p.isDeleted;
                        Eperson.updateTime = DateTime.Now;
                        Eperson.vUpdatedBy = p.vUpdatedBy;
                        try
                        {
                            _unitOfWork.personRepository.Update(Eperson);
                            _unitOfWork.Save();
                        } catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Error while Save to personRepository", e.Message);
                        }
                       
                    }
                    #endregion

                    #region  Update necessary row only to selected ID in personDetail
                    UnitOfWork _unitOfWork1 = new UnitOfWork();
                    var rpDetail = _unitOfWork1.personDetailRepository.GetByID(p.personDetailID);
                    if (rpDetail != null)
                    {
                        rpDetail.isDeleted = 1;
                        rpDetail.vUpdatedBy = p.vUpdatedBy;
                        rpDetail.updateTime = DateTime.Now;
                        try
                        {
                            _unitOfWork1.personDetailRepository.Update(rpDetail);
                            _unitOfWork1.Save();
                            System.Diagnostics.Debug.WriteLine("Save to personDetailRepository");
                        } catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Error while Save to personDetailRepository : ", e.Message);
                        }


                        #region new row personDetail 
                        UnitOfWork _unitOfWork2 = new UnitOfWork();

                        //Create New Row on personDetail
                        var pDetail = new personDetail();
                        pDetail.IDV = p.IDV;
                        pDetail.NIP = p.NIP;
                        pDetail.Name = p.Name;
                        pDetail.NickName = p.NickName;
                        pDetail.Nationality = p.Nationality;
                        pDetail.Birthplace = p.Birthplace;
                        pDetail.Birthdate = p.Birthdate;
                        pDetail.Marital = p.Marital;
                        pDetail.Religion = p.Religion;
                        pDetail.Gender = p.Gender;
                        pDetail.createTime = DateTime.Now;
                        pDetail.vCreatedBy = p.vCreatedBy;
                        pDetail.isDeleted = 0;
                        try
                        {
                            _unitOfWork2.personDetailRepository.Insert(pDetail);
                            _unitOfWork2.Save();
                            System.Diagnostics.Debug.WriteLine("Save to personIdentityRepository");
                        } catch (Exception e)
                        {
                            //System.Diagnostics.Debug.WriteLine("profileServices: ", pDetail, ':', p);
                            System.Diagnostics.Debug.WriteLine("Error while Save to personDetailRepository: ", e.Message);
                        }
                        #endregion




                    }
                    #endregion


                    /*
                    #region Update necessary row only to selected ID in personIdentity
                    UnitOfWork _unitOfWork3 = new UnitOfWork();
                    var rpIdentity = _unitOfWork3.personIdentityRepository.GetByID(p.personIdentityID);
                    if (rpIdentity != null)
                    {
                        rpIdentity.isDeleted = 1;
                        rpIdentity.vUpdatedBy = p.vUpdatedBy;
                        _unitOfWork3.personIdentityRepository.Update(rpIdentity);
                        _unitOfWork3.Save();

                        UnitOfWork _unitOfWork = new UnitOfWork();
                        var pIdentity = new personIdentity();
                        pIdentity.IDV = p.IDV;
                        pIdentity.idType = p.idType;
                        pIdentity.idNumber = p.idNumber;
                        pIdentity.issuedCountry = p.issuedCountry;
                        pIdentity.expiredDate = p.expiredDate;
                        pIdentity.vCreatedBy = p.vCreatedBy;
                        pIdentity.isDeleted = 0;
                        _unitOfWork.personIdentityRepository.Insert(pIdentity);
                        _unitOfWork.Save();
                    }
                    #endregion*/
                    
                    scope.Complete();
                    res = true;
                }
            }
            return res;
        }
    }

    public class profileEduServices : IprofileEdu
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0; // 0 means row is active, not in deleted status


        public profileEduServices()
        {
            _u = new UnitOfWork();
        }

        public IEnumerable<profileEduEntities> getEduByIDV(int profileIDV)
        {
            List<profileEduEntities> ms = new List<profileEduEntities>();
            var empEdu = _u.personEduRepository.GetMany(b => b.IDV == profileIDV &&  b.isDeleted == isDelete);
            if (empEdu.Any())
            {
                foreach ( personEdu px in empEdu)
                {
                    profileEduEntities t = new profileEduEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.eduLevel = px.eduLevel;
                    t.eduMajor = px.eduMajor;
                    t.eduValue = px.eduValue;
                    t.eduGraduate = px.eduGraduate;
                    t.eduCountry = px.eduCountry;
                    t.createTime = px.createTime;
                    t.updateTime = px.updateTime;
                    t.vCreatedBy = px.vCreatedBy;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t); 

                }
            }

            return ms.AsEnumerable();
        }

        public int addEdu(profileEduEntities  px)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personEdu
                {
                    //ID = px.ID,
                    IDV = px.IDV,
                    eduLevel = px.eduLevel,
                    eduMajor = px.eduMajor,
                    eduValue = px.eduValue,
                    eduGraduate = px.eduGraduate,
                    eduCountry = px.eduCountry,
                    vCreatedBy = px.vCreatedBy,
                    createTime = DateTime.Now,
                    isDeleted = 0
                };
                _u.personEduRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return px.ID;
            }

        }

        public bool UpdateEdu(int profileIDV, profileEduEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personEduRepository.GetByID(profileIDV);
                    if (px != null)
                    {
                        addEdu(p);
                        px.isDeleted = 1;
                        px.vUpdatedBy = p.vUpdatedBy;
                        px.updateTime = DateTime.Now;

                        _u.personEduRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
            //throw new NotImplementedException();
        }

        public bool DeleteEdu(int profileIDV, profileEduEntities p)
        {
            return UpdateEdu(profileIDV, p);
        }
    }
    public class profileSkillServices : IprofileSkill
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0; // 0 means row is active, not in deleted status

        public profileSkillServices()
        {
            _u = new UnitOfWork();
        }

        public IEnumerable<profileSkillEntities> getSkillByIDV(int profileIDV)
        {
            List<profileSkillEntities> ms = new List<profileSkillEntities>();
            var emp = _u.personSkillRepository.GetMany(b => b.IDV == profileIDV && b.isDeleted == isDelete);
            if (emp.Any())
            {
                foreach (personSkill px in emp)
                {
                    profileSkillEntities t = new profileSkillEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.skillLevel = px.skillLevel;
                    t.skillName = px.skillName;
                    t.vCreatedBy = px.vCreatedBy;
                    t.createTime = px.createTime;
                    t.updateTime = px.updateTime;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t);
                }
            }

            return ms.AsEnumerable();
        }

        public int addSkill(profileSkillEntities p)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personSkill
                {
                    //ID = px.ID,
                    IDV = p.IDV,
                    skillLevel = p.skillLevel,
                    skillName = p.skillName,
                    vCreatedBy = p.vCreatedBy,
                    createTime = DateTime.Now,
                    isDeleted = 0
                };
                _u.personSkillRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return p.ID;
            }
        }

        public bool UpdateSkill(int ID, profileSkillEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personSkillRepository.GetByID(ID);
                    if (px != null)
                    {
                        addSkill(p);
                        px.isDeleted = 1;
                        px.updateTime = DateTime.Now;
                        px.vUpdatedBy = p.vUpdatedBy;
                        _u.personSkillRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;
                        
                    }
                }
            }
            return success;
        }

        public bool DeleteSkill(int ID, profileSkillEntities p)
        {
            return UpdateSkill(ID, p);
        }
    }
    public class profileLanguageServices : IprofileLanguage
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0; // 0 means row is active, not in deleted status

        public profileLanguageServices()
        {
            _u = new UnitOfWork();
        }

        public IEnumerable<profileLanguageEntities> getLanguageByIDV(int profileIDV)
        {
            List<profileLanguageEntities> ms = new List<profileLanguageEntities>();
            var emp = _u.personLanguageRepository.GetMany(b => b.IDV == profileIDV && b.isDeleted == isDelete);
            if (emp.Any())
            {
                foreach (personLanguage px in emp)
                {
                    profileLanguageEntities t = new profileLanguageEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.languageName = px.languageName;
                    t.spoken = px.spoken;
                    t.written = px.written;
                    t.vCreatedBy = px.vCreatedBy;
                    t.createTime = px.createTime;
                    t.updateTime = px.updateTime;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t);
                }
            }

            return ms.AsEnumerable();
        }

        public int addLanguage(profileLanguageEntities p)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personLanguage
                {
                    //ID = px.ID,
                    IDV = p.IDV,
                    languageName = p.languageName,
                    spoken = p.spoken,
                    written = p.written,
                    vCreatedBy = p.vCreatedBy,
                    createTime = DateTime.Now,
                    isDeleted = 0
                };
                _u.personLanguageRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return p.ID;
            }
        }

        public bool UpdateLanguage(int ID, profileLanguageEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personLanguageRepository.GetByID(ID);
                    if (px != null)
                    {
                        addLanguage(p);
                        px.isDeleted = 1;
                        px.updateTime = DateTime.Now;
                        px.vUpdatedBy = p.vUpdatedBy;
                        _u.personLanguageRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;

                    }
                }
            }
            return success;
        }

        public bool DeleteLanguage(int ID, profileLanguageEntities p)
        {
            return UpdateLanguage(ID, p);
        }
    }
    public class profileTrainingServices : IprofileTraining
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0; // 0 means row is active, not in deleted status

        public profileTrainingServices()
        {
            _u = new UnitOfWork();
        }

        public IEnumerable<profileTrainingEntities> getTrainingByIDV(int profileIDV)
        {
            List<profileTrainingEntities> ms = new List<profileTrainingEntities>();
            var emp = _u.personTrainingRepository.GetMany(b => b.IDV == profileIDV && b.isDeleted == isDelete);
            if (emp.Any())
            {
                foreach (personTraining px in emp)
                {
                    profileTrainingEntities t = new profileTrainingEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.TrainingName = px.TrainingName;
                    t.TrainingSponsor = px.TrainingSponsor;
                    t.startDate = px.startDate;
                    t.endDate = px.endDate;
                    t.vCreatedBy = px.vCreatedBy;
                    t.createTime = px.createTime;
                    t.updateTime = px.updateTime;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t);
                }
            }

            return ms.AsEnumerable();
        }

        public int addTraining(profileTrainingEntities p)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personTraining
                {
                    //ID = px.ID,
                    IDV = p.IDV,
                    TrainingName = p.TrainingName,
                    TrainingSponsor = p.TrainingSponsor,
                    startDate = p.startDate,
                    endDate = p.endDate,
                    vCreatedBy = p.vCreatedBy,
                    createTime = DateTime.Now,
                    isDeleted = 0
                };
                _u.personTrainingRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return p.ID;
            }
        }

        public bool UpdateTraining(int ID, profileTrainingEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personTrainingRepository.GetByID(ID);
                    if (px != null)
                    {
                        addTraining(p);
                        px.isDeleted = 1;
                        px.updateTime = DateTime.Now;
                        px.vUpdatedBy = p.vUpdatedBy;
                        _u.personTrainingRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;

                    }
                }
            }
            return success;
        }

        public bool DeleteTraining(int ID, profileTrainingEntities p)
        {
            return UpdateTraining(ID, p);
        }
    }
    public class profileCertificationServices : IprofileCertification
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0; // 0 means row is active, not in deleted status

        public profileCertificationServices()
        {
            _u = new UnitOfWork();
        }

        public IEnumerable<profileCertificationEntities> getCertificationByIDV(int profileIDV)
        {
            List<profileCertificationEntities> ms = new List<profileCertificationEntities>();
            var emp = _u.personCertificationRepository.GetMany(b => b.IDV == profileIDV && b.isDeleted == isDelete);
            if (emp.Any())
            {
                foreach (personCertification px in emp)
                {
                    profileCertificationEntities t = new profileCertificationEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.certificationName = px.certificationName;
                    t.issuedCity = px.issuedCity;
                    t.issuedCountry = px.issuedCountry;
                    t.issuedDate = px.issuedDate;
                    t.issuedExpiredDate = px.issuedExpiredDate;
                    t.vCreatedBy = px.vCreatedBy;
                    t.createTime = px.createTime;
                    t.updateTime = px.updateTime;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t);
                }
            }

            return ms.AsEnumerable();
        }

        public int addCertification(profileCertificationEntities p)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personCertification
                {
                    //ID = px.ID,
                    IDV = p.IDV,
                    certificationName = p.certificationName,
                    issuedCity = p.issuedCity,
                    issuedCountry = p.issuedCountry,
                    issuedDate = p.issuedDate,
                    issuedExpiredDate = p.issuedExpiredDate,
                    vCreatedBy = p.vCreatedBy,
                    createTime = DateTime.Now,
                    isDeleted = 0
                };
                _u.personCertificationRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return p.ID;
            }
        }

        public bool UpdateCertification(int ID, profileCertificationEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personCertificationRepository.GetByID(ID);
                    if (px != null)
                    {
                        addCertification(p);
                        px.isDeleted = 1;
                        px.updateTime = DateTime.Now;
                        px.vUpdatedBy = p.vUpdatedBy;
                        _u.personCertificationRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteCertification(int ID, profileCertificationEntities p)
        {
            return UpdateCertification(ID, p);
        }
    }
    public class profileIdentityServices : IprofileIdentity
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0; // 0 means row is active, not in deleted status

        public profileIdentityServices()
        {
            _u = new UnitOfWork();
        }

        public IEnumerable<profileIdentityEntities> getIdentityByIDV(int profileIDV)
        {
            List<profileIdentityEntities> ms = new List<profileIdentityEntities>();
            var emp = _u.personIdentityRepository.GetMany(b => b.IDV == profileIDV && b.isDeleted == isDelete);
            if (emp.Any())
            {
                foreach (personIdentity px in emp)
                {
                    profileIdentityEntities t = new profileIdentityEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.idNumber = px.idNumber;
                    t.idType = px.idType;
                    t.issuedCountry = px.issuedCountry;
                    t.vCreatedBy = px.vCreatedBy;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t);
                }
            }

            return ms.AsEnumerable();
        }

        public int addIdentity(profileIdentityEntities p)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personIdentity
                {
                    //ID = px.ID,
                    IDV = p.IDV,
                    idNumber = p.idNumber,
                    idType = p.idType,
                    issuedCountry = p.issuedCountry,
                    vCreatedBy = p.vCreatedBy,
                    isDeleted = 0
                };
                _u.personIdentityRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return p.ID;
            }
        }

        public bool UpdateIdentity(int ID, profileIdentityEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personIdentityRepository.GetByID(ID);
                    if (px != null)
                    {
                        addIdentity(p);
                        px.isDeleted = 1;
                        px.vUpdatedBy = p.vUpdatedBy;
                        _u.personIdentityRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteIdentity(int ID, profileIdentityEntities p)
        {
            return UpdateIdentity(ID, p);
        }
    }
    public class profileDependentServices : IprofileDependent
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0; // 0 means row is active, not in deleted status
       
        public profileDependentServices()
        {
            _u = new UnitOfWork();
        }

        public IEnumerable<profileDependentEntities> getDependentByIDV(int parentIDV)
        {
            List<profileDependentEntities> ms = new List<profileDependentEntities>();
            var emp = _u.personDependentRepository.GetMany(b => b.IDVDependent == parentIDV && b.isDeleted == isDelete);
            if (emp.Any())
            {
                foreach (personDependent px in emp)
                {
                    profileDependentEntities t = new profileDependentEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.IDVDependent = px.IDVDependent;
                    t.relationType = px.relationType;
                    t.insuranceCovered = px.insuranceCovered;
                    t.taxDependent = px.taxDependent;
                    t.vCreatedBy = px.vCreatedBy;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t);
                }
            }

            return ms.AsEnumerable();
        }

        public int addDependent(profileDependentEntities p)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personDependent
                {
                    //ID = px.ID,
                    IDV = p.IDV,
                    IDVDependent = p.IDVDependent,
                    relationType = p.relationType,
                    insuranceCovered = p.insuranceCovered,
                    taxDependent = p.taxDependent,
                    vCreatedBy = p.vCreatedBy,
                    isDeleted = 0
                };
                _u.personDependentRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return p.ID;
            }
        }

        public bool UpdateDependent(int ID, profileDependentEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personDependentRepository.GetByID(ID);
                    if (px != null)
                    {
                        addDependent(p);
                        px.isDeleted = 1;
                        px.vUpdatedBy = p.vUpdatedBy;
                        _u.personDependentRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteDependent(int ID, profileDependentEntities p)
        {
            return UpdateDependent(ID, p);
        }
    }
    public class profileJobServices : IprofileJob
    {
        private readonly UnitOfWork _u;
        private int isDelete = 0;

        public profileJobServices()
        {
            _u = new UnitOfWork();
        }

        public int addJob(profileJobEntities p)
        {
            using (var scope = new TransactionScope())
            {
                var t = new personJob
                {
                    //ID = px.ID,
                    IDV = p.IDV.HasValue ? p.IDV.Value : 0,
                    JobDepartement = p.JobDepartement,
                    JobDivision = p.JobDivision,
                    JobLevel = p.JobLevel,
                    JobLocation = p.JobLocation,
                    jobName = p.jobName,
                    JobPosition = p.JobPosition,
                    startDate = p.startDate,
                    endDate = p.endDate,
                    Note = p.Note,
                    parentIDV = p.parentIDV,
                    updateTime = p.updateTime,
                    createTime = p.createTime,
                    vCreatedBy = p.vCreatedBy,
                    vUpdatedBy = p.vUpdatedBy,
                    isDeleted = 0
                };
                _u.personJobRepository.Insert(t);
                _u.Save();
                scope.Complete();
                return p.ID;
            }
        }
        
        public bool UpdateJob(int ID, profileJobEntities p)
        {
            var success = false;
            if (p != null)
            {
                using (var scope = new TransactionScope())
                {
                    var px = _u.personJobRepository.GetByID(ID);
                    if (px != null)
                    {
                        addJob(p);
                        px.isDeleted = 1;
                        px.vUpdatedBy = p.vUpdatedBy;
                        _u.personJobRepository.Update(px);
                        _u.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<profileJobEntities> getJobByIDV(int IDV)
        {
            List<profileJobEntities> ms = new List<profileJobEntities>();
            var emp = _u.personJobRepository.GetMany(b => b.IDV == IDV && b.isDeleted == isDelete);
            if (emp.Any())
            {
                foreach (personJob px in emp)
                {
                    profileJobEntities t = new profileJobEntities();
                    t.ID = px.ID;
                    t.IDV = px.IDV;
                    t.JobDepartement = px.JobDepartement;
                    t.JobDivision = px.JobDivision;
                    t.JobLevel = px.JobLevel;
                    t.JobLocation = px.JobLocation;
                    t.jobName = px.jobName;
                    t.JobPosition = px.JobPosition;
                    t.startDate = px.startDate;
                    t.endDate = px.endDate;
                    t.Note = px.Note;
                    t.parentIDV = px.parentIDV;
                    t.updateTime = px.updateTime;
                    t.createTime = px.createTime;
                    t.vCreatedBy = px.vCreatedBy;
                    t.vUpdatedBy = px.vUpdatedBy;
                    ms.Add(t);
                }
            }

            return ms.AsEnumerable();
        }
        
        public bool DeleteJob(int ID, profileJobEntities p)
        {
            return UpdateJob(ID, p);
        }
    }



}
