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
    public class AllocateClassRoomController : Controller
    {
        DepartmentManager departmentManager;
        CourseManager courseManager;
        AllocateClassRoomManager allocateClassRoomManager;
        ClassRoomManager classRoomManager;
        TeacherManager teacherManager;

        public AllocateClassRoomController()
        {
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            allocateClassRoomManager = new AllocateClassRoomManager();
            classRoomManager = new ClassRoomManager();
            teacherManager = new TeacherManager();
        }
        [HttpGet]
        public ActionResult Allocate()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            departments.Insert(0, new Department()
            {
                Id = 0,
                Code = "--Select--"
            });
            List<Course> courses = new List<Course>()
            {
                new Course(){ Id = 0,Code = "--Select--",DepartmentId = 0}
            };
            List<ClassRoom> classRooms = classRoomManager.GetAllClassRoomInfo();
            {
                new ClassRoom() {Id = 0, DepartmentId = 0, Name = "--Select--"};
            };
            List<string> days = GetDays();
           
                ViewBag.Departments = departments;
                ViewBag.ClassRooms = classRooms;
                ViewBag.Courses = courses;
                ViewBag.Days = days;    
            return View();
        }

        [HttpPost]
        public ActionResult Allocate(AllocateClassRoom allocateClassRoom)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = allocateClassRoomManager.Save(allocateClassRoom);
            }
            else
            {
                ViewBag.Message = "Model State is Invalid";
            }

            List<Department> departments = departmentManager.GetAllDepartments();
            departments.Insert(0, new Department()
            {
                Id = 0,
                Code = "--Select--"
            });
            List<Course> courses = new List<Course>()
            {
                new Course(){ Id = 0,Code = "--Select--",DepartmentId = 0}
            };
            List<ClassRoom> classRooms = new List<ClassRoom>()
            {
                new ClassRoom(){Id = 0,DepartmentId = 0,Name = "--Select--"}
            };
            List<string> days = GetDays();

            ViewBag.Departments = departments;
            ViewBag.ClassRooms = classRooms;
            ViewBag.Courses = courses;
            ViewBag.Days = days;
            return View();          
        }


        public List<string> GetDays()
        {
            return new List<string>()
            {
                "--Select--","SAT","SUN","MON","TUE","WED","THU","FRI"
            };
        }


        public ActionResult Schedule()
        {
            List<ClassRoomAllocationAndClassSchedule> classSchedule = new List<ClassRoomAllocationAndClassSchedule>();
            List<Department> departments = departmentManager.GetAllDepartments();
            departments.Insert(0, new Department()
            {
                Id = 0,
                Code = "--Select--"
            });
            ViewBag.ClassSchedule = classSchedule;
            ViewBag.Departments = departments;
            return View();
        }
        [HttpPost]
        public JsonResult Schedule(int id)
        {
            List<ClassRoomAllocationAndClassSchedule> classSchedule = allocateClassRoomManager.GetClassSchedule(id);
            return Json(classSchedule);
        }
        public JsonResult GetCourses(int id)
        {
            List<Course> courses = courseManager.GetAllCourses();
            var s = courses.Where(x => x.DepartmentId == id);
            return Json(s);
        }

        public JsonResult GetRooms(int id)
        {
            List<ClassRoom> rooms = classRoomManager.GetAllClassRoomInfo();
            var s = rooms.Where(x => x.DepartmentId == id);
            return Json(s);
        }

        public ActionResult Unallocate()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Unallocate")]
        public ActionResult UnallocatePost()
        {
            string message = classRoomManager.UnallocateAllClassRooms();
            ViewBag.Message = message;
            return View();
        }
	}
}