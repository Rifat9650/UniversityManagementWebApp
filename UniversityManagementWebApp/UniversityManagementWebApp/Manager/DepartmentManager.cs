using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway DepartmentGateway;
        public DepartmentManager()
        {
            DepartmentGateway = new DepartmentGateway();
        }

        public string SaveDepartment(Department department)
        {

            if (DepartmentGateway.IsDepartmentExist(department))
            {
                return "Code Or Name Already Exists";
            }
            int rowAffect = DepartmentGateway.SaveDepartment(department);
            if (rowAffect > 0)
            {
                return "Saved Succesfully";
            }
            return "Save Failed";
        }

       
        public List<Department> GetAllDepartments()
        {
            return DepartmentGateway.GetAllDepartments();
        }
        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments =DepartmentGateway.GetAllDepartments();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Value = "",Text = "--Select--"}
            };
            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Name;
                selectListItem.Value = department.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}