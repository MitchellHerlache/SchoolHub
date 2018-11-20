
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