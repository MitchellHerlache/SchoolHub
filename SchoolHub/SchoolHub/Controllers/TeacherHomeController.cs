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
        public ActionResult Index(string username)
        {
            SchoolhubDb db = new SchoolhubDb();
            string usersname = username.Split(':')[0];
            string password = username.Split(':')[1];
            User user = db.GetUserByUsernamePassword(usersname, password);
            TeacherHomeModel model = new TeacherHomeModel
            {
                Classes = db.GetClassesByTeacherId(user.Id),
                Events = new List<Event>(),
                Schools = new List<SelectItem>(),
                User = user
            };
            return View(model);
        }
    }
}