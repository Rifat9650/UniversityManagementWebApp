using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Designation
    {
       
        public int Id { get; set; }

        public string DesignationOfTeacher { get; set; }
    }
}