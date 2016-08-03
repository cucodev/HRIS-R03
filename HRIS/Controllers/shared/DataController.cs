using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using System.Web.Services;

namespace HRIS.Controllers.shared
{
    public class DataController : Controller
    {

        private readonly IManageRoleBasedMatrix _pServices;

        public DataController()
        {
            _pServices = new RoleBasedMatrixServices();// ProductServices();
        }

        [WebMethod]
        public void CalculateYears()
        {
            var p = _pServices.CalculateMatrix(3);
            //return View();
        }
    }
}