using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHub.Models
{
    public class TeacherHomeModel
    {
        public List<SelectItem> Schools { get; set; }
        public List<Class> Classes { get; set; }
        public List<Event> Events { get; set; }
    }
}