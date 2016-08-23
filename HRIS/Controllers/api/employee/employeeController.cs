using BusinessEntities.CrudEntities;
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
    public class employeeController : ApiController
    {
        private readonly IEmployee _pServices;

        public employeeController()
        {
            _pServices = new employeeServices();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getStructure")]
        [System.Web.Http.Route("api/employee/getStructure")]
        public HttpResponseMessage getStructure()
        {
            var p = _pServices.getStructure();
            if (p != null)
                return Request.CreateResponse(HttpStatusCode.OK, p);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Structure Not found");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getEmployee")]
        [System.Web.Http.Route("api/employee/getEmployee/{IDV}")]
        public HttpResponseMessage getEmployee(int IDV)
        {
            var p = _pServices.GetEmployee(IDV);
            if (p != null)
                return Request.CreateResponse(HttpStatusCode.OK, p);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not found");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBased")]
        [System.Web.Http.Route("api/employee/getRoleBased/{IDV}")]
        public HttpResponseMessage getRoleBased(int IDV)
        {
            var p = _pServices.GetRoleBased(IDV);
            if (p != null)
            {
                var pEntities = p as List<employeeRoleBasedEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "HRD Matrix for this employee are not found");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getMedicalRoleBased")]
        [System.Web.Http.Route("api/employee/getMedicalRoleBased/{IDV}")]
        public HttpResponseMessage getMedicalRoleBased(int IDV)
        {
            var p = _pServices.getCurrentRoleBasedMedical(IDV);
            if (p != null)
            {
                var pEntities = p as List<employeeRoleBasedEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "HRD Matrix for this employee are not found");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getLeaveRoleBased")]
        [System.Web.Http.Route("api/employee/getLeaveRoleBased/{IDV}")]
        public HttpResponseMessage getLeaveRoleBased(int IDV)
        {
            var p = _pServices.getCurrentRoleBasedLeave(IDV);
            if (p != null)
            {
                var pEntities = p as List<employeeRoleBasedEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "HRD Matrix for this employee are not found");
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBasedValue")]
        [System.Web.Http.Route("api/employee/getRoleBasedValue/{IDV}/{policyType}")]
        public HttpResponseMessage getRoleBasedValue(int IDV, int policyType)
        {
            var p = _pServices.getRoleBasedValue(IDV, policyType);
            if (p != null)
            {
                var pEntities = p as employeeRoleBasedEntities ?? p;
                if (pEntities.ID != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "HRD Matrix for this employee are not found");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBasedAnnualValue")]
        [System.Web.Http.Route("api/employee/getRoleBasedAnnualValue/{IDV}")]
        public HttpResponseMessage getRoleBasedAnnualValue(int IDV)
        {
            var p = _pServices.GetRoleBased(IDV);
            if (p != null)
            {
                var pEntities = p as List<employeeRoleBasedEntities> ?? p.ToList();
                if (pEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "HRD Matrix for this employee are not found");
        }

        


    }
}
