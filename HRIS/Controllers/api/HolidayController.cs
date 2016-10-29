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

        // GET: api/holiday
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getAll")]
        [System.Web.Http.Route("api/holiday")]
        public IEnumerable<holidayEntities> getAll()
        {
            return _pServices.getAll();
        }

        // POST api/holiday
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("create")]
        [System.Web.Http.Route("api/holiday")]
        public int create(holidayEntities hEntity)
        {
            return _pServices.post(hEntity);
        }

        // PUT api/holiday/5
        [System.Web.Http.HttpPut]
        [System.Web.Http.ActionName("update")]
        [System.Web.Http.Route("api/holiday")]
        public bool update(int id, holidayEntities hEntity)
        {
            System.Diagnostics.Debug.WriteLine("apiConsole: holidayEntities", hEntity);
            if (id > 0)
            {
                return _pServices.put(id, hEntity);
            }
            return false;
        }

        // DELETE api/holiday/5
        [System.Web.Http.HttpDelete]
        [System.Web.Http.ActionName("delete")]
        [System.Web.Http.Route("api/holiday")]
        public bool delete(int id)
        {
            if (id > 0)
                return _pServices.delete(id);
            return false;
        }

    }
}
