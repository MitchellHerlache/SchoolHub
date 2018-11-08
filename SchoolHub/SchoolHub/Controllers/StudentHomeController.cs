using SchoolHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolHub.Controllers
{
    public class StudentHomeController : Controller
    {
        public ActionResult StudentHomeIndex()
        {
            StudentHomeModel thisModel = new StudentHomeModel();
            return View(thisModel);
        }

        
    }
}