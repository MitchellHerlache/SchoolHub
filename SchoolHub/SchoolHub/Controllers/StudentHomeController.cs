
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
            /*
            StudentHomeModel thisModel = new StudentHomeModel()
            {
                User = user,
                Events = db.GetEventsByStudentId(user.Id),
                Classes = db.GetClassesByStudentId(user.Id)
            };*/

            // being used to test the filter, switch back to other after.
            StudentHomeModel thisModel = new StudentHomeModel()
            {
                User = user
            };

            return View(thisModel);
        }

        public ActionResult StudentCalendar(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUserId(userId);

            /*
            StudentHomeModel thisModel = new StudentHomeModel()
            {
                User = user,
                Events = db.GetEventsByStudentId(user.Id),
                Classes = db.GetClassesByStudentId(user.Id)
            };*/

            StudentHomeModel thisModel = new StudentHomeModel()
            {
                User = user
            };

            return View(thisModel);
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

        public ActionResult AddDropClass(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUserId(userId);
            ClassHomeModel model = new ClassHomeModel()
            {
                User = user,
                Classes = db.GetAllClasses(),
                Schools = db.GetAllSchools()
            };
            return View(model);
        }

        public ActionResult AddStudentClass(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUserId(userId);
            ClassHomeModel model = new ClassHomeModel()
            {
                User = user,
                Classes = db.GetAllClasses(),
                Schools = db.GetAllSchools()
            };
            return View(model);
        }

        public JsonResult DropStudentClass(Class inClass)
        {
            SchoolhubDb db = new SchoolhubDb();
            bool result = db.AddClass(inClass);
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
            //User theUser = user;
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