using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
//using DataModel;
//using DataModel.UnitOfWork;
using HRIS_R03.Controllers.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HRIS_R03.Controllers
{
    
    public class AdminController : ApplicationController<LogOnModel>
    {
        //private readonly UnitOfWork _u;

        
        public new UserCredModel User;
        public readonly IUser _p;
       
        public AdminController()
        {
            _p = new UserServices();
            adminRole();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult  UserManagement()
        {
           
            //if (User.role != 3) RedirectToAction("Content", "Dashboard");
            var UserDetail = _p.getUsers();
               
            ViewBag.UserDetail = UserDetail;

            return View(User);
        }
    }
}