using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.UnitOfWork;
using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;

namespace BusinessServices.InterfaceMethod
{
    public class SecurityServices : Isecurity 
    {
        private readonly IprofileServices _pProfile;
        private readonly UnitOfWork _unitOfWork;
        private int isDelete = 0;

        public SecurityServices()
        {
            _pProfile = new ProfileServices();
            _unitOfWork = new UnitOfWork();
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
            System.Diagnostics.Debug.WriteLine("Variable: IDV=" + IDV + ", isDelete=" + isDelete);
            UserCredModel ms = new UserCredModel();
            var y = _unitOfWork.userRepository.GetSingle(b => b.IDV == IDV);
            System.Diagnostics.Debug.WriteLine("y:" + y.IDV);
            var x = _unitOfWork.personJobRepository.GetByCode(c => c.IDV == IDV && c.isDeleted == isDelete);
            System.Diagnostics.Debug.WriteLine("X:" + x.IDV + ", parentID:" + x.parentIDV);
            var z = _unitOfWork.userRepository.GetByCode(b => b.IDV == x.parentIDV);
            System.Diagnostics.Debug.WriteLine("z:parentID:", z.IDV);
            var cc = _unitOfWork.personDetailRepository.GetSingle(e => e.IDV == IDV && e.isDeleted == isDelete);
            ms.IDV = x.IDV;
            ms.IDVMail = y.IDVMAIL;
            ms.Name = cc.Name;
            ms.parentIDV = x.parentIDV.HasValue ? x.parentIDV.Value : -1;
            ms.parentIDVMail = z.IDVMAIL;
            ms.role = y.IDVROLE.HasValue ? y.IDVROLE.Value : -1;
            ms.timeLogin = DateTime.Now;

            System.Diagnostics.Debug.WriteLine(ms.IDV + ":" + ms.IDVMail + ":" + ms.Name + ":" + ms.parentIDV + ":" + ms.parentIDVMail + ":" + ms.role + ":" + ms.timeLogin);

            return ms;
        }
    }
}
