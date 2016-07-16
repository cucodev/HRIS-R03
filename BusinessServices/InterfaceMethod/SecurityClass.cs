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
    public class SecurityClass : Isecurity 
    {
        private readonly IprofileServices _pProfile;
        private readonly UnitOfWork _unitOfWork;

        public SecurityClass()
        {
            _pProfile = new profileServices();
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
            var getUser = _unitOfWork.userRepository.GetFirst(b => b.IDVMAIL == model.UserName || b.IDVMAILPASSWORD == model.Password);
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

        public profileEntities getProfile(int id)
        {
           return _pProfile.GetProfileById(id);
        }
    }
}
