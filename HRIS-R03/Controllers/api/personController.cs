using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;

namespace HRIS_R03.Controllers.api
{
    public class personController : ApiController
    {
        private readonly IpersonServices _pServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public personController()
        {
            _pServices = new personServices();// ProductServices();
        }

        #endregion

        // GET api/product
        public HttpResponseMessage Get()
        {
            var p = _pServices.GetAllPersons();//.GetAllProducts();
            if (p != null)
            {
                var pEntities = p  as List<personEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person not found");
        }

        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            var p = _pServices.GetPersonById(id);
            if (p != null)
                return Request.CreateResponse(HttpStatusCode.OK, p);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/product
        public int Post([FromBody] personEntities pEntity)
        {
            return _pServices.CreatePerson(pEntity);
        }

        // PUT api/product/5
        public bool Put(int id, [FromBody]personEntities pEntity)
        {
            if (id > 0)
            {
                return _pServices.UpdatePerson(id, pEntity);
            }
            return false;
        }

        // DELETE api/product/5
        public bool Delete(int id, int user)
        {
            if (id > 0)
                return _pServices.DeletePerson(id, user);
            return false;
        }
    }
}
