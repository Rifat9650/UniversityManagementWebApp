using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class DepartmentGateway:BaseGateway
    {
       
        public int SaveDepartment(Department department)
        {
            
            string query = "INSERT INTO SaveDepartment(Code,Name) VALUES(@code,@name)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@code", department.Code);
            command.Parameters.AddWithValue("@name", department.Name);
            Connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM SaveDepartment";
            SqlCommand command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(reader["Id"]);
                department.Code = reader["Code"].ToString();
                department.Name = reader["Name"].ToString();
                departmentList.Add(department);
            }
            Connection.Close();
            return departmentList;
        }
        public bool IsDepartmentExist(Department department)
        {
            string query =
                "SELECT * FROM SaveDepartment WHERE "
                    + "Name = @Name OR Code = @code";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@name", department.Name);
            command.Parameters.AddWithValue("@code", department.Code);

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool isExist = reader.HasRows;
            Connection.Close();
            return isExist;
        }
    }
}