using BusinessEntities;
using BusinessEntities.CrudEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Controllers
{
    public class ErrorController : Controller
    {
        public new UserCredModel User;

        
        public ErrorController()
        {
            User = UserVariable.User;
        }

        // GET: Error
        public ActionResult NotAllowed()
        {
            return View(User);
        }
    }
}