using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private DepartmentManager departmentManager;
        private TeacherManager teacherManager;
        private DesignationManager designationManager;
        public TeacherController()
        {
            departmentManager = new DepartmentManager();
            teacherManager = new TeacherManager();
            designationManager = new DesignationManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Designations = designationManager.GetAllDesignationForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = teacherManager.Save(teacher);
                ViewBag.Message = message;
                ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
                ViewBag.Designations = designationManager.GetAllDesignationForDropdown();
                ModelState.Clear();
            }
            
            
            return View();
        }

    }
}