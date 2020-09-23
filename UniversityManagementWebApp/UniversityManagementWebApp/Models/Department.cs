using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Code is required")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code name must be 2 to 7 character long")]
        //[RegularExpression(@"\S", ErrorMessage = "Only Space not Allowed")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        //[RegularExpression(@"\", ErrorMessage = "Only Space & Number not Allowed")]
        public string Name { get; set; }
    }
}