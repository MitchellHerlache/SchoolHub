using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolHub.Infrastructure.Containers
{
    public class Class
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateString => StartDate.ToShortDateString();
        public string EndDateString => EndDate.ToShortDateString();
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
    }
}
