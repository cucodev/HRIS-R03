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
    public class profileJobController : ApiController
    {
        private readonly IprofileJob _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileJobController()
        {
            _pServices = new profileJobServices();// ProductServices();
        }

        #endregion

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getJobByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileJobEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not found");
        }

        public int Post([FromBody] profileJobEntities pEntity)
        {
            return _pServices.addJob(pEntity);
        }

        public bool Put(int id, profileJobEntities pEntity)
        {
            if (id > 0)
            {
                return _pServices.UpdateJob(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileJobEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteJob(id, pEntity);
            return false;
        }
    }
}
