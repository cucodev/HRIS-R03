using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
//using HRIS_R03.Models;

namespace HRIS_R03.Controllers.shared
{
    public class ApplicationController<TSource> : Controller
    {
        private const string LogOnSession = "LogOnSession";
        private const string ErrorController = "Error";
        private const string LogOnController = "Default";
        private const string LogOnAction = "Index";
        private const string UserCred = GlobalVariable.UserCred;
        private const string ParentList = "ParentList";

        private const int roleAdmin = 15;
        private const int roleHRD = 10;
        private const int roleSuperior = 5;
        private const int roleUser = 1;

        public new UserCredModel User;
        public RequestContext CurrentRequestContext;

        private readonly Isecurity _pServices;

        //private 
        //private MasterHRISEntities db = new MasterHRISEntities();

        //private EmployeeEntities dbEmp = new EmployeeEntities();
        //private UserEntities dbUser = new UserEntities();

        protected ApplicationController()
        {
            _pServices = new SecurityServices();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            CurrentRequestContext = requestContext;

            ViewData[UserCred] = null;
            Session[UserCred] = null;

            /*important to check both, because logOnController should be access able with out any session*/
            if (!IsNonSessionController(requestContext) && !HasSession())
            {
                Rederect(requestContext, Url.Action(LogOnAction, LogOnController));
            } else
            {
                if (UserVariable.User != null)
                {
                    System.Diagnostics.Debug.WriteLine("CurrentRequestContext:", CurrentRequestContext);
                    System.Diagnostics.Debug.WriteLine("User Role: ", UserVariable.User.role);
                }
            }
        }

        //PageSection
        public void adminRole()
        {
            User = UserVariable.User;
            if (User != null)
            {
                System.Diagnostics.Debug.WriteLine("Name: " + User.Name.Trim() + ", Role:" + User.role);
                if (User.role != 3)
                {
                    System.Diagnostics.Debug.WriteLine("Role Not Allowed");
                    //Rederect(CurrentRequestContext, Url.Action("Error", "NotAllowed"));
                    RedirectToAction("Error", "NotAllowed");
                }
            }
        }

        private bool IsNonSessionController(RequestContext requestContext)
        {
            var currentController = requestContext.RouteData.Values["controller"].ToString().ToLower();
            var nonSessionedController = new List<string>() { ErrorController.ToLower(), LogOnController.ToLower() };
            return nonSessionedController.Contains(currentController);
        }

        private void Rederect(RequestContext requestContext, string action)
        {
            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.Redirect(action);
            requestContext.HttpContext.Response.End();
        }
        
        protected bool HasSession()
        {
            return Session[LogOnSession] != null;
        }

        protected TSource GetLogOnSessionModel()
        {
            return (TSource)this.Session[LogOnSession];
        }

        public bool SetUserSession(LogOnModel model,int IDV)
        {
            try
            {
                UserCredModel data = new UserCredModel();
                if (model.RememberMe)
                {
                    var ASPCookie = Request.Cookies["LogOnSession"];
                    // var FormCookie = Request.Cookies[""]
                    ASPCookie.Expires = DateTime.Now.AddDays(1);
                    Response.SetCookie(ASPCookie);
                }
                System.Diagnostics.Debug.Write("Application COntroller: ");
                System.Diagnostics.Debug.WriteLine("Username: " + model.UserName + ", Password: " + model.Password + "IDV: " + model.IDV);

                //Get User Profile
                data = _pServices.getUserCred(IDV);
                ViewData[UserCred] = data;
                Session[UserCred] = data;
                UserVariable.User = data;
                try
                {
                    ViewBag.cIDV = data.IDV;
                    ViewBag.cIDVMail = data.IDVMail;
                    ViewBag.cIDVParent = data.parentIDV;
                    ViewBag.cIDVParentMail = data.parentIDVMail;
                    ViewBag.cName = data.Name;
                    ViewBag.cRole = data.role;
                    ViewBag.cTimeLogin = data.timeLogin;
                } catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Set Viewbag Error : ", e.Message);
                }
                
                return true;
            } catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + x.Message);
                return false;
            }
            
            
        }

        protected void SetLogOnSessionModel(TSource model)
        {
            Session[LogOnSession] = model;
        }

       
        protected void AbandonSession()
        {
            if (HasSession())
            {
                Session.Abandon();

                //Session["UserCred"]
            }
        }

    }
}