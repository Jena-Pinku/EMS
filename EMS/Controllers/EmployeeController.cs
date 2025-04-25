using EMS.DbUtility;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpRepository _empRepository = new EmpRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var emp = _empRepository.GetEmployees();

            return View(emp);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create(Employees emp)
        {
            _empRepository.AddEmployee(emp);
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            var emp = _empRepository.GetById(id);
            return View(emp);

        }
        [HttpPost]
        public ActionResult Edit(Employees emp)
        {
            if (ModelState.IsValid)
            {

                _empRepository.UpdateEmployee(emp);
                return RedirectToAction("Index");

            }

            return View(emp);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            _empRepository.DeleteEmployee(id);
            TempData["SuccessMessage"] = "Employee deleted successfully.";
            return RedirectToAction("Index");
        }


        public ActionResult ExportToExcel()
        {
            var emp = _empRepository.GetEmployees();
            var gv = new GridView();

            gv.DataSource = emp.ToList();
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=EmployeeDetails.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return View();
        }

        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            DateTime dTime = DateTime.Now;
            string strPDFFileName = $"EmployeeDetails{dTime:yyyyMMdd}.pdf";

            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            // 👉 Use 8 columns here to match your header/data cells
            PdfPTable tableLayout = new PdfPTable(8);

            string strAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);
            PdfWriter.GetInstance(doc, workStream).CloseStream = false;

            doc.Open();
            doc.Add(Add_Content_To_PDF(tableLayout));
            doc.Close();
            byte[] byteInfo = workStream.ToArray();
            workStream.Position = 0;

            return File(workStream, "application/pdf", strPDFFileName);
        }
        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)

        {
            float[] headers = { 20, 30, 30, 20, 30, 50, 40, 60 };
            tableLayout.SetWidths(headers);
            tableLayout.WidthPercentage = 100;
            tableLayout.HeaderRows = 1;


            var employees = _empRepository.GetEmployees();
            tableLayout.AddCell(new PdfPCell(new Phrase("EMS SYSTEM", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 8,
                Border = 0,
                PaddingBottom = 10,
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            AddCellToHeader(tableLayout, "EmpId");
            AddCellToHeader(tableLayout, "FirstName");
            AddCellToHeader(tableLayout, "LastName");
            AddCellToHeader(tableLayout, "Gender");
            AddCellToHeader(tableLayout, "DOB");
            AddCellToHeader(tableLayout, "EmailId");
            AddCellToHeader(tableLayout, "ContactNo");
            AddCellToHeader(tableLayout, "Address");

            foreach (var emp in employees)
            {

                AddCellToBody(tableLayout, emp.EmpId.ToString());
                AddCellToBody(tableLayout, emp.FirstName);
                AddCellToBody(tableLayout, emp.LastName);
                AddCellToBody(tableLayout, emp.Gender);
                AddCellToBody(tableLayout, emp.DOB.ToString());
                AddCellToBody(tableLayout, emp.EmailId);
                AddCellToBody(tableLayout, emp.ContactNo);
                AddCellToBody(tableLayout, emp.Address);

            }
            return tableLayout;
        }
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(64, 64, 64)
            });
        }
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }
    }
}


