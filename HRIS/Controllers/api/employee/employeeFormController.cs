using BusinessEntities.CrudEntities;
using BusinessEntities.DataEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HRIS.Controllers.api.employee
{
    public class employeeFormController : ApiController
    {
        private readonly ILeave _pServices;

        public employeeFormController()
        {
            _pServices = new LeaveServices();
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("postLeave")]
        [System.Web.Http.Route("api/employeeForm/postLeave/{IDV}")]
        public HttpResponseMessage postLeave(List<leaveSummaryEntities> dt, int IDV )
        {
            /*var resolveRequest = HttpContext.Request;
            List<leaveSummaryEntities> model = new List<leaveSummaryEntities>();
            Request..InputStream.Seek(0, SeekOrigin.Begin);
            string jsonString = new StreamReader(dt).ReadToEnd();
            if (jsonString != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                model = (List<YourModel>)serializer.Deserialize(jsonString, typeof(List<YourModel>);
            }
            */
           // int IDV = 3;

            int i = 0;
            foreach (leaveSummaryEntities summaryE in dt)
            {
                System.Diagnostics.Debug.WriteLine(IDV + " Posted Data: " + summaryE.Date + ", i=" + i);
                
                i = summaryE.ID;
            }
           // return Request.CreateResponse(HttpStatusCode.OK, i);

           
            var p = _pServices.PostLeaveSummary(IDV, IDV, dt);
            if (p != 0)
            {
                var pEntities = p; // as leaveSummaryEntities ?? p;
                if (pEntities != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "HRD Matrix for this employee are not found");
        }



    }
}
