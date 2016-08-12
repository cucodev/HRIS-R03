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
    public class ContentController : ApplicationController<LogOnModel>
    {
        public new UserCredModel User;

        public ContentController()
        {
            User = UserVariable.User;
        }
        
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Leave()
        {
            return View(User);
        }

        public ActionResult vLeave()
        {
            //current();
            return View(User);
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult vProfile()
        {
            return View(User);
        }

        public ActionResult vMap()
        {
            return View();
        }

        public ActionResult MyIdentity()
        {
            return View(User);
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Timesheet()
        {
            return View();
        }

        public ActionResult Mailbox()
        {
            return View(User);
        }

        public ActionResult MailboxDetail()
        {
            return View(User);
        }

        public ActionResult MyDependent()
        {
            return View();
        }

        public ActionResult MyMatrix()
        {
            ViewBag.cIDV = 3;//dt.IDV;
            ViewBag.cIDVParent = 40;// dt.parentIDV;
            ViewBag.cIDVLevel = 71;
            return View();
        }

        public ActionResult Temp()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return View(User);
        }

        public ActionResult MyDependentBeta()
        {
            return View(User);
        }

        public ActionResult MyEducation()
        {
            return View(User);
        }

        public ActionResult MyTraining()
        {
            return View(User);
        }

        public ActionResult MyLanguage()
        {
            return View(User);
        }

        public ActionResult MySkill()
        {
            return View(User);
        }

        public ActionResult MyCertification()
        {
            return View(User);
        }

    }
}