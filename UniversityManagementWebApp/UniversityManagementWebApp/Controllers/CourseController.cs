using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Controllers
{
    public class CourseController : Controller
    {
        private DepartmentManager departmentManager;
        private CourseManager courseManager;
        private SemesterManager semesterManager;
        private TeacherManager teacherManager;

        public CourseController()
        {
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            semesterManager = new SemesterManager();
            teacherManager = new TeacherManager();
            
        }
        
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Semester = semesterManager.GetAllSemesterForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {

            if (ModelState.IsValid)
            {
                course.Assigned = "False";
                ViewBag.Message = courseManager.SaveCourse(course);
                ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
                ViewBag.Semester = semesterManager.GetAllSemesterForDropdown();
                ModelState.Clear();
            }

            else
            {
                ViewBag.Message = "Model State is Invalid";
            }
           
            return View();
        }

        [HttpGet]
        public ActionResult Assign()
        {

            List<Department> departments = departmentManager.GetAllDepartments();
            departments.Insert(0, new Department()
            {
                Id = 0,
                Code = "--Select--"
            });
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){ Id = 0,Name = "--Select--",DepartmentId = 0}
            };
            List<Course> courses = new List<Course>()
            {
                new Course(){ Id = 0,Code = "--Select--",DepartmentId = 0}
            };
            //CreateJson();
            ViewBag.Departments = departments;
            ViewBag.Teachers = teachers;
            ViewBag.Courses = courses;
            return View();
        }

        [HttpPost]
        public ActionResult Assign(CourseAssign courseAssign)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = courseManager.AssignCourse(courseAssign);
            }

            List<Department> departments = departmentManager.GetAllDepartments();
            departments.Insert(0, new Department()
            {
                Id = 0,
                Code = "--Select--"
            });
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){ Id = 0,Name = "--Select",DepartmentId = 0}
            };
            List<Course> courses = new List<Course>()
            {
                new Course(){ Id = 0,Code = "--Select--",DepartmentId = 0}
            };
            //CreateJson();
            ViewBag.Departments = departments;
            ViewBag.Teachers = teachers;
            ViewBag.Courses = courses;
            return View();
        }

        public JsonResult GetTeachersByDepartmentId(int? departmentId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachers();
            var teacher = teachers.Where(x => x.DepartmentId == departmentId);
            return Json(teacher);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = courseManager.GetAllCourses();
            var course = courses.Where(x => x.DepartmentId == departmentId && x.Assigned == "False");
            return Json(course);
        }

        public JsonResult GetTeacherById(int teacherId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachers();
            var teacher = teachers.Where(x => x.Id == teacherId);
            return Json(teacher);
        }
        public JsonResult GetCourseById(int courseId)
        {
            List<Course> courses = courseManager.GetAllCourses();
            var course = courses.Where(x => x.Id == courseId);
            return Json(course);
        }

        public ActionResult Statics()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            departments.Insert(0, new Department
            {
                Id = 0,
                Code = "--Select--"
            });
            ViewBag.Departments = departments;
            return View();
        }
        public JsonResult GetCourseInformationById(int id)
        {
            List<CourseStatics> courseStatics = courseManager.GetCourseInformation();
            var course = courseStatics.Where(x => x.DepartmentId == id);
            return Json(course);
        }
        public JsonResult GetCoursesInformationById(int id)
        {
            List<CourseStatics> courseStatics = courseManager.GetCoursesInformation();
            var course = courseStatics.Where(x => x.DepartmentId == id);
            return Json(course);
        }


        [HttpGet]
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Unassign")]
        public ActionResult UnassignPost()
        {
            string message = courseManager.UnassignAllCourses();
            ViewBag.Message = message;
            return View();
        }
    }
}