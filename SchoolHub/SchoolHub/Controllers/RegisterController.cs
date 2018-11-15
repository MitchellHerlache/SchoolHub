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
        public ActionResult RegisterIndex()
        {
            return View();
        }
        // GET: Register
        public JsonResult RegisterUser(User inUser, string password)
        {   
            SchoolhubDb db = new SchoolhubDb();
            User user = inUser;
            string result = db.AddUser(inUser, password);
            if(int.TryParse(result, out int x))
            {
                user.Id = int.Parse(result);
                return Json(new { message = "", user = user });
            }
            return Json(new { message = result, user = user });
        }

        //public ActionResult RegisterUser(User user, string password)
        //{
        //    if (user.Email != null || password != null)
        //    {
        //        SchoolhubDb db = new SchoolhubDb();
        //        User newUser = user;
        //        newUser.Id = int.Parse(db.AddUser(user, password));
        //        if (newUser.RoleId == 1)
        //        {
        //            TeacherHomeModel model = new TeacherHomeModel
        //            {
        //                Classes = db.GetClassesByTeacherId(newUser.Id),
        //                Events = new List<Event>(),
        //                Schools = new List<SelectItem>(),
        //                User = newUser
        //            };
        //            return View(model);
        //        } else if (newUser.RoleId == 2)
        //        {
        //            StudentHomeModel thisModel = new StudentHomeModel();
        //            return View(thisModel);
        //        }
        //    }    
        //    return View();
        //}
    }
}