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
    }
}