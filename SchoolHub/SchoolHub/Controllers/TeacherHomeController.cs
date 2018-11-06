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
        public ActionResult Index(User user)
        {
            SchoolhubDb db = new SchoolhubDb();
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