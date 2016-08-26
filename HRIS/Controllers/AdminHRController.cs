using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using HRIS_R03.Controllers.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R03.Controllers
{
    public class AdminHRController : ApplicationController<LogOnModel>
    {
        private readonly IManageRoleBasedMatrix _pServices;
        public new UserCredModel User;
        private int cIDV;

        public AdminHRController()
        {
            _pServices = new RoleBasedMatrixServices();
            User = UserVariable.User;
        }

        
        
        private void current()
        {
            if (Session[GlobalVariable.UserCred] != null)
            {
                var dt = (UserCredModel)Session[GlobalVariable.UserCred];
                cIDV = 3;
                ViewBag.cIDV = 3;//dt.IDV;
                ViewBag.cIDVParent = 40;// dt.parentIDV;
            }
        }

        public ActionResult Employee()
        {

            return View(User);
        }

        public ActionResult Approval()
        {
            return View(User);
        }

        // GET: AdminHR
        public ActionResult Index()
        {
            return RedirectToAction("MaintainData"); //View();
        }

        public ActionResult MaintainData()
        {
            ViewBag.menuAdminHRD = "Active";
            return View(User);
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult EmployeeManagement()
        {
            ViewBag.menuAdminHRD = "Active";
            return View(User);
        }

        public ActionResult Notifications()
        {
            return View(User);
        }


        //Calculate Role to Employee, JobLevel != null
        [HttpPost]
        public ActionResult Calculate()
        {
            
            var p = _pServices.CalculateMatrix(cIDV);
            return RedirectToAction("MaintainData");
        }

        public ActionResult FileManagement()
        {
            ViewBag.menuAdminHRD = "Active";
            return View(User);
        }
    }
}