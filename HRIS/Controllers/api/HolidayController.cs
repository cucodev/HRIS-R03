using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRIS.Controllers.api
{
    public class HolidayController : ApiController
    {
        private readonly IHoliday _pServices;
        public new UserCredModel User;

        public HolidayController()
        {
            _pServices = new HolidayServices();
            User = UserVariable.User;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getHoliday")]
        [System.Web.Http.Route("api/holiday")]
        public IEnumerable<holidayEntities> getHoliday()
        {
            return _pServices.getAll();
        }

    }
}
