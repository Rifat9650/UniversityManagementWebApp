using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Gateway
{
    public class CourseGateway:BaseGateway
    {
        public int SaveCourse(Course course)
        {
            string query =
                "INSERT INTO SaveCourse(Code,Name,Credit,Description,DepartmentId,SemesterId,Assigned,TeacherId)" +
                " VALUES(@code,@name,@credit,@description,@departmentId,@semesterId,@assigned,@teacher)";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@code", course.Code);
            Command.Parameters.AddWithValue("@name", course.Name);
            Command.Parameters.AddWithValue("@credit", course.Credit);
            Command.Parameters.AddWithValue("@description", course.Description);
            Command.Parameters.AddWithValue("@departmentId", course.DepartmentId);
            Command.Parameters.AddWithValue("@semesterId", course.SemesterId);
            Command.Parameters.AddWithValue("@assigned", course.Assigned);
            Command.Parameters.AddWithValue("@teacher", DBNull.Value);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }



        public List<Course> GetCoursesByDepartmentId(int id)
        {
            string query = "SELECT * FROM SaveCourse WHERE DepartmentId = @departmentId  ";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentId", id);
            List<Course> courseList = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                courseList.Add(course);               
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }

        public bool IsExistCourse(Course course)
        {
            string query = "SELECT * FROM SaveCourse where Code = @code or Name = @name";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", course.Code);
            Command.Parameters.AddWithValue("@name", course.Name);

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

        public List<Course> GetAllCourses()
        {
            string query = "SELECT * FROM SaveCourse";
            Command = new SqlCommand(query, Connection);
            List<Course> courseList = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Assigned = Reader["Assigned"].ToString();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                course.Name = Reader["Name"].ToString();
                course.Credit = Convert.ToDouble(Reader["Credit"]);
                courseList.Add(course);

            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }
        

        public List<int> AssignCourse(CourseAssign courseAssign)
        {
            string query = "UPDATE SaveCourse SET Assigned='true',TeacherId= @teacherId WHERE Id=@id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@teacherId", courseAssign.TeacherId);
            Command.Parameters.AddWithValue("@id", courseAssign.CourseId);
            Connection.Open();
            int rowAffectedInSaveCouseTable = Command.ExecuteNonQuery();
            Connection.Close();
            query = "UPDATE SaveTeacher SET RemainingCredit=" +
                    (courseAssign.RemainingCredit - courseAssign.CourseCredit) + " WHERE Id=" +
                    courseAssign.TeacherId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffectedInSaveTeacherTable = Command.ExecuteNonQuery();
            Connection.Close();

            return new List<int>()
            {
                rowAffectedInSaveCouseTable,rowAffectedInSaveTeacherTable
            };
        }

        public List<CourseStatics> GetCoursesInformation()
        {
            string query = "SELECT * FROM ViewCourseStatics";
            Command = new SqlCommand(query, Connection);
            List<CourseStatics> courseStaticList = new List<CourseStatics>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                CourseStatics courseStatics = new CourseStatics();
                courseStatics.Code = Reader["Code"].ToString();
                courseStatics.Name = Reader["Name"].ToString();
                courseStatics.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                courseStatics.Semester = Convert.ToInt32(Reader["Semester"]);
                courseStatics.Assigned = Reader["Assigned"].ToString();
                courseStatics.TeacherId = HandleNullValue(Reader);
                courseStaticList.Add(courseStatics);

            }
            Reader.Close();
            Connection.Close();
            return courseStaticList;
        }
        public List<CourseStatics> GetCourseInformation()
        {
            string query = "SELECT * FROM ViewCourseStatics WHERE Assigned='true'";
            Command = new SqlCommand(query, Connection);
            List<CourseStatics> courseStaticList = new List<CourseStatics>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                CourseStatics courseStatics = new CourseStatics();
                courseStatics.Code = Reader["Code"].ToString();
                courseStatics.Name = Reader["Name"].ToString();
                courseStatics.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                courseStatics.Semester = Convert.ToInt32(Reader["Semester"]);
                courseStatics.Assigned = Reader["Assigned"].ToString();
                courseStatics.TeacherId = HandleNullValue(Reader);
                courseStaticList.Add(courseStatics);

            }
            Reader.Close();
            Connection.Close();
            return courseStaticList;
        }

        private int HandleNullValue(SqlDataReader r)
        {
            if (r["TeacherId"] == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(Reader["TeacherId"]);
            }
        }

        public List<Course> GetCoursesById(int id)
        {
            string query = "SELECT * FROM SaveCourse WHERE DepartmentId=" + id;
            Command = new SqlCommand(query, Connection);
            List<Course> courses = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new Course
                {
                    Code = Reader["Code"].ToString(),
                    Id = Convert.ToInt32(Reader["Id"])
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }


        public List<int> UnassignAllCourses()
        {
            List<int> idList = new List<int>();
            string query = "SELECT * FROM SaveTeacher";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                idList.Add(Convert.ToInt32(Reader["Id"]));
            }
            Reader.Close();
            Connection.Close();
            //List<double> totalCreditList=new List<double>();
            int rowAffected = 0;
            foreach (int id in idList)
            {
                double totalCredit = 0;
                query = "SELECT TotalCredit FROM SaveTeacher WHERE Id=" + id;
                Command = new SqlCommand(query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    totalCredit = Convert.ToDouble(Reader["TotalCredit"]);
                }
                Reader.Close();
                Connection.Close();
                query = "UPDATE SaveTeacher SET RemainingCredit=" + totalCredit + "WHERE Id=" + id;
                Command = new SqlCommand(query, Connection);
                Connection.Open();
                int i = Command.ExecuteNonQuery();
                if (i == 1)
                {
                    rowAffected++;
                }

                Connection.Close();
            }
            query = "UPDATE SaveCourse SET Assigned='False'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffectedForSaveTeacher = Command.ExecuteNonQuery();
            Connection.Close();



            query = "UPDATE CourseEnroll SET Flag =" +0;
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffectedForEnrollStudent = Command.ExecuteNonQuery();
            Connection.Close();
            return new List<int>()
            {
                idList.Count,
                rowAffected,
                rowAffectedForSaveTeacher
            };

            //query = "UPDATE SaveCourse SET Assigned='False',TeacherId=NULL";
            //Command = new SqlCommand(query, Connection);
            //Connection.Open();
            //int rowAffectedForSaveTeacher = Command.ExecuteNonQuery();
            //Connection.Close();
            //return new List<int>()
            //{
            //    idList.Count,
            //    rowAffected,
            //    rowAffectedForSaveTeacher
            //};

        }
    }
}