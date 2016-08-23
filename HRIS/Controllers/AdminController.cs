using BusinessEntities;
using BusinessEntities.CrudEntities;
using DataModel;
using DataModel.UnitOfWork;
using HRIS_R03.Controllers.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R03.Controllers
{
    
    public class AdminController : ApplicationController<LogOnModel>
    {
        private readonly UnitOfWork _u;
        public new UserCredModel User;

       
        public AdminController()
        {
            _u = new UnitOfWork();
            User = UserVariable.User;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult  UserManagement()
        {
            if (User.role != 3) RedirectToAction("Content", "Dashboard");
            var UserDetail = _u.userRepository.Get().ToList();
            ViewBag.UserDetail = UserDetail;
            return View(User);
        }
    }
}