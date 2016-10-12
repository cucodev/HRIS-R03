using BusinessEntities.CrudEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
    public interface ISetting
    {
        //constanta == Static Variable in GlobalVariable
        SettingEntities getValue(string constanta);
    }
}
