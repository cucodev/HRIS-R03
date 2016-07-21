using BusinessEntities;
using BusinessEntities.CrudEntities;
using HRIS_R03.Controllers.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R03.Controllers
{
    public class ContentController : ApplicationController<LogOnModel>
    {
        
        
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vProfile()
        {

            //profileEntities dt = new ViewData["UserCred"] as profileEntities();

            var dt = (UserCredModel)Session[GlobalVariable.UserCred];
            // ViewBag.cUser = dt.cUser;
            ViewBag.cIDV = dt.IDV;
            ViewBag.cIDVParent = dt.parentIDV;
            /*ViewBag.cIDVParentLevel = dt.cIDParentLevel;
            ViewBag.cName = dt.cName;
            ViewBag.cNickName = dt.cNickName;
            ViewBag.cNIP = dt.cNIP;
            ViewBag.cEmpPosition = dt.cEmpPosition;
            ViewBag.cEmpJobLevel = dt.cEmpJobLevel;
            ViewBag.cEmpDivision = dt.cEmpDivision;
            ViewBag.cEmpDepartement = dt.cEmpDepartement;
            ViewBag.cEmpOfficeLocation = dt.cEmpOfficeLocation; */

            return View();
        }
    }
}