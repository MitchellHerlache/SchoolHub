using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHub.Models
{
    public class EventHomeModel
    {
        public User User { get; set; }
        public Class Class { get; set; }
        public List<Class> Classes { get; set; }
        public List<Event> Events { get; set; }
        public List<SelectItem> EventTypes { get; set; }
    }
}