using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class DesignationManager
    {
        DesignationGateway designationGateway = new DesignationGateway();
        public List<Designation> GetAllDesignation()
        {
            return designationGateway.GetAllDesignation();
        }
        public List<SelectListItem> GetAllDesignationForDropdown()
        {
            List<Designation> designations = designationGateway.GetAllDesignation();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Value = "",Text = "--Select--"}
            };
            foreach (Designation designation in designations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designation.DesignationOfTeacher;
                selectListItem.Value = designation.Id.ToString();
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}