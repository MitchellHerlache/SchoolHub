using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Infrastructure.Containers;
using SchoolHub.Models;

namespace SchoolHub.Controllers
{
    public class LoginController : Controller
    {
        SchoolhubDb db = new SchoolhubDb();
        public ActionResult LoginIndex()
        {
            return View();
        }

        public JsonResult CheckUserLogin(string username, string password)
        {
            int userId = this.db.GetUserIdByUsernamePassword(username, password);
            if(user == null)
            {
                return Json(new {message = "Incorrect username or password" });
            }
            return Json(new { message = "", userId = userId });

        }

        public ActionResult LoginUser(User user)
        {
            if(user.RoleId == 1)
            {
                return RedirectToAction("TeacherHomeIndex", "TeacherHome", new { user = user });
            }
            return RedirectToAction("StudentHomeIndex", "StudentHome");
        }
    }
}