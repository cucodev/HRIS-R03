using BusinessEntities.DataEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRIS.Controllers.api.employee
{
    public class employeeTransactionController : ApiController
    {
        private readonly ITx _pServices;

        public employeeTransactionController()
        {
            _pServices = new TransactionServices();
        }

        //Mapping Field


        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getTransaction")]
        [System.Web.Http.Route("api/employeeTransaction/getTransaction/{IDV}/{purposeID}")]
        public HttpResponseMessage postLeave(int IDV, int purposeID)
        {
            var p = _pServices.getByIDV(IDV, purposeID);
            if (p != null)
            {
                if (p.Any())
                {
                    var pEntities = p; //as transactionMaster ?? p.ToList();
                    if (pEntities.Any())
                        return Request.CreateResponse(HttpStatusCode.OK, pEntities);
                }
            }
            
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "HRD Matrix for this employee are not found");
        }



        // GET: api/employeeTransaction
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/employeeTransaction/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/employeeTransaction
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/employeeTransaction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/employeeTransaction/5
        public void Delete(int id)
        {
        }
    }
}
