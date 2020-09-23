using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class TeacherGateway:BaseGateway
    {
        public int SaveTeacher(Teacher teacher)
        {
            string query =
                "INSERT INTO SaveTeacher(Name,Address,Email,ContactNumber,DesignationId,DepartmentId,TotalCredit,RemainingCredit)" +
                " VALUES(@name,@address,@email,@contactNumber,@designationId,@departmentId,@totalCredit,@remainingCredit)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@name", teacher.Name);
            Command.Parameters.AddWithValue("@address", teacher.Address);
            Command.Parameters.AddWithValue("@email", teacher.Email);
            Command.Parameters.AddWithValue("@contactNumber", teacher.ContactNumber);
            Command.Parameters.AddWithValue("@designationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@departmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@totalCredit", teacher.TotalCredit);
            Command.Parameters.AddWithValue("@remainingCredit", teacher.TotalCredit);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }


        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM SaveTeacher";
            Command = new SqlCommand(query, Connection);
            List<Teacher> teacherList = new List<Teacher>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.Name = Reader["Name"].ToString();
                teacher.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                teacher.TotalCredit = Convert.ToDouble(Reader["TotalCredit"]);
                teacher.RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"]);
                teacherList.Add(teacher);               
            }
            Reader.Close();
            Connection.Close();
            return teacherList;
        }


        public bool SearchTeacher(string email)
        {
            string query = "SELECT * FROM SaveTeacher WHERE Email=@email";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@email", email);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }
    }
}