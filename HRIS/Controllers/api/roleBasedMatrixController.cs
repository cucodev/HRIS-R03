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
    public class roleBasedMatrixController : ApiController
    {
        private readonly IManageRoleBasedMatrix _pServices;

        public roleBasedMatrixController()
        {
            _pServices = new RoleBasedMatrixServices();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBasedMatrix")]
        [System.Web.Http.Route("api/role/getRoleBasedMatrix")]
        public IEnumerable<roleBasedMatrixEntities> getRoleBasedMatrix()
        {
            var p = _pServices.getMatrix();
            if (p != null)
            {
                var pEntities = p as List<roleBasedMatrixEntities> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getRoleBasedMatrixByID")]
        [System.Web.Http.Route("api/role/getRoleBasedMatrixByID")]
        public roleBasedMatrixEntities getRoleBasedMatrixByID(int ID)
        {
            var p = _pServices.getMatrixByID(ID);
            if (p != null)
            {
                var pEntities = p as roleBasedMatrixEntities;
                if (pEntities != null)
                    return pEntities;
            }
            // return null;
            return null;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("createRoleBasedMatrix")]
        [System.Web.Http.Route("api/role/createRoleBasedMatrix")]
        public int createRoleBasedMatrix(roleBasedMatrixEntities px)
        {
            return _pServices.CreateMatrix(px);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.ActionName("updateRoleBasedMatrix")]
        [System.Web.Http.Route("api/role/updateRoleBasedMatrix/{ID}")]
        public bool updateRoleBasedMatrix(int ID, roleBasedMatrixEntities px)
        {
            if (ID > 0)
                return _pServices.UpdateMatrix(ID, px);
            return false;
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.ActionName("updateRoleBasedMatrixCategory")]
        [System.Web.Http.Route("api/role/updateRoleBasedMatrixCategory/{ID}")]
        public bool updateRoleBasedMatrixCategory(int ID, roleBasedMatrixEntities px)
        {
            if (ID > 0)
                return _pServices.UpdateMatrixCategory(ID, px);
            return false;
        }

        [HttpDelete]
        [ActionName("deleteRoleBasedMatrix")]
        [Route("api/role/deleteRoleBasedMatrix/{ID}")]
        public bool deleteRoleBasedMatrix(int ID)
        {
            if (ID > 0)
                return _pServices.DeleteMatrix(ID);
            return false;
        }


    }
}
