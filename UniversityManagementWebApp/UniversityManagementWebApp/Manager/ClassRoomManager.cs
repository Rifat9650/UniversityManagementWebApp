using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class ClassRoomManager
    {
        private ClassRoomGateway classRoomGateway = new ClassRoomGateway();
        public List<ClassRoom> GetAllClassRoomInfo()
        {
            return classRoomGateway.GetAllClassRoomInfo();
        }

        public string UnallocateAllClassRooms()
        {
            int rowAffected = classRoomGateway.UnallocateAllClassRooms();
            if (rowAffected > 0)
            {
                return "All Classrooms are unallocated.";
            }
            else
            {
                return "Classroom unallocation failed.";
            }
        }
    }
}