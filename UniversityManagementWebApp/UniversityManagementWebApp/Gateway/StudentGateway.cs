using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Gateway
{
    public class StudentGateway:BaseGateway
    {
        public int SaveStudent(Student student)
        {
            string query = "INSERT INTO SaveStudent(Name,Email,ContactNo,Date,Address,RegistrationNo,DepartmentId)" +
                           " values(@name,@email,@contactNo,@date,@address,@registrationNo,@departmentId)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@name", student.Name);
            Command.Parameters.AddWithValue("@email", student.Email);
            Command.Parameters.AddWithValue("@contactNo", student.ContactNo);
            Command.Parameters.AddWithValue("@date", student.Date);
            Command.Parameters.AddWithValue("@address", student.Address);
            Command.Parameters.AddWithValue("@registrationNo", student.RegistrationNo);
            Command.Parameters.AddWithValue("@departmentId", student.DepartmentId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public bool IsvalideStudent(Student aStudent)
        {

            string query = "SELECT * FROM SaveStudent where Email=@email or ContactNo=@contactNo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@email", aStudent.Email);
            Command.Parameters.AddWithValue("@contactNo", aStudent.ContactNo);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            reader.Read();
            bool isExist = reader.HasRows;
            Connection.Close();
            return isExist;


            //Connection.Open();
            //Reader = Command.ExecuteReader();
            //if (Reader.Read())
            //{
            //    Reader.Close();
            //    Connection.Close();
            //    return 1;
            //}

            //Reader.Close();
            //Connection.Close();
            //return 0;
        }

        public int GetStudentNum(string regNo)
        {
            string query = "SELECT * FROM SaveStudent where RegistrationNo like '" + regNo + "%" + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            int rowAffect = 0;
            while (Reader.Read())
            {
                rowAffect++;
            }
            Reader.Close();
            Connection.Close();
            return rowAffect;
        }


        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM SaveStudent";
            Command = new SqlCommand(query, Connection);
            List<Student> studentList = new List<Student>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(Reader["Id"]);
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.ContactNo = Reader["ContactNo"].ToString();
                student.Date = Convert.ToDateTime(Reader["Date"]);
                student.Address = Reader["Address"].ToString();
                student.RegistrationNo = Reader["RegistrationNo"].ToString();
                student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);

                studentList.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return studentList;
        }


        public int SaveStudentResult(CourseEnroll studentResult)
        {
            string query = "UPDATE CourseEnroll SET CourseGrade = @grade WHERE " +
                           "StudentId=@id AND CourseId=@courseId";
            Command = new SqlCommand(query, Connection);

            
            Command.Parameters.AddWithValue("@grade", studentResult.CourseGrade);
            Command.Parameters.AddWithValue("@id", studentResult.StudentId);
            Command.Parameters.AddWithValue("@courseId", studentResult.CourseId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<StudentResultView> GetCoursesByStudent(int id)
        {

            string query = "SELECT * FROM StudentResultView WHERE StudentId = @id and Flag = @Flag";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            Command.Parameters.AddWithValue("@Flag", 1);
            List<StudentResultView> resultViewList = new List<StudentResultView>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                StudentResultView studentResultView = new StudentResultView();
                studentResultView.CourseName = Reader["CourseName"].ToString();
                studentResultView.CourseId = Convert.ToInt32(Reader["CourseId"]);
                resultViewList.Add(studentResultView);
            }
            Reader.Close();
            Connection.Close();
            return resultViewList;

        }

        public List<StudentCourseWiseResult> GetCoursesResultByStudent(int id)
        {
            string query = "SELECT * FROM StudentCourseWiseView WHERE StudentId = @id and Flag = @Flag";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@id", id);
            Command.Parameters.AddWithValue("@Flag", 1);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentCourseWiseResult> resultList = new List<StudentCourseWiseResult>();
            while (Reader.Read())
            {
                StudentCourseWiseResult aResult = new StudentCourseWiseResult();
                aResult.StudentId = Convert.ToInt32(Reader["StudentId"]);
                aResult.Code = Reader["Code"].ToString();
                aResult.Name = Reader["Name"].ToString();
                aResult.CourseGrade = Reader["CourseGrade"].ToString();
                resultList.Add(aResult);
            }
            Reader.Close();
            Connection.Close();
            return resultList;

        }
    }
}