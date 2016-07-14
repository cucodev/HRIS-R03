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

        IEnumerable<LocationEntities> getCountry();
        IEnumerable<LocationEntities> getLocation(long id);

        IEnumerable<LocationEntities> getProvince();
        IEnumerable<LocationEntities> getKabupaten();
        IEnumerable<LocationEntities> getKecamatan();

        //IEnumerable<listEntities> getListCategory(int parentID);
        //IEnumerable<listEntities> getListparentCategory(int parentID);
        //int CreateProfile(listEntities personEntity);
        //bool UpdateProfile(int personID, listEntities personEntity);
        //bool DeleteProfile(int personIDV, int vUpdatedBy);
    }
}
