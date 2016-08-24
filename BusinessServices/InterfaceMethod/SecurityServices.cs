using System;
using DataModel.UnitOfWork;
using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;

namespace BusinessServices.InterfaceMethod
{
    public class SecurityServices : Isecurity 
    {
        private readonly Iprofile _pProfile;
        private readonly UnitOfWork _unitOfWork;
        private readonly FileDataServices _file;
        private int isDelete = 0;

        public SecurityServices()
        {
            _pProfile = new ProfileServices();
            _unitOfWork = new UnitOfWork();
            _file = new FileDataServices();
        }

        public int isExist(LogOnModel model)
        {
            var getUser = _unitOfWork.userRepository.GetByCode(b => (b.IDVMAIL).Trim() == ( model.UserName).Trim() );
            //var getUser = await db.emp_user.FirstOrDefaultAsync(b => b.IDVMAIL == model.UserName || b.IDVMAILPASSWORD == model.Password);
            if (getUser.IDV < 0)
            {
                System.Diagnostics.Debug.WriteLine("LogOn False");
                return 0;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("LogOn True:" + getUser.IDV);
                return getUser.IDV;
            }
        }

        public bool AuthenticateLocal(LogOnModel model)
        {
            var getUser = _unitOfWork.userRepository.GetSingle(b => b.IDVMAIL == model.UserName || b.IDVMAILPASSWORD == model.Password);
            System.Diagnostics.Debug.WriteLine("Authenticate: IDV:" +  getUser.IDV + " : From Variable : " + getUser);
            if (getUser.IDV > 0){
                return true;
            } else  return false;
            
        }

        public bool AuthenticateLDAP(LogOnModel model)
        {
            return false;
        }

        public void UserSession()
        {
        }


        
        public UserCredModel getUserCred(int IDV)
        {
            UserCredModel ms = new UserCredModel();
            System.Diagnostics.Debug.WriteLine("Security Services: getUserCred: Variable: IDV=" + IDV + ", isDelete=" + isDelete);
            try
            {
                if (IDV > 0)
                {
                    ms.IDV = IDV;
                    ms.timeLogin = DateTime.Now;

                    #region getPersonDetail
                    var cc = _unitOfWork.personDetailRepository.GetSingle(e => e.IDV == IDV && e.isDeleted == isDelete);
                    if (cc != null)
                    {
                        ms.Name = cc.Name;
                        ms.NIP = cc.NIP;
                        ms.Image = _file.ImagePath(cc.NIP);
                    }
                    #endregion

                    #region getUser
                    var y = _unitOfWork.userRepository.GetSingle(b => b.IDV == IDV);
                    if (y != null)
                    {
                        ms.IDVMail = y.IDVMAIL;
                        ms.role = y.IDVROLE.HasValue ? y.IDVROLE.Value : -1;
                    }
                    #endregion

                    #region getpersonJob
                    var x = _unitOfWork.personJobRepository.GetByCode(c => c.IDV == IDV && c.isDeleted == isDelete);
                    
                    if (x != null)
                    {
                        ms.parentIDV = x.parentIDV.HasValue ? x.parentIDV.Value : -1;
                        #region getParent
                        var z = _unitOfWork.userRepository.GetByCode(b => b.IDV == x.parentIDV);
                        if (z != null)
                        {
                            ms.parentIDVMail = z.IDVMAIL;
                        }
                        #endregion

                    }
                    #endregion
                }

            } catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Security Sercive: getUserCred: Error: " + e.Message);
            }
            return ms;
        }


    }
}
