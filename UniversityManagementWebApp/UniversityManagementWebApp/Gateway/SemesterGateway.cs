using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class SemesterGateway : BaseGateway
    {
        public List<Semester> GetAllSemester()
        {
            string query = "SELECT * FROM Semesters";
            Command = new SqlCommand(query, Connection);
            List<Semester> semestersList = new List<Semester>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Semester semester = new Semester();
                semester.Id = Convert.ToInt32(Reader["Id"]);
                semester.SemesterNo = Convert.ToInt32(Reader["Semester"]);              
                semestersList.Add(semester);
            }

            Reader.Close();
            Connection.Close();

            return semestersList;
        }
    }
}