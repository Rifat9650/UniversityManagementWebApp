using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class DesignationGateway:BaseGateway
    {
        public List<Designation> GetAllDesignation()
        {
            string query = "SELECT * FROM Designation";
            Command = new SqlCommand(query, Connection);
            List<Designation> designationList = new List<Designation>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Designation designation = new Designation();
                designation.Id = Convert.ToInt32(Reader["Id"]);
                designation.DesignationOfTeacher = Reader["Designation"].ToString();
                designationList.Add(designation);
                
            }
            Reader.Close();
            Connection.Close();
            return designationList;
        }
    }
}