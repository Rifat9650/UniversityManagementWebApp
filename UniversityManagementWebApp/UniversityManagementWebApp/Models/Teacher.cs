using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Teacher
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Contact Number")]
        public string ContactNumber { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Designation")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Enter How Much Credit You Want To Take")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Negative Credit Is Not Allowed")]
        [Display(Name = "Credit To Be Taken")]
        public double TotalCredit { get; set; }
        public double RemainingCredit { get; set; }
    }
}