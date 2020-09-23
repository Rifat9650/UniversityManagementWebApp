using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class CourseAssign
    {
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Teacher")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Course")]
        public int CourseId { get; set; }
        //[Display(Name = "Credit to be taken")]
        public double CourseCredit { get; set; }
        public double RemainingCredit { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public double Credit { get; set; }
    }
}