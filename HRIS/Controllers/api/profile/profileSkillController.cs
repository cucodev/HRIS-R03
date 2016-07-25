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
    public class profileSkillController : ApiController
    {
        private readonly IprofileSkill _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public profileSkillController()
        {
            _pServices = new profileSkillServices();// ProductServices();
        }

        #endregion

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.getSkillByIDV(id);
            if (p != null)
            {
                var pEntities = p as List<profileSkillEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Not found");
        }

        public int Post([FromBody] profileSkillEntities pEntity)
        {
            return _pServices.addSkill(pEntity);
        }

        public bool Put(int id, profileSkillEntities pEntity)
        {
            System.Diagnostics.Debug.WriteLine("apiConsole: profileEntities", pEntity);
            if (id > 0)
            {
                return _pServices.UpdateSkill(id, pEntity);
            }
            return false;
        }

        public bool Delete(int id, profileSkillEntities pEntity)
        {
            if (id > 0)
                return _pServices.DeleteSkill(id, pEntity);
            return false;
        }
    }
}
