using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class CourseEnroll
    {
        public int Id { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Student")]
        public int StudentId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        
        public string DepartmentName { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Course")]
        public int CourseId { get; set; }
        public string CourseGrade { get; set; }
        public int Flag { get; set; }
    }
}