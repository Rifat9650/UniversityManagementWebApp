using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models.Views
{
    public class StudentCourseWiseResult
    {
        public int StudentId { get; set; }
        public string CourseGrade { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Flag { get; set; }
    }
}