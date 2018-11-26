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
            Class TempClass = new Class();
            EventHomeModel model = new EventHomeModel
            {
                //TempClass.Id = ClassId,
                Classes = new List<Class>(),
                Events = db.GetEventsByClassId(ClassId),
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

        public ActionResult AddEvent()
        {
            SchoolhubDb db = new SchoolhubDb();
            EventHomeModel model = new EventHomeModel
            {
                EventTypes = db.GetAllEventTypes(),
            };
            return View(model);
          //  return View();
        }
    }
}