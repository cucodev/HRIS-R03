using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R03.Controllers
{
    public class AdminHRController : Controller
    {
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
    }
}