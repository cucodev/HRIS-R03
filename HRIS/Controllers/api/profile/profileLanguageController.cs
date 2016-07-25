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
    public class profileLanguageController : ApiController
    {
        private readonly IprofileLanguage _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileLanguageController()
        {
            _pServices = new profileLanguageServices();// ProductServices();
        }

        #endregion

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getLanguageByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileLanguageEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not found");
        }

        public int Post([FromBody] profileLanguageEntities pEntity)
        {
            return _pServices.addLanguage(pEntity);
        }

        public bool Put(int id, profileLanguageEntities pEntity)
        {
            System.Diagnostics.Debug.WriteLine("apiConsole: profileEntities", pEntity);
            if (id > 0)
            {
                return _pServices.UpdateLanguage(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileLanguageEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteLanguage(id, pEntity);
            return false;
        }
    }
}
