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
    public class profileServices : IprofileServices
    {
        private readonly UnitOfWork _unitOfWork;
        private int isDelete = 0; // 0 means row is active, not in deleted status

        public profileServices()
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
}
