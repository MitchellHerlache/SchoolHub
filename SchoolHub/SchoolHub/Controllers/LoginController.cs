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
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckUserLogin(string username, string password)
        {
            User user = this.db.GetUserByUsernamePassword(username, password);
            if(user == null)
            {
                return Json(new {message = "Incorrect username or password" });
            }
            return Json(new { message = "", user = user });

        }

        public ActionResult LoginUser(User user)
        {
            if(user.RoleId == 1)
            {
                return RedirectToAction("Index", "TeacherHome", new { user = user });
            }
            return RedirectToAction("Index", "StudentHome");
        }
    }
}