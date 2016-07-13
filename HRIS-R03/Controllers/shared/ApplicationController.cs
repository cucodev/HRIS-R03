using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessServices;

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

       

    }
}