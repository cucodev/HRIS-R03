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
            ViewBag.menuForm = "Active";
            return View(User);
        }

        public ActionResult Medical()
        {
            //ViewBag.menuForm = "Active";
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
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult vMap()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult MyIdentity()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult Calendar()
        {
            ViewBag.menuCalendar = "Active";
            return View(User);
        }

        public ActionResult Timesheet()
        {
            ViewBag.menuTimesheet = "Active";
            return View(User);
        }

        public ActionResult Mailbox()
        {
            ViewBag.menuMailbox = "Active";
            return View(User);
        }

        public ActionResult MailboxDetail()
        {
            return View(User);
        }

        public ActionResult MyDependent()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult MyMatrix()
        {
            ViewBag.MenuMyMatrix = "active";
            return View(User);
        }

        public ActionResult Notifications()
        {
            return View(User);
        }

        public ActionResult Temp()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult MyEducation()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult MyTraining()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult MyLanguage()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult MySkill()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult MyCertification()
        {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

        public ActionResult Structure() {
            ViewBag.menuProfile = "Active";
            return View(User);
        }

    }
}