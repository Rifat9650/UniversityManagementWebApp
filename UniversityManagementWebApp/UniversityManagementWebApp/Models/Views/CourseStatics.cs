using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models.Views
{
    public class CourseStatics
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int Semester { get; set; }
        public string Assigned { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}