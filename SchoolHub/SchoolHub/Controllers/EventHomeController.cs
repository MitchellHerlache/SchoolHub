using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Models;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHub.Controllers
{
    public class EventHomeController : Controller
    {
        public ActionResult EventHome(int ClassId)
        {
            SchoolhubDb db = new SchoolhubDb();

            //User user = db.GetUserByUserId(userId);
            Class TempClass = new Class
            {
                Id = ClassId
            };
            EventHomeModel model = new EventHomeModel
            {
                //TempClass.Id = ClassId,
                Class = TempClass,
                Classes = new List<Class>(),
                Events = db.GetEventsByClassId(TempClass.Id),
            };
            return View(model);
        }

        public JsonResult AddNewEvent(Event InEvent)
        {
           SchoolhubDb db = new SchoolhubDb();
           bool result = db.AddClassEvent(InEvent);
           if (result == true)
           {
              return Json(new { message = ""});
         } else
         {
              return Json(new { message = result});
         }
        }

        public ActionResult AddEvent(int ClassId)
        {
            SchoolhubDb db = new SchoolhubDb();
            Class TempClass = new Class
            {
                Id = ClassId
            };
            EventHomeModel model = new EventHomeModel
            {
                Class = TempClass,
                EventTypes = db.GetAllEventTypes(),
            };
            return View(model);
        }
    }
}