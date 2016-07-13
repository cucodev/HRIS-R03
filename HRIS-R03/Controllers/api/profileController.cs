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
    public class profileController : ApiController
    {
        private readonly IprofileServices _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileController()
        {
            _pServices = new profileServices();// ProductServices();
        }

        #endregion

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getOrg")]
        [System.Web.Http.Route("api/getOrg/{orgID}")]
        public HttpResponseMessage getOrg(int OrgID)
        {
            var p = _pServices.GetAllOrgProfiles(OrgID);//.GetAllProducts();
            if (p != null)
            {
                var pEntities = p as List<profileEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person within this Organization are not found");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("profile")]
        [System.Web.Http.Route("api/profile")]
        public HttpResponseMessage profile()
        {
            var p = _pServices.GetAllProfiles();//.GetAllProducts();
            if (p != null)
            {
                var pEntities = p as List<profileEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person not found");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("profile")]
        [System.Web.Http.Route("api/profile/{id}")]
        public HttpResponseMessage Profile(int id)
        {
            var p = _pServices.GetProfileById(id);
            if (p != null)
                return Request.CreateResponse(HttpStatusCode.OK, p);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/product
        public int Post([FromBody] profileEntities pEntity)
        {
            return _pServices.CreateProfile(pEntity);
        }

        // PUT api/product/5
        public bool Put(int id, profileEntities pEntity)
        {
            System.Diagnostics.Debug.WriteLine("apiConsole: profileEntities", pEntity);
            if (id > 0)
            {
                return _pServices.UpdateProfile(id, pEntity);
            }
            return false;
        }

        // DELETE api/product/5
        public bool Delete(int id, int user)
        {
            if (id > 0)
                return _pServices.DeleteProfile(id, user);
            return false;
        }
    }
}
