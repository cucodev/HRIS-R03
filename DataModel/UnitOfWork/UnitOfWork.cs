#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel.GenericRepository;
using DataModel;

#endregion

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private HRISEntities _context = null;
        private GenericRepository<person> _personRepository;
        private GenericRepository<personAddress> _personAddressRepository;
        private GenericRepository<personBankAccount> _personBankAccountRepository;
        private GenericRepository<personCertification> _personCertificationRepository;
        private GenericRepository<personContact> _personContactRepository;
        private GenericRepository<personDependent> _personDependentRepository;
        private GenericRepository<personDetail> _personDetailRepository;
        private GenericRepository<personEdu> _personEduRepository;
        private GenericRepository<personEmergency> _personEmergencyRepository;
        private GenericRepository<personIdentity> _personIdentityRepository;
        private GenericRepository<personJob> _personJobRepository;
        private GenericRepository<personLanguage> _personLanguageRepository;
        private GenericRepository<personSkill> _personSkillRepository;
        private GenericRepository<personTraining> _personTrainingRepository;
        private GenericRepository<personWorkExperience> _personWorkExperienceRepository;
        private GenericRepository<employee> _employeeRepository;
        private GenericRepository<employeeRoleBased> _employeeRoleBasedRepository;
        private GenericRepository<C_purpose> _C_purposeRepository;
        private GenericRepository<C_transaction> _C_transactionRepository;
        private GenericRepository<category> _categoryRepository;
        private GenericRepository<categoryParent> _categoryParentRepository;
        private GenericRepository<file> _fileRepository;
        private GenericRepository<location> _locationParentRepository;
        private GenericRepository<organization> _organizationRepository;
        private GenericRepository<roleBased> _roleBasedRepository;
        private GenericRepository<roleBasedMatrix> _roleBasedMatrixRepository;

        private GenericRepository<user> _userRepository;
        private GenericRepository<Token> _tokenRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new HRISEntities();
        }

        #region Public Repository Creation properties...

        public GenericRepository<roleBased> roleBasedRepository
        {
            get
            {
                if (this._roleBasedRepository == null)
                    this._roleBasedRepository = new GenericRepository<roleBased>(_context);
                return _roleBasedRepository;
            }
        }
        public GenericRepository<roleBasedMatrix> roleBasedMatrixRepository
        {
            get
            {
                if (this._roleBasedMatrixRepository == null)
                    this._roleBasedMatrixRepository = new GenericRepository<roleBasedMatrix>(_context);
                return _roleBasedMatrixRepository;
            }
        }

        public GenericRepository<C_purpose> purposeRepository
        {
            get
            {
                if (this._C_purposeRepository == null)
                    this._C_purposeRepository = new GenericRepository<C_purpose>(_context);
                return _C_purposeRepository;
            }
        }

        public GenericRepository<C_transaction> transactionRepository
        {
            get
            {
                if (this._C_transactionRepository == null)
                    this._C_transactionRepository = new GenericRepository<C_transaction>(_context);
                return _C_transactionRepository;
            }
        }
        public GenericRepository<category> categoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new GenericRepository<category>(_context);
                return _categoryRepository;
            }
        }
        public GenericRepository<categoryParent> categoryParentRepository
        {
            get
            {
                if (this._categoryParentRepository == null)
                    this._categoryParentRepository = new GenericRepository<categoryParent>(_context);
                return _categoryParentRepository;
            }
        }
        public GenericRepository<employee> employeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                    this._employeeRepository = new GenericRepository<employee>(_context);
                return _employeeRepository;
            }
        }
        public GenericRepository<employeeRoleBased> employeeRoleBasedRepository
        {
            get
            {
                if (this._employeeRoleBasedRepository == null)
                    this._employeeRoleBasedRepository = new GenericRepository<employeeRoleBased>(_context);
                return _employeeRoleBasedRepository;
            }
        }
        public GenericRepository<file> fileRepository
        {
            get
            {
                if (this._fileRepository == null)
                    this._fileRepository = new GenericRepository<file>(_context);
                return _fileRepository;
            }
        }
        public GenericRepository<location> locationParentRepository
        {
            get
            {
                if (this._locationParentRepository == null)
                    this._locationParentRepository = new GenericRepository<location>(_context);
                return _locationParentRepository;
            }
        }
        public GenericRepository<organization> organizationRepository
        {
            get
            {
                if (this._organizationRepository == null)
                    this._organizationRepository = new GenericRepository<organization>(_context);
                return _organizationRepository;
            }
        }
        public GenericRepository<person> personRepository
        {
            get
            {
                if (this._personRepository == null)
                    this._personRepository = new GenericRepository<person>(_context);
                return _personRepository;
            }
        }
        public GenericRepository<personAddress> personAddressRepository
        {
            get
            {
                if (this._personAddressRepository == null)
                    this._personAddressRepository = new GenericRepository<personAddress>(_context);
                return _personAddressRepository;
            }
        }
        public GenericRepository<personBankAccount> personBankAccountRepository
        {
            get
            {
                if (this._personBankAccountRepository == null)
                    this._personBankAccountRepository = new GenericRepository<personBankAccount>(_context);
                return _personBankAccountRepository;
            }
        }
        public GenericRepository<personCertification> personCertificationRepository
        {
            get
            {
                if (this._personCertificationRepository == null)
                    this._personCertificationRepository = new GenericRepository<personCertification>(_context);
                return _personCertificationRepository;
            }
        }
        public GenericRepository<personContact> personContactRepository
        {
            get
            {
                if (this._personContactRepository == null)
                    this._personContactRepository = new GenericRepository<personContact>(_context);
                return _personContactRepository;
            }
        }
        public GenericRepository<personDependent> personDependentRepository
        {
            get
            {
                if (this._personDependentRepository == null)
                    this._personDependentRepository = new GenericRepository<personDependent>(_context);
                return _personDependentRepository;
            }
        }
        public GenericRepository<personDetail> personDetailRepository
        {
            get
            {
                if (this._personDetailRepository == null)
                    this._personDetailRepository = new GenericRepository<personDetail>(_context);
                return _personDetailRepository;
            }
        }
        public GenericRepository<personEdu> personEduRepository
        {
            get
            {
                if (this._personEduRepository == null)
                    this._personEduRepository = new GenericRepository<personEdu>(_context);
                return _personEduRepository;
            }
        }
        public GenericRepository<personEmergency> personEmergencyRepository
        {
            get
            {
                if (this._personEmergencyRepository == null)
                    this._personEmergencyRepository = new GenericRepository<personEmergency>(_context);
                return _personEmergencyRepository;
            }
        }
        public GenericRepository<personIdentity> personIdentityRepository
        {
            get
            {
                if (this._personIdentityRepository == null)
                    this._personIdentityRepository = new GenericRepository<personIdentity>(_context);
                return _personIdentityRepository;
            }
        }
        public GenericRepository<personJob> personJobRepository
        {
            get
            {
                if (this._personJobRepository == null)
                    this._personJobRepository = new GenericRepository<personJob>(_context);
                return _personJobRepository;
            }
        }
        public GenericRepository<personLanguage> personLanguageRepository
        {
            get
            {
                if (this._personLanguageRepository == null)
                    this._personLanguageRepository = new GenericRepository<personLanguage>(_context);
                return _personLanguageRepository;
            }
        }
        public GenericRepository<personSkill> personSkillRepository
        {
            get
            {
                if (this._personSkillRepository == null)
                    this._personSkillRepository = new GenericRepository<personSkill>(_context);
                return _personSkillRepository;
            }
        }
        public GenericRepository<personTraining> personTrainingRepository
        {
            get
            {
                if (this._personTrainingRepository == null)
                    this._personTrainingRepository = new GenericRepository<personTraining>(_context);
                return _personTrainingRepository;
            }
        }
        public GenericRepository<personWorkExperience> personWorkExperienceRepository
        {
            get
            {
                if (this._personWorkExperienceRepository == null)
                    this._personWorkExperienceRepository = new GenericRepository<personWorkExperience>(_context);
                return _personWorkExperienceRepository;
            }
        }
        public GenericRepository<user> userRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<user>(_context);
                return _userRepository;
            }
        }
        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository<Token>(_context);
                return _tokenRepository;
            }
        }
        

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        //outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\e\errors.txt", outputLines);

                //throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}