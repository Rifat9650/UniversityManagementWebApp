using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class ClassRoomGateway : BaseGateway
    {
        public List<ClassRoom> GetAllClassRoomInfo()
        {
            string query = "SELECT * FROM SaveClassRoom";
            Command = new SqlCommand(query, Connection);
            List<ClassRoom> classRoomList = new List<ClassRoom>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ClassRoom classRoom = new ClassRoom();
                classRoom.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                classRoom.Id = Convert.ToInt32(Reader["ID"]);
                classRoom.Name = Reader["Name"].ToString();
                classRoomList.Add(classRoom);

            }
            Reader.Close();
            Connection.Close();
            return classRoomList;
        }

        public int UnallocateAllClassRooms()
        {
            string query = "UPDATE AllocateClassRoom SET Flag = " + 0;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}