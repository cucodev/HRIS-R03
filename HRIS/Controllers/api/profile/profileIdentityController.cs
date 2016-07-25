using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;

namespace HRIS.Controllers.api.profile
{
    public class profileIdentityController : ApiController
    {
        private readonly IprofileIdentity _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileIdentityController()
        {
            _pServices = new profileIdentityServices();// ProductServices();
        }

        #endregion

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getIdentityByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileIdentityEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not found");
        }

        public int Post([FromBody] profileIdentityEntities pEntity)
        {
            return _pServices.addIdentity(pEntity);
        }

        public bool Put(int id, profileIdentityEntities pEntity)
        {
            if (id > 0)
            {
                return _pServices.UpdateIdentity(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileIdentityEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteIdentity(id, pEntity);
            return false;
        }
    }
}
