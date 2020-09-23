using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Manager
{
    public class StudentManager
    {
        private DepartmentGateway departmentGateway;
        private StudentGateway studentGateway;

        public StudentManager()
        {
            departmentGateway = new DepartmentGateway();
            studentGateway = new StudentGateway();
        }

        public string SaveStudent(Student student)
        {
            student.RegistrationNo = GenarateRegNo(student);
            if (studentGateway.IsvalideStudent(student))
            {
                return "Sorry! Email or Contact No already Exist";
            }
            int rowAffected = studentGateway.SaveStudent(student);

                if (rowAffected > 0)
                {
                    return "Saved Successfully!!";
                }
               
            else
            {
                return "Sorry! Student Save Failed";
            }

        }

        private string GenarateRegNo(Student student)
        {
            var aList = departmentGateway.GetAllDepartments();
            string depName = "";
            foreach (var item in aList)
            {
                if (item.Id == student.DepartmentId)
                {
                    depName = item.Code;
                    break;

                }
            }

            string regNo = depName + "-" + student.Date.Year + "-";
            int num = studentGateway.GetStudentNum(regNo) + 1;

            if (num > 99)
            {
                regNo = regNo + num;
            }
            else if (num > 9)
            {
                regNo = regNo + "0" + num;
            }
            else
            {
                regNo = regNo + "00" + num;
            }

            return regNo;
        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }

        public List<string> GetAllGrades()
        {

            return new List<string>
            {
               "Select", "A+","A","A-","B+","B","B-","C+","C","C-","D+","D","D-","F"
            };
        }

        public string SaveStudentResult(CourseEnroll studentResult)
        {

            int rowAffected = studentGateway.SaveStudentResult(studentResult);

            if (rowAffected < 1)
            {
                return "Sorry! Student Result Save Failed";
            }
            else
            {
                return "Saved Successfully!!";
            }
        }

        public List<StudentResultView> GetCoursesByStudent(int id)
        {

            return studentGateway.GetCoursesByStudent(id);
        }

        public List<StudentCourseWiseResult> GetCoursesResultByStudent(int id)
        {
            return studentGateway.GetCoursesResultByStudent(id);
        }

    }
}