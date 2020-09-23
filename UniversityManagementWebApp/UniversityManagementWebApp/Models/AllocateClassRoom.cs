using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class AllocateClassRoom
    {
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Department")]
        public int DepartmentId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Course")]
        public int CourseId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Room")]
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        [StringLength(3,ErrorMessage = "Select a Day")]
        [Required(ErrorMessage = "Select a Day")]


        public string Day { get; set; }
        [Required(ErrorMessage = "From Time Hour Required")]
        public string FromTimeHour { get; set; }
        [Required(ErrorMessage = "From Time Period Required")]
        public string FromTimePeriod { get; set; }
        [Required(ErrorMessage = "To Time Hour Required")]
        public string ToTimeHour { get; set; }
        [Required(ErrorMessage = "To Time Period Required")]
        public string ToTimePeriod { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
    }
}