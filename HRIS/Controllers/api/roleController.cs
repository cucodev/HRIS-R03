using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;

namespace HRIS.Controllers.api
{
    public class roleController : ApiController
    {
        private readonly IRoleBased _pServices;

        public roleController()
        {
            _pServices = new RoleBasedServices();
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBased")]
        [System.Web.Http.Route("api/role/getRoleBased")]
        public IEnumerable<roleBasedEntities> getRoleBased()
        {
            var p = _pServices.getRoleBased();
            if (p != null)
            {
                var pEntities = p as List<roleBasedEntities> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBasedBypolicyType")]
        [System.Web.Http.Route("api/role/getRoleBasedBypolicyType/{policyTypeID}")]
        public IEnumerable<roleBasedEntities> getRoleBasedBypolicyType(int policyTypeID)
        {
            var p = _pServices.getRoleBasedBypolicyType(policyTypeID);
            if (p != null)
            {
                var pEntities = p as List<roleBasedEntities> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }


        [System.Web.Http.HttpDelete]
        [System.Web.Http.ActionName("deleteRoleBased")]
        [System.Web.Http.Route("api/role/deleteRoleBased")]
        public bool deleteRoleBased(int id)
        {
            if (id > 0)
                return _pServices.DeleteRoleBased(id);
            return false;
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("createRoleBased")]
        [System.Web.Http.Route("api/role/createRoleBased")]
        public int createRoleBased(roleBasedEntities p)
        {
            System.Diagnostics.Debug.WriteLine("[Controller] - createRoleBased");
            return _pServices.CreateRoleBased(p);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.ActionName("updateRoleBased")]
        [System.Web.Http.Route("api/role/updateRoleBased/{id}")]
        public bool updateRoleBased(int id, roleBasedEntities pEntity)
        {
            System.Diagnostics.Debug.WriteLine("apiConsole: update roleBasedEntities", pEntity);
            if (id > 0)
            {
                return _pServices.UpdateRoleBased(id, pEntity);
            }
            return false;
        }

        
    }
}
