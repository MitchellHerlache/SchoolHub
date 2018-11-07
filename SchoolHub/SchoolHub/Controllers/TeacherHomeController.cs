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
        public ActionResult Index(string username, string password)
        {
            SchoolhubDb db = new SchoolhubDb();
            User user = db.GetUserByUsernamePassword(username, password);
            TeacherHomeModel model = new TeacherHomeModel
            {
                Classes = db.GetClassesByTeacherId(user.Id),
                Events = null,
                Schools = null,
                User = user
            };
            return View(model);
        }
    }
}