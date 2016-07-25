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
    public class profileCertificationController : ApiController
    {
        private readonly IprofileCertification _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileCertificationController()
        {
            _pServices = new profileCertificationServices();// ProductServices();
        }

        #endregion

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getCertificationByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileCertificationEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not found");
        }

        public int Post([FromBody] profileCertificationEntities pEntity)
        {
            return _pServices.addCertification(pEntity);
        }

        public bool Put(int id, profileCertificationEntities pEntity)
        {
            if (id > 0)
            {
                return _pServices.UpdateCertification(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileCertificationEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteCertification(id, pEntity);
            return false;
        }
    }
}
