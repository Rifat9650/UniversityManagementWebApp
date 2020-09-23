using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Gateway
{
    public class AllocateClassRoomGateway:BaseGateway
    {
        public int Save(AllocateClassRoom allocateClassRoom)
        {
            string query = "INSERT INTO AllocateClassRoom(DepartmentId,CourseId,RoomId,Day,FromTime,ToTime,Flag)" +
                           " VALUES(@departmentId,@courseId,@roomId,@day,@fromTime,@toTime,@Flag)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentId", allocateClassRoom.DepartmentId);
            Command.Parameters.AddWithValue("@courseId", allocateClassRoom.CourseId);
            Command.Parameters.AddWithValue("@roomId", allocateClassRoom.RoomId);
            Command.Parameters.AddWithValue("@day", allocateClassRoom.Day);
            Command.Parameters.AddWithValue("@fromTime",allocateClassRoom.FromTimeHour + " " + allocateClassRoom.FromTimePeriod);
            Command.Parameters.AddWithValue("@toTime",allocateClassRoom.ToTimeHour + " " + allocateClassRoom.ToTimePeriod);
            Command.Parameters.AddWithValue("@Flag", 1);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<AllocateClassRoom> GetClassRoomAllocationInfo(int roomId, string day)
        {
            string query = "SELECT * FROM AllocateClassRoom WHERE RoomId=@roomId AND Day=@day AND Flag = @Flag";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@roomId", roomId);
            Command.Parameters.AddWithValue("@day", day);
            Command.Parameters.AddWithValue("@Flag", 1);
            List<AllocateClassRoom> classRoomAllocationsList = new List<AllocateClassRoom>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                AllocateClassRoom allocateClassRoom = new AllocateClassRoom();
                allocateClassRoom.FromTime = Reader["FromTime"].ToString();
                allocateClassRoom.ToTime = Reader["ToTime"].ToString();
                classRoomAllocationsList.Add(allocateClassRoom);              
            }
            Reader.Close();
            Connection.Close();
            return classRoomAllocationsList;
        }

        public List<ClassRoomAllocationAndClassSchedule> GetClassSchedule(List<Course> courses)
        {
            List<ClassRoomAllocationAndClassSchedule> classSchedule = new List<ClassRoomAllocationAndClassSchedule>();
            foreach (Course course in courses)
            {
                string query = "SELECT * FROM ClassRoomAllocationAndClassSchedule WHERE Code=@Code AND Flag = @Flag";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("Code", course.Code);
                Command.Parameters.AddWithValue("@Flag", 1);
                ClassRoomAllocationAndClassSchedule classRoomAllocationAndSchedule =
                    new ClassRoomAllocationAndClassSchedule();
                classRoomAllocationAndSchedule.Code = course.Code;
                classRoomAllocationAndSchedule.Name = course.Name;
                Connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    classRoomAllocationAndSchedule.ClassRoomAllocations.Add(new AllocateClassRoom
                    {
                        RoomName = Reader["RoomName"].ToString(),
                        Day = Reader["Day"].ToString(),
                        FromTime = Reader["FromTime"].ToString(),
                        ToTime = Reader["ToTime"].ToString()
                    });
                }
                Reader.Close();
                Connection.Close();
                classSchedule.Add(classRoomAllocationAndSchedule);
            }
            return classSchedule;
        }
    }  


}