using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Write Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Write Student Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Write Student Contact Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Write Student Address")]
        public string Address { get; set; }
        public string RegistrationNo { get; set; }
        [Required(ErrorMessage = "Please Select Student Separtment")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}