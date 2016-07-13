using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R03.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {

           // ViewBag.cUser = dt.cUser;
            ViewBag.cIDV = 3;
            ViewBag.cIDVParent = 40;
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