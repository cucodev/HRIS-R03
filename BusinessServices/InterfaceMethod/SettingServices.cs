using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.InterfaceMethod
{
    public class SettingServices : ISetting
    {
        private readonly UnitOfWork _u;

        public SettingServices()
        {
            _u = new UnitOfWork();
        }


        public SettingEntities getValue(string constanta)
        {
            SettingEntities ms = new SettingEntities();
            var val = _u.settingRepository.GetFirst(b => b.type.Trim() == constanta.Trim());
            if (val != null)
            {
                ms.id = val.id;
                ms.type = val.type;
                ms.value = val.value;
                ms.description = val.description;
                ms.vUpdatedBy = val.vUpdatedBy;
                ms.updateTime = val.updateTime;
            }
            return ms;   
        }
    }
}
