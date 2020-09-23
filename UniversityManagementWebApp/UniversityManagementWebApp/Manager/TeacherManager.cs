using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway = new TeacherGateway();

        public List<Teacher> GetAllTeachers()
        {
            return teacherGateway.GetAllTeachers();
        }

        public string Save(Teacher teacher)
        {
            bool hasRows = teacherGateway.SearchTeacher(teacher.Email);
            if (!hasRows)
            {
                int rowAffected = teacherGateway.SaveTeacher(teacher);
                if (rowAffected > 0)
                {
                    return "Teacher Saved Sucessfully";
                }
                else
                {
                    return "Teacher Save Failed";
                }
            }
            else
            {
                return "Teacher with same Email already Exist";
            }
        }
        public List<SelectListItem> GetAllTeacherForDropdown()
        {
            List<Teacher> teacherList = teacherGateway.GetAllTeachers();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Value = "",Text = "--Select--"}
            };
            foreach (Teacher teacher in teacherList)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = teacher.Name;
                selectListItem.Value = teacher.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}