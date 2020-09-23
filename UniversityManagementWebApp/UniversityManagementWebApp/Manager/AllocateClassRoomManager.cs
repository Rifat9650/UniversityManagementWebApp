using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Manager
{
    public class AllocateClassRoomManager
    {
        private AllocateClassRoomGateway allocateClassRoomGateway;
        private CourseGateway courseGateway;
        private ClassRoomGateway classRoomGateway;
        private CourseManager courseManager;
        public AllocateClassRoomManager()
        {
            allocateClassRoomGateway = new AllocateClassRoomGateway();
            courseGateway = new CourseGateway();
            classRoomGateway = new ClassRoomGateway();
            courseManager = new CourseManager();
        }



        public string Save(AllocateClassRoom allocateClassRoom)
        {
            List<AllocateClassRoom> classRoomAllocations =
                allocateClassRoomGateway.GetClassRoomAllocationInfo(allocateClassRoom.RoomId, allocateClassRoom.Day);

            //int rowAffected = allocateClassRoomGateway.Save(allocateClassRoom);
            //if (classRoomAllocations.Count == 0)
            //{
            //    int rowAffected = allocateClassRoomGateway.Save(allocateClassRoom);
            //    if (rowAffected > 0)
            //    {
            //        return "Success";
            //    }
            //    else
            //    {
            //        return "Failed.";
            //    }
            //}

            //else
            //{
            //    return "Room Can't be allocated.";
            //}

            {
                string fromTime = allocateClassRoom.FromTimeHour + " " + allocateClassRoom.FromTimePeriod;
                string toTime = allocateClassRoom.ToTimeHour + " " + allocateClassRoom.ToTimePeriod;
                string dateFormat = "h:mm tt";
                DateTime fromDateTime = DateTime.ParseExact(fromTime, dateFormat, CultureInfo.InvariantCulture);
                DateTime toDateTime = DateTime.ParseExact(toTime, dateFormat, CultureInfo.InvariantCulture);
                bool roomCanBeAllocated = true;


                if ((TimeSpan.Compare(toDateTime.TimeOfDay, fromDateTime.TimeOfDay) == 0))
                {
                    roomCanBeAllocated = false;

                }
                else
                {
                    foreach (AllocateClassRoom classRoom in classRoomAllocations)
                    {
                        DateTime fromTimeExist = DateTime.ParseExact(classRoom.FromTime, dateFormat,
                            CultureInfo.InvariantCulture);
                        DateTime toTimeExist = DateTime.ParseExact(classRoom.ToTime, dateFormat,
                            CultureInfo.InvariantCulture);
                        if ((TimeSpan.Compare(fromTimeExist.TimeOfDay, fromDateTime.TimeOfDay) == 1 &&
                             TimeSpan.Compare(fromTimeExist.TimeOfDay, toDateTime.TimeOfDay) == 1)
                             ||
                            (TimeSpan.Compare(toTimeExist.TimeOfDay, fromDateTime.TimeOfDay) == -1 &&
                             TimeSpan.Compare(toTimeExist.TimeOfDay, toDateTime.TimeOfDay) == -1)
                             ||
                            (TimeSpan.Compare(toTimeExist.TimeOfDay, fromDateTime.TimeOfDay) == 0 &&
                             TimeSpan.Compare(toTimeExist.TimeOfDay, toDateTime.TimeOfDay) == -1)
                             ||
                            (TimeSpan.Compare(fromTimeExist.TimeOfDay, toDateTime.TimeOfDay) == 0 &&
                             TimeSpan.Compare(fromTimeExist.TimeOfDay, fromDateTime.TimeOfDay) == 1)
                            )
                        {
                            roomCanBeAllocated = true;
                        }
                        //else if ((TimeSpan.Compare(toDateTime.TimeOfDay, fromDateTime.TimeOfDay) == 0))
                        //{
                        //    roomCanBeAllocated = false;
                        //    break;
                        //}
                        else
                        {
                            roomCanBeAllocated = false;
                        }
                    }
                }

                
                if (roomCanBeAllocated)
                {
                    int rowAffected = allocateClassRoomGateway.Save(allocateClassRoom);
                    if (rowAffected > 0)
                    {
                        return "Room Successfully Allocated.";
                    }
                    else
                    {
                        return "Room Can't be allocated.";
                    }
                }
                else
                {
                    return "Room Can't be allocated.";
                }
            }
        }

        public List<ClassRoom> GetAllClassRoomInfo()
        {
            return classRoomGateway.GetAllClassRoomInfo();
        }

        public List<ClassRoomAllocationAndClassSchedule> GetClassSchedule(int id)
        {
            List<Course> courses = courseManager.GetCoursesByDepartmentId(id);
            return allocateClassRoomGateway.GetClassSchedule(courses);
        }
    }
}
