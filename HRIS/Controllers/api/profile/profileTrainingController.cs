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
    public class profileTrainingController : ApiController
    {
        private readonly IprofileTraining _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileTrainingController()
        {
            _pServices = new profileTrainingServices();// ProductServices();
        }

        #endregion

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getTrainingByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileTrainingEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not found");
        }

        public int Post([FromBody] profileTrainingEntities pEntity)
        {
            return _pServices.addTraining(pEntity);
        }

        public bool Put(int id, profileTrainingEntities pEntity)
        {
            System.Diagnostics.Debug.WriteLine("apiConsole: profileEntities", pEntity);
            if (id > 0)
            {
                return _pServices.UpdateTraining(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileTrainingEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteTraining(id, pEntity);
            return false;
        }
    }
}
