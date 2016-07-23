using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;

namespace HRIS_R03.Controllers.api
{
    public class listController : ApiController
    {
        private readonly IList _pServices;

        public listController()
        {
            _pServices = new ListServices();// ProductServices();
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getDatafieldJobLevel")]
        [System.Web.Http.Route("api/list/getDatafieldJobLevel")]
        public IEnumerable<DynamicDatafield> getDatafieldJobLevel()
        {
            var p = _pServices.datafieldJobLevel();
            if (p != null)
            {
                var pEntities = p as List<DynamicDatafield> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }


        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getColumnJobLevel")]
        [System.Web.Http.Route("api/list/getColumnJobLevel")]
        public IEnumerable<DynamicColumn> getColumnJobLevel()
        {
            var p = _pServices.columnJobLevel();
            if (p != null)
            {
                var pEntities = p as List<DynamicColumn> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }


        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getValueType")]
        [System.Web.Http.Route("api/list/getValueType")]
        public IEnumerable<LOV> getValueType()
        {
            var p = _pServices.getValueType();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getPolicyType")]
        [System.Web.Http.Route("api/list/getPolicyType")]
        public IEnumerable<LOV> getPolicyType()
        {
            var p = _pServices.getPolicyType();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getPolicyRootType")]
        [System.Web.Http.Route("api/list/getPolicyRootType")]
        public IEnumerable<LOV> getPolicyRootType()
        {
            var p = _pServices.getPolicyRootType();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getName")]
        [System.Web.Http.Route("api/list/getName")]
        public IEnumerable<LOV> getName()
        {
            var p = _pServices.getName();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getParentCategory")]
        [System.Web.Http.Route("api/list/getParentCategory")]
        public IEnumerable<classificationEntities> getParentCategory()
        {
            var p = _pServices.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<classificationEntities> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getOrg")]
        [System.Web.Http.Route("api/list/getOrg")]
        public IEnumerable<LOV> getOrg()
        {
            var p = _pServices.getOrg();//.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getEdu")]
        [System.Web.Http.Route("api/list/getEdu")]
        public IEnumerable<LOV> getEdu()
        {
            var p = _pServices.getEdu();//.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }


        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getLevelTree")]
        [System.Web.Http.Route("api/list/getLevelTree")]
        public IEnumerable<LOVTree> getLevelTree()
        {
            var p = _pServices.getLevelTree();//.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<LOVTree> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getLevel")]
        [System.Web.Http.Route("api/list/getLevel")]
        public IEnumerable<LOV> getLevel()
        {
            var p = _pServices.getLevel();//.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getSkillLevel")]
        [System.Web.Http.Route("api/list/getSkillLevel")]
        public IEnumerable<LOV> getSkillLevel()
        {
            var p = _pServices.getSkillLevel();//.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getEmpStatus")]
        [System.Web.Http.Route("api/list/getEmpStatus")]
        public IEnumerable<LOV> getEmpStatus()
        {
            var p = _pServices.getEmpStatus();//.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getMarital")]
        [System.Web.Http.Route("api/list/getMarital")]
        public IEnumerable<LOV> getMarital()
        {
            var p = _pServices.getMarital();//.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getGender")]
        [System.Web.Http.Route("api/list/getGender")]
        public IEnumerable<LOV> getGender()
        {
            var p = _pServices.getGender();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getID")]
        [System.Web.Http.Route("api/list/getID")]
        public IEnumerable<LOV> getID()
        {
            var p = _pServices.getID();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getReligion")]
        [System.Web.Http.Route("api/list/getReligion")]
        public IEnumerable<LOV> getReligion()
        {
            var p = _pServices.getReligion();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getPosition")]
        [System.Web.Http.Route("api/list/getPosition")]
        public IEnumerable<LOV> getPosition()
        {
            var p = _pServices.getPosition();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        //Division
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getDivision")]
        [System.Web.Http.Route("api/list/getDivision")]
        public IEnumerable<LOV> getDivision()
        {
            var p = _pServices.getDivision();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

 
        //Country
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getCountry")]
        [System.Web.Http.Route("api/list/getCountry")]
        public IEnumerable<LOVLocation> getCountry()
        {
            var p = _pServices.getCountry();
            if (p != null)
            {
                var pEntities = p as List<LOVLocation> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        //Province
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getLocation")]
        [System.Web.Http.Route("api/list/getLocation/{id}")]
        public IEnumerable<LOVLocation> getLocaton(long id)
        {
            var p = _pServices.getLocation(id);
            if (p != null)
            {
                var pEntities = p as List<LOVLocation> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }


        //Province
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getProvince")]
        [System.Web.Http.Route("api/list/getProvince")]
        public IEnumerable<LOVLocation> getProvince()
        {
            var p = _pServices.getProvince();
            if (p != null)
            {
                var pEntities = p as List<LOVLocation> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        //Kabupaten Kota
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getKabupaten")]
        [System.Web.Http.Route("api/list/getKabupaten")]
        public IEnumerable<LOVLocation> getKabupaten()
        {
            var p = _pServices.getKabupaten();
            if (p != null)
            {
                var pEntities = p as List<LOVLocation> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        //Kabupaten Kota
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getKecamatan")]
        [System.Web.Http.Route("api/list/getKecamatan")]
        public IEnumerable<LOVLocation> getKecamatan()
        {
            var p = _pServices.getKecamatan();
            if (p != null)
            {
                var pEntities = p as List<LOVLocation> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        //Kabupaten Kota
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBasedTree")]
        [System.Web.Http.Route("api/list/getRoleBasedTree")]
        public IEnumerable<LOVTree> getRoleBasedTree()
        {
            var p = _pServices.getRoleBasedTree();
            if (p != null)
            {
                var pEntities = p as List<LOVTree> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }


        //Department shows nothing, because its parent to Division each
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getDepartment")]
        [System.Web.Http.Route("api/list/getDepartment")]
        public IEnumerable<LOV> getDepartementn()
        {
            var p = _pServices.getDepartment();
            if (p != null)
            {
                var pEntities = p as List<LOV> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            return null;
            //return new string[] { "value1", "value2" };
        }

    }
}
