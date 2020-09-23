using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class CourseEnrollController : Controller
    {
        private CourseManager courseManager;
        private CourseEnrollManager courseEnrollManager;
        private StudentManager studentManager;
        public CourseEnrollController()
        {
            courseManager = new CourseManager();
            courseEnrollManager = new CourseEnrollManager();
            studentManager = new StudentManager();
        }

        //[HttpGet]
        public ActionResult Enroll()
        {
            ViewBag.Students = studentManager.GetAllStudents();
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(CourseEnroll courseEnroll)
        {
            ViewBag.Students = studentManager.GetAllStudents();
            if (ModelState.IsValid)
            {
                ViewBag.Message = courseEnrollManager.SaveStudentEnrollment(courseEnroll);
            }


            return View();
        }


        public JsonResult GetStudentInfoById(int Id)
        {
            StudentCourseAssign assign = courseEnrollManager.GetStudentInfoById(Id);
            return Json(assign);
        }
        public JsonResult GetCoursesById(int id)
        {
            List<Course> courses = courseManager.GetCoursesById(id);
            return Json(courses);
        }

        //public ActionResult GetCourseById(int courseId)
        //{
        //    List<Course> courses = courseManager.GetAllCourses();
        //    var c = courses.Where(p => p.Id == courseId);
        //    return Json(c);
        //}
	}
}