using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface IList
    {
        //listEntities getListByParentID(int parentID);
        IEnumerable<LOV> getDivision();
        IEnumerable<LOV> getDepartment();
        IEnumerable<LOV> getPosition();
        IEnumerable<listEntities> getParentCategory();
        IEnumerable<LOV> getOrg();
        IEnumerable<LOV> getSkillLevel();
        IEnumerable<LOV> getEmpStatus();
        IEnumerable<LOV> getMarital();
        IEnumerable<LOV> getGender();
        IEnumerable<LOV> getReligion();
        IEnumerable<LOV> getID();
        IEnumerable<LOV> getName();

        IEnumerable<LOVLocation> getCountry();
        IEnumerable<LOVLocation> getLocation(long id);

        IEnumerable<LOVLocation> getProvince();
        IEnumerable<LOVLocation> getKabupaten();
        IEnumerable<LOVLocation> getKecamatan();

        //IEnumerable<listEntities> getListCategory(int parentID);
        //IEnumerable<listEntities> getListparentCategory(int parentID);
        //int CreateProfile(listEntities personEntity);
        //bool UpdateProfile(int personID, listEntities personEntity);
        //bool DeleteProfile(int personIDV, int vUpdatedBy);
    }
}
