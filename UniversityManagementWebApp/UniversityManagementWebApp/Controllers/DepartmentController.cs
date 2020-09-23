using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentManager DepartmentManager { get; private set; }

        public DepartmentController()
        {
            DepartmentManager = new DepartmentManager();
        }
        public ActionResult Index()
        {

            List<Department> departmentList = DepartmentManager.GetAllDepartments();


            return View(departmentList);
        }

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                string message = DepartmentManager.SaveDepartment(department);
                ViewBag.Message = message;
                ModelState.Clear();
            }

            return View();
        }
       
	}
}