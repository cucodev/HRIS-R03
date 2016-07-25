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
    public class profileEduController : ApiController
    {
        private readonly IprofileEdu _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileEduController()
        {
            _pServices = new profileEduServices();// ProductServices();
        }

        #endregion
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getEduByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileEduEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person not found");
        }

        public int Post([FromBody] profileEduEntities pEntity)
        {
            return _pServices.addEdu(pEntity);
        }

        public bool Put(int id, profileEduEntities pEntity)
        {
            System.Diagnostics.Debug.WriteLine("apiConsole: profileEntities", pEntity);
            if (id > 0)
            {
                return _pServices.UpdateEdu(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileEduEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteEdu(id, pEntity);
            return false;
        }
    }
}
