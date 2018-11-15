using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Models;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHub.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        //public ActionResult RegisterIndex()
        //{
        //    return View();
        //}

        public ActionResult RegisterIndex(User user, string password)
        {
            if (user.Email != null || password != null)
            {
                SchoolhubDb db = new SchoolhubDb();
                User newUser = user;
                newUser.Id = int.Parse(db.AddUser(user, password));
                if (newUser.RoleId == 1)
                {
                    TeacherHomeModel model = new TeacherHomeModel
                    {
                        Classes = db.GetClassesByTeacherId(newUser.Id),
                        Events = new List<Event>(),
                        Schools = new List<SelectItem>(),
                        User = newUser
                    };
                    return View(model);
                } else if (newUser.RoleId == 2)
                {
                    StudentHomeModel thisModel = new StudentHomeModel();
                    return View(thisModel);
                }
            }    
            return View();
        }

        //public ActionResult TeacherHomeIndex(int userId)
        //{
        //    SchoolhubDb db = new SchoolhubDb();
        //    User user = db.GetUserByUserId(userId);
        //    TeacherHomeModel model = new TeacherHomeModel
        //    {
        //        Classes = db.GetClassesByTeacherId(user.Id),
        //        Events = new List<Event>(),
        //        Schools = new List<SelectItem>(),
        //        User = user
        //    };
        //    return View(model);
        //}


    }
}