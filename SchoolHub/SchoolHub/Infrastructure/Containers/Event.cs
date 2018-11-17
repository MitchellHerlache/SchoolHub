using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolHub.Infrastructure.Containers
{
    public class Event
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartDateString => StartDate.ToShortDateString();
        public string EndDateString => EndDate == null ? null : EndDate.Value.ToShortDateString();
        public int? ClassId { get; set; }
        public int? UserId { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
    }
}
