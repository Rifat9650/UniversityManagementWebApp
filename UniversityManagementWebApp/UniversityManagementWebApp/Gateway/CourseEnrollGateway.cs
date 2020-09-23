using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class CourseEnrollGateway :BaseGateway
    {
        public int SaveStudentEnrollmen(CourseEnroll courseEnroll)
        {
            string query =
                "INSERT INTO CourseEnroll(StudentId,Name,Email,Date,DepartmentName,CourseId,CourseGrade,Flag)" +
                " VALUES(@studentId,@name,@email,@date,@departmentName,@courseId,@courseGrade,@flag)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@studentId", courseEnroll.StudentId);
            Command.Parameters.AddWithValue("@name", courseEnroll.Name);
            Command.Parameters.AddWithValue("@email", courseEnroll.Email);
            Command.Parameters.AddWithValue("@date", courseEnroll.Date);
            Command.Parameters.AddWithValue("@departmentName", courseEnroll.DepartmentName);
            Command.Parameters.AddWithValue("@courseId", courseEnroll.CourseId);
            Command.Parameters.AddWithValue("@courseGrade", "Not graded yet");
            Command.Parameters.AddWithValue("@flag", 1);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }


        public bool CourseCheck(CourseEnroll courseId)
        {
            string query = "SELECT * FROM CourseEnroll WHERE CourseId = @courseId and StudentId = @id and Flag = @flag";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@courseId", courseId.CourseId);
            Command.Parameters.AddWithValue("@id", courseId.StudentId);
            Command.Parameters.AddWithValue("@flag", 1);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            reader.Read();
            bool isExist = reader.HasRows;
            Connection.Close();
            return isExist;

          
        }

        public StudentCourseAssign GetStudentInfoById(int id)
        {
            string query = "select * from StudentCourseAssign where Id= @id";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("id", id);

            Connection.Open();
            Reader = Command.ExecuteReader();
            StudentCourseAssign assign = null;
            if (Reader.Read())
            {
                assign = new StudentCourseAssign
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    DepartmentName = Reader["DepartmentName"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Name = Reader["Name"].ToString(),
                    RegistrationNo = Reader["RegistrationNo"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"])
                };
            }

            return assign;
        }
    }
}