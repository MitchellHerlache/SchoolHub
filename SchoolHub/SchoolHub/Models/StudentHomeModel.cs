using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolHub.Infrastructure.Containers;

namespace SchoolHub.Models
{
    public class StudentHomeModel
    {
        public List<Class> Classes { get; set; }
        public List<Event> Events { get; set; }

        public StudentHomeModel()
        {
            Classes = new List<Class>();
            Events = new List<Event>();

            // BELOW IS EXAMPLE DATA TO BE DELETED AFTER ZFR //

            Class tempClass = new Class();
            tempClass.Id = 0;
            tempClass.Number = "101";
            tempClass.Name = "Physics 101";
            tempClass.Description = "Introduction to Physics";
            tempClass.StartDate = DateTime.Now;
            tempClass.EndDate = DateTime.Now.AddDays(30);
            tempClass.TeacherId = 0;
            tempClass.TeacherName = "Jane Doe";
            tempClass.SchoolId = 0;
            tempClass.SchoolName = "UW - Oshkosh";

            Classes.Add(tempClass);
            tempClass = new Class();

            tempClass.Id = 1;
            tempClass.Number = "341";
            tempClass.Name = "CS 341";
            tempClass.Description = "Software Engineering I";
            tempClass.StartDate = DateTime.Now;
            tempClass.EndDate = DateTime.Now.AddDays(30);
            tempClass.TeacherId = 1;
            tempClass.TeacherName = "John Doe";
            tempClass.SchoolId = 0;
            tempClass.SchoolName = "UW - Oshkosh";

            Classes.Add(tempClass);
            tempClass = new Class();

            tempClass.Id = 2;
            tempClass.Number = "300";
            tempClass.Name = "CS 300";
            tempClass.Description = "Artificial Intelligence";
            tempClass.StartDate = DateTime.Now;
            tempClass.EndDate = DateTime.Now.AddDays(30);
            tempClass.TeacherId = 0;
            tempClass.TeacherName = "Jane Doe";
            tempClass.SchoolId = 0;
            tempClass.SchoolName = "UW - Oshkosh";

            Classes.Add(tempClass);

            Event tempEvent = new Event();

            tempEvent.Id = 0;
            tempEvent.Description = "A Zero Feature Release of group project.";
            tempEvent.StartDate = new DateTime(2018, 10, 27);
            tempEvent.EndDate = new DateTime(2018, 11, 7);
            tempEvent.ClassId = 1;
            tempEvent.UserId = 0;
            tempEvent.TypeId = 2;
            tempEvent.Type = "Project";

            Events.Add(tempEvent);
            tempEvent = new Event();

            tempEvent.Id = 1;
            tempEvent.Description = "Exam 2";
            tempEvent.StartDate = new DateTime(2018, 11, 8);
            tempEvent.EndDate = new DateTime(2018, 11, 8);
            tempEvent.ClassId = 2;
            tempEvent.UserId = 0;
            tempEvent.TypeId = 1;
            tempEvent.Type = "Exam";

            Events.Add(tempEvent);
            tempEvent = new Event();

            tempEvent.Id = 2;
            tempEvent.Description = "Do problems 1-25 for 4.2";
            tempEvent.StartDate = new DateTime(2018, 11, 1);
            tempEvent.EndDate = new DateTime(2018, 11, 9);
            tempEvent.ClassId = 0;
            tempEvent.UserId = 0;
            tempEvent.TypeId = 0;
            tempEvent.Type = "Assignment";

            Events.Add(tempEvent);
            tempEvent = new Event();

            tempEvent.Id = 3;
            tempEvent.Description = "Lab Write up for Lab 7";
            tempEvent.StartDate = new DateTime(2018, 11, 5);
            tempEvent.EndDate = new DateTime(2018, 11, 12);
            tempEvent.ClassId = 0;
            tempEvent.UserId = 0;
            tempEvent.TypeId = 0;
            tempEvent.Type = "Assignment";

            Events.Add(tempEvent);
        }
    }
}