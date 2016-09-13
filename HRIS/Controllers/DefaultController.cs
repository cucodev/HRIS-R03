using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using HRIS_R03.Controllers.shared;
using System;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace HRIS_R03.Controllers
{
    public class DefaultController : ApplicationController<LogOnModel>
    {
        private readonly Isecurity _pSecurity;

        public DefaultController()
        {
            _pSecurity = new SecurityServices();
        }

       

        // GET: Default
        public ActionResult Index()
        {
            return this.RedirectToAction("LogOn", "Default");
        }

        public ActionResult LogOn()
        {
            return View();
        }

       // [HttpPost]
        public ActionResult LogOff()
        {
            AbandonSession();
            return RedirectToAction("LogOn");
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            System.Diagnostics.Debug.WriteLine("Try to Login with username: " + model.UserName);

            
                int current = _pSecurity.isExist(model);
                if ( current < 0) {
                    ViewBag.Msg = "The user name provided is incorrect, please register";
                    return View(model);
                } else
                {
                    
                    SetLogOnSessionModel(model);
                    LogOnModel sessionModel = GetLogOnSessionModel();
                    try
                    {
                        //if (true == AuthenticateUser(model.UserName, model.Password, out Msg))
                        System.Diagnostics.Debug.WriteLine("3 LogOn Model Username: " + model.UserName + ", IDV= " + current);
                        if (true == _pSecurity.AuthenticateLocal(model))
                        {
                            
                            if (true == SetUserSession(model, current))
                            {
                                ViewBag.Msg = "Login OK";
                                System.Diagnostics.Debug.WriteLine("Login OK");
                                return this.RedirectToAction("MyProfile", "Content");
                            }
                            else
                            {
                                ViewBag.Msg = "Unable to Set User Caching, Contact Web Administrator";
                                return View(model);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        ViewBag.Msg = " Error : " + e.Message;
                        return View(model);
                    }
                


            }
            //return this.RedirectToAction("Logon", "Default");
            return View(model);
        }

    }
}