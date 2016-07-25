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
    public class profileDependentController : ApiController
    {
        private readonly IprofileDependent _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileDependentController()
        {
            _pServices = new profileDependentServices();// ProductServices();
        }

        #endregion

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getDependentByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileDependentEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not found");
        }

        public int Post([FromBody] profileDependentEntities pEntity)
        {
            return _pServices.addDependent(pEntity);
        }

        public bool Put(int id, profileDependentEntities pEntity)
        {
            if (id > 0)
            {
                return _pServices.UpdateDependent(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileDependentEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteDependent(id, pEntity);
            return false;
        }
    }
}
