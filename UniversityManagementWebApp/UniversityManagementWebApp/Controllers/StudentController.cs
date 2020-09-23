using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;
using UniversityManagementWebApp.Models.Views;

namespace UniversityManagementWebApp.Controllers
{
    public class StudentController : Controller
    {
        private DepartmentManager departmentManager;
        private StudentManager studentManager;
        private CourseEnrollManager courseEnrollManager;

        private static List<StudentCourseWiseResult> SaveData = new List<StudentCourseWiseResult>();
        private static List<Student> infoData = new List<Student>();
        private static int? keyData;
        public StudentController()
        {
            departmentManager = new DepartmentManager();
            studentManager = new StudentManager();
            courseEnrollManager=new CourseEnrollManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = studentManager.SaveStudent(student);
                ModelState.Clear();
            }

            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        public ActionResult SaveResult()
        {
            ViewBag.Students = studentManager.GetAllStudents();
            ViewBag.Grades = studentManager.GetAllGrades();
            return View();

        }

        [HttpPost]

        public ActionResult SaveResult(CourseEnroll studentResult)
        {


            ViewBag.Students = studentManager.GetAllStudents();
            ViewBag.Grades = studentManager.GetAllGrades();
            if (ModelState.IsValid)
            {
                ViewBag.Message = studentManager.SaveStudentResult(studentResult);
            }

            return View();

        }
        public JsonResult GetCoursesByStudent(int Id)
        {
            List<StudentResultView> assign = studentManager.GetCoursesByStudent(Id);

            return Json(assign);


        }
        public JsonResult GetStudentInfoById(int Id)
        {
            StudentCourseAssign assign = courseEnrollManager.GetStudentInfoById(Id);
            return Json(assign);
        }

        public ActionResult ViewResult()
        {
            ViewBag.Students = studentManager.GetAllStudents();
            infoData = studentManager.GetAllStudents();
            return View();

        }

        public JsonResult GetCoursesResultByStudent(int Id)
        {
            List<StudentCourseWiseResult> result = studentManager.GetCoursesResultByStudent(Id);
            SaveData = result;
            keyData = Id;
            return Json(result);
        }


        public ActionResult MakePDF()
        {
            List<Department> aDepartments = departmentManager.GetAllDepartments();

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            //string pdfName = aPatient.BillNo.ToString();
            string pdfName = "result";
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("D:/" + pdfName + ".pdf", FileMode.Create));
            var output = new MemoryStream();

            doc.Open();
            var titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL);
            var subStyle = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.UNDERLINE);
            var boldTableFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL);

            //PdfPTable aTable =new PdfPTable(4);
            //aTable.AddCell()


            Paragraph header = new Paragraph("International Islamic University, Chittagong", titleFont);
            header.Alignment = Element.ALIGN_CENTER;
            doc.Add(header);


            Paragraph body = new Paragraph("University Management System", bodyFont);
            body.Alignment = Element.ALIGN_CENTER;
            doc.Add(body);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Date: " + DateTime.Now, subTitleFont));
            doc.Add(Chunk.NEWLINE);
            Paragraph infoa = new Paragraph("Student Information", subStyle);
            infoa.Alignment = Element.ALIGN_CENTER;
            doc.Add(infoa);
            doc.Add(Chunk.NEWLINE);

            foreach (var item in infoData)
            {
                if (keyData == item.Id)
                {
                    doc.Add(new Paragraph("Student Name:                    " + item.Name, subTitleFont));
                    doc.Add(new Paragraph("Student Email:                    " + item.Email, subTitleFont));
                    doc.Add(new Paragraph("Student Registration No:    " + item.RegistrationNo, subTitleFont));

                    foreach (var aitem in aDepartments)
                    {
                        if (item.DepartmentId == aitem.Id)
                        {
                            doc.Add(new Paragraph("Student Department:          " + aitem.Name, subTitleFont));
                        }
                    }

                    break;
                }
            }

            infoData = null;
            keyData = null;

            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);


            Paragraph info = new Paragraph("Student Course Wise Result", subStyle);
            info.Alignment = Element.ALIGN_CENTER;
            doc.Add(info);
            doc.Add(Chunk.NEWLINE);




            var orderDetailsTable = new PdfPTable(3);
            orderDetailsTable.HorizontalAlignment = 1;
            orderDetailsTable.SpacingBefore = 10;
            orderDetailsTable.SpacingAfter = 35;
            orderDetailsTable.DefaultCell.Border = PdfPCell.BOX;
            orderDetailsTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


            orderDetailsTable.AddCell(new Phrase("Course Code", boldTableFont));
            orderDetailsTable.AddCell(new Phrase("Course Name", boldTableFont));
            orderDetailsTable.AddCell(new Phrase("Grade", boldTableFont));


            int sl = 1;
            double totalFee = 0;
            if (SaveData.Count != 0 || SaveData == null)
            {
                foreach (var item in SaveData)
                {

                    orderDetailsTable.AddCell(item.Code);
                    orderDetailsTable.AddCell(item.Name);
                    orderDetailsTable.AddCell(item.CourseGrade);

                }
            }

            SaveData = new List<StudentCourseWiseResult>();
            orderDetailsTable.HorizontalAlignment = Element.ALIGN_CENTER;
            doc.Add(orderDetailsTable);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);


            // Add ending message
            Paragraph endingMessage = new Paragraph("All Rights Reserved University Authority",
                endingMessageFont);
            endingMessage.Alignment = Element.ALIGN_CENTER;
            doc.Add(endingMessage);

            doc.Close();
            string fillName = "D:/" + pdfName + ".pdf";
            System.Diagnostics.Process.Start(fillName);

            return RedirectToAction("ViewResult", "Student");

        }
	}
}