using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Models;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHub.Controllers
{
    public class StudentHomeController : Controller
    {
        public ActionResult StudentHomeIndex(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUserId(userId);
            
            StudentHomeModel thisModel = new StudentHomeModel()
            {
                User = user,
                Events = db.GetEventsByStudentId(user.Id),
                Classes = db.GetClassesByStudentId(user.Id)
            };

            return View(thisModel);
        }

        public ActionResult StudentCalendar(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUserId(userId);

            StudentHomeModel thisModel = new StudentHomeModel()
            {
                User = user,
                Events = db.GetEventsByStudentId(user.Id),
                Classes = db.GetClassesByStudentId(user.Id)
            };

            return View(thisModel);
        }
        public ActionResult AddStudentEvent(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUserId(userId);

            ClassHomeModel model = new ClassHomeModel()
            {
                User = user,
                Classes = db.GetClassesByStudentId(userId),
                Schools = db.GetAllSchools(),
                EventTypes = db.GetAllEventTypes()
            };

            return View(model);
        }

        public JsonResult NewStudentEvent(Event InEvent)
        {
            SchoolhubDb db = new SchoolhubDb();
            bool result = db.AddStudentEvent(InEvent);

            if (result == true)
            {
                return Json(new { message = "" });
            }
            else
            {
                return Json(new { message = result });
            }
        }

        public ActionResult Classes(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();

            ClassHomeModel model = new ClassHomeModel()
            {
                Classes = db.GetClassesByStudentId(userId),
                Schools = db.GetAllSchools()
            };

            return View(model);
        }
        
        public ActionResult AddDropClass(int userId, int classId = -1)
        {
            SchoolhubDb db = new SchoolhubDb();

            if (classId > 0)
            {
                bool result = db.RemoveStudentFromClass(userId, classId);
            }

            User user = db.GetUserByUserId(userId);

            ClassHomeModel model = new ClassHomeModel()
            {
                User = user,
                Classes = db.GetUnenrolledClassesByStudentId(userId),
                EnrolledClasses = db.GetClassesByStudentId(userId),
                Schools = db.GetAllSchools()
            };
            return View(model);
        }

        public JsonResult DropStudentClass(int userId, int ClassId)
        {
            SchoolhubDb db = new SchoolhubDb();
            bool result = db.RemoveStudentFromClass(userId, ClassId);

            if (result == true)
            {
                return Json(new { message = "" });
            }
            else
            {
                return Json(new { message = result });
            }
        }

        public JsonResult EnrollStudentInClass(int userId, int ClassId)
        {
            SchoolhubDb db = new SchoolhubDb();
            bool result = db.EnrollStudentInClass(userId, ClassId);

            if (result == true)
            {
                return Json(new { message = "" });
            }
            else
            {
                return Json(new { message = result });
            }
        }

        public bool DropClass(int userId, int classId)
        {
            SchoolhubDb db = new SchoolhubDb();
            return db.RemoveStudentFromClass(userId, classId);
        }

        public bool AddClass(int userId, int classId)
        {
            SchoolhubDb db = new SchoolhubDb();
            return db.EnrollStudentInClass(userId, classId);
        }        
    }
}