using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R03.Controllers
{
    public class AdminHRController : Controller
    {
        private readonly IManageRoleBasedMatrix _pServices;

        public AdminHRController()
        {
            _pServices = new RoleBasedMatrixServices();
        }
        // GET: AdminHR
        public ActionResult Index()
        {
            return RedirectToAction("MaintainData"); //View();
        }

        public ActionResult MaintainData()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult EmployeeManagement()
        {
            return View();
        }


        //Calculate Role to Employee, JobLevel != null
        [HttpPost]
        public ActionResult Calculate()
        {
            var p = _pServices.CalculateMatrix();
            return RedirectToAction("MaintainData");
        }
    }
}