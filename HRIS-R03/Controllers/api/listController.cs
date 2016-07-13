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
            _pServices = new ListService();// ProductServices();
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getParentCategory")]
        [System.Web.Http.Route("api/list/getParentCategory")]
        public IEnumerable<listEntities> getParentCategory()
        {
            var p = _pServices.getParentCategory();
            if (p != null)
            {
                var pEntities = p as List<listEntities> ?? p.ToList();
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
