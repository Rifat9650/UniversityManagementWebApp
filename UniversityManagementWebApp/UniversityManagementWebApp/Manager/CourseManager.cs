using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();

        public String SaveCourse(Course course)
        {

            if (courseGateway.IsExistCourse(course))
            {
                return "Sorry! Course Already Exist";
            }

            int rowAffected = courseGateway.SaveCourse(course);

                if (rowAffected > 0)
                {
                    return "Saved Successfully!!";
                        
                }

            return "Save Failed";

        }

        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }

       
        public List<Course> GetCoursesByDepartmentId(int id)
        {
            return courseGateway.GetCoursesByDepartmentId(id);
        }
        
        public string AssignCourse(CourseAssign courseAssign)
        {
            var rowAffected = courseGateway.AssignCourse(courseAssign);
            if (rowAffected[0] > 0 && rowAffected[1] > 0)
            {
                return "Course Assigned.";
            }
            else
            {
                return "Course Assign failed.";
            }
        }

        
        public List<CourseStatics> GetCourseInformation()
        {
            List<CourseStatics> courseStatics = courseGateway.GetCourseInformation();
            List<Teacher> teacherList = new TeacherGateway().GetAllTeachers();
            foreach (CourseStatics course in courseStatics)
            {
                foreach (Teacher teacher in teacherList)
                {
                    if (course.TeacherId == teacher.Id)
                    {
                        course.TeacherName = teacher.Name;
                        break;
                    }
                    else
                    {
                        course.TeacherName = "Not Assigned Yet";
                    }
                }
            }
            return courseStatics;
        }
        public List<CourseStatics> GetCoursesInformation()
        {
            List<CourseStatics> courseStatics = courseGateway.GetCoursesInformation();
            List<Teacher> teacherList = new TeacherGateway().GetAllTeachers();
            foreach (CourseStatics course in courseStatics)
            {
                foreach (Teacher teacher in teacherList)
                {
                    if (course.TeacherId == teacher.Id)
                    {
                        course.TeacherName = teacher.Name;
                        break;
                    }
                    else
                    {
                        course.TeacherName = "Not Assigned Yet";
                    }
                }
            }
            return courseStatics;
        }



        public List<Course> GetCoursesById(int id)
        {
            return courseGateway.GetCoursesById(id);
        }


        public string UnassignAllCourses()
        {
            List<int> rows = courseGateway.UnassignAllCourses();
            rows.Add(courseGateway.GetAllCourses().Count);
            if (rows[0] == rows[1] && rows[2] == rows[3] )
            {
                return "Course Unassign Successful.";
            }
            else
            {
                return "Course Unassign Failed";
            }
        }
    }
}