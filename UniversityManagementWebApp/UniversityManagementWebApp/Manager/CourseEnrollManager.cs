using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourseEnrollManager
    {
        private CourseEnrollGateway courseEnrollGateway;
        public CourseEnrollManager()
        {
            courseEnrollGateway = new CourseEnrollGateway();
        }

        public string SaveStudentEnrollment(CourseEnroll courseEnroll)
        {
            if (courseEnrollGateway.CourseCheck(courseEnroll))
            {
                 return "Sorry! Course Enrollment Failed";
            }
            int rowAffected = courseEnrollGateway.SaveStudentEnrollmen(courseEnroll);

                if (rowAffected > 0)
                {
                    return "Saved Successfully!!";
                }
                
            else
            {
                return "Sorry! Course Enrollment Failed";
            }

        }

        public StudentCourseAssign GetStudentInfoById(int id)
        {
            return courseEnrollGateway.GetStudentInfoById(id);
        }

    }
}