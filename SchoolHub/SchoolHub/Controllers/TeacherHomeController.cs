using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Models;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHub.Controllers
{
    public class TeacherHomeController : Controller
    {
        // GET: TeacherHome
        // View(model) returns a user with an id, username, etc. 
        public ActionResult TeacherHomeIndex(int userId)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUserId(userId);
            TeacherHomeModel model = new TeacherHomeModel
            {
                Classes = db.GetClassesByTeacherId(user.Id),
                Events = new List<Event>(),
                Schools = new List<SelectItem>(),
                User = user
            };
            return View(model);
        }
        
        public ActionResult AddClass(int userId)
        {
            TeacherHomeModel model = new TeacherHomeModel();
            User user = new User();
            user.Id = userId;
            model.User = user;
            return View(model);
        }

        public JsonResult AddNewClass(Class inClass)
        {
           SchoolhubDb db = new SchoolhubDb();
           bool result = db.AddClass(inClass);
           if (result == true)
           {
              return Json(new { message = ""});
         } else
         {
              return Json(new { message = result});
         }
        }

        public ActionResult ChangePassword(int userId)
        {
            TeacherHomeModel model = new TeacherHomeModel();
            User user = new User();
            user.Id = userId;
            model.User = user;
            return View(model);
        }

        public JsonResult RegisterUser(User inUser, string password)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = inUser;
            string result = db.AddUser(inUser, password);
            if (int.TryParse(result, out int x))
            {
                user.Id = int.Parse(result);
                return Json(new { message = "", user = user });
            }
            return Json(new { message = result, user = user });
        }
    }
}