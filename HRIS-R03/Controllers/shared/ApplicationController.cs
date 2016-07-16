using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
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
        private const string UserCred = "UserCred";
        private const string ParentList = "ParentList";

        private readonly Isecurity _pServices;

        //private 
        //private MasterHRISEntities db = new MasterHRISEntities();

        //private EmployeeEntities dbEmp = new EmployeeEntities();
        //private UserEntities dbUser = new UserEntities();

        protected ApplicationController()
        {
            _pServices = new SecurityClass();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            /*important to check both, because logOnController should be access able with out any session*/
            if (!IsNonSessionController(requestContext) && !HasSession())
            {
                Rederect(requestContext, Url.Action(LogOnAction, LogOnController));
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

        public bool SetUserSession(LogOnModel model,int id)
        {
            try
            {
                profileEntities data = new profileEntities();
                if (model.RememberMe)
                {
                    var ASPCookie = Request.Cookies["LogOnSession"];
                    // var FormCookie = Request.Cookies[""]
                    ASPCookie.Expires = DateTime.Now.AddDays(1);
                    Response.SetCookie(ASPCookie);
                }
                System.Diagnostics.Debug.WriteLine("Set User Session :: LogOn Model Username: " + model.UserName);

                //Get User Profile
                data = _pServices.getProfile(id);
                //Pass User as ViewData & Session
                ViewData[UserCred] = data;
                Session[UserCred] = data;

                var dt = data;
                    //ViewBag.cUser = x.IDV;
                    ViewBag.cIDV = dt.IDV;
                    ViewBag.cIDVParent = dt.parentIDV;
                    ViewBag.cIDVParentLevel = 0;
                    ViewBag.cName = dt.Name;
                    ViewBag.cNickName = dt.NickName;
                    ViewBag.cNIP = dt.NIP;
                    ViewBag.cEmpPosition = dt.JobPosition;
                    ViewBag.cEmpJobLevel = dt.JobLevel;
                    ViewBag.cEmpDivision = dt.JobDivision;
                    ViewBag.cEmpDepartement = dt.JobDepartement;
                    ViewBag.cEmpOfficeLocation = dt.JobLocation;
                
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