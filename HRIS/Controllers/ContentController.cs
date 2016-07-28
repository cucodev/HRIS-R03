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
    public class ContentController : Controller //ApplicationController<LogOnModel>
    {
        
       
        private void current()
        {
            if (Session[GlobalVariable.UserCred] != null)
            {
                var dt = (UserCredModel)Session[GlobalVariable.UserCred];
                ViewBag.cIDV = dt.IDV;
                ViewBag.cIDVParent = dt.parentIDV;
            }
        }
        
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vLeave()
        {
            current();
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult vProfile()
        {
            current();
            return View();
        }

        public ActionResult vMap()
        {
            current();
            return View();
        }
        
    }
}