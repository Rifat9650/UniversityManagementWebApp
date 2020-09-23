using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway = new SemesterGateway();
        public List<Semester> GetAllSemester()
        {
            return semesterGateway.GetAllSemester();
        }
        public List<SelectListItem> GetAllSemesterForDropdown()
        {
            List<Semester> semesters = semesterGateway.GetAllSemester();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select--", Value = ""}
            };
            foreach (Semester semester in semesters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semester.Id.ToString();
                selectListItem.Value = semester.SemesterNo.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}