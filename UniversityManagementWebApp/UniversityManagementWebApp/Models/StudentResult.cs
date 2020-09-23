using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }

        //public string CourseCode { get; set; }
        //public string CourseName { get; set; }
        //[RegularExpression("[0-9]",ErrorMessage = "Select a Grade")]
        public string CourseGrade { get; set; }
    }
}