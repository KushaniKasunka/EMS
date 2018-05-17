using CrystalDecisions.CrystalReports.Engine;
using FEMS.Database;
using FEMS.Enums;
using FEMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Controllers
{
    public class ReportsController : Controller
    {
        private EMSEntities db;

        public ReportsController()
        {
            db = new EMSEntities();
        }

        [Authorize(Roles ="Admin,Manager")]
        // GET: Reports/CreateClientReport
        public ActionResult CreateClientReport()
        {
            try
            {
                ViewBag.clients = new SelectList(db.clients.Where(c => c.client_status == 1), "client_id", "client_company");
                return View(new Report() { emp_id = 0 });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Reports/CreateClientReport
        public ActionResult CreateClientReport(Report report)
        {
            if (ModelState.IsValid)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/ProjectReport.rpt")));
                rd.SetDataSource(db.projects.Select(p => new {
                    project_id = p.project_id,
                    project_name = p.project_name,
                    project_location = p.project_location,
                    project_budget = p.project_budget,
                    project_assign_date = p.project_assign_date,
                    project_deadline = p.project_deadline,
                    client_id = p.client_id
                }).ToList().Where(p => p.client_id == report.client_id 
                && Int32.Parse(p.project_assign_date.Substring(0,4)) >= Int32.Parse(report.reportDateFrom.Substring(0,4))
                && Int32.Parse(p.project_assign_date.Substring(0, 4)) <= Int32.Parse(report.reportDateTo.Substring(0, 4))
                && Int32.Parse(p.project_assign_date.Substring(5, 2)) >= Int32.Parse(report.reportDateFrom.Substring(5, 2))
                && Int32.Parse(p.project_assign_date.Substring(5, 2)) <= Int32.Parse(report.reportDateTo.Substring(5, 2))
                && Int32.Parse(p.project_assign_date.Substring(8, 2)) >= Int32.Parse(report.reportDateFrom.Substring(8, 2))
                && Int32.Parse(p.project_assign_date.Substring(8, 2)) <= Int32.Parse(report.reportDateTo.Substring(8, 2))
                ));
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Projects_report.pdf");
            }
            else
            {
                ViewBag.clients = new SelectList(db.clients.Where(c => c.client_status == 1), "client_id", "client_company");
                return View();
            }
        }


        [Authorize(Roles = "Admin,Manager")]
        // GET: Reports/CreateEMPReport
        public ActionResult CreateEMPReport()
        {
            try
            {
                ViewBag.employees = new SelectList(db.employees.Where(e => e.emp_status == 1), "emp_id", "emp_fname");
                return View(new Report() { client_id = 0 });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Reports/CreateEMPReport
        public ActionResult CreateEMPReport(Report report)
        {
            if (ModelState.IsValid)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/TaskReport.rpt")));
                rd.SetDataSource(db.emp_task_ref.Select(t => new
                {
                    task_id = t.task.task_id,
                    task_name = t.task.task_name,
                    task_description = t.task.task_description,
                    task_started_date = t.task.task_started_date,
                    task_end_date = t.task.task_end_date,
                    emp_id = t.employee.emp_id
                }).ToList().Where(t => t.emp_id == report.emp_id
                && Int32.Parse(t.task_started_date.Substring(0, 4)) >= Int32.Parse(report.reportDateFrom.Substring(0, 4))
                && Int32.Parse(t.task_started_date.Substring(0, 4)) <= Int32.Parse(report.reportDateTo.Substring(0, 4))
                && Int32.Parse(t.task_started_date.Substring(5, 2)) >= Int32.Parse(report.reportDateFrom.Substring(5, 2))
                && Int32.Parse(t.task_started_date.Substring(5, 2)) <= Int32.Parse(report.reportDateTo.Substring(5, 2))
                && Int32.Parse(t.task_started_date.Substring(8, 2)) >= Int32.Parse(report.reportDateFrom.Substring(8, 2))
                && Int32.Parse(t.task_started_date.Substring(8, 2)) <= Int32.Parse(report.reportDateTo.Substring(8, 2))
                ));
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Employee_report.pdf");
            }
            else
            {
                ViewBag.employees = new SelectList(db.employees.Where(e => e.emp_status == 1), "emp_id", "emp_fname");
                return View();
            }
        }


        [Authorize(Roles = "Admin,Manager")]
        // GET: Reports/CreateProjectReport
        public ActionResult CreateProjectReport()
        {
            try
            {
                return View(new Report() { emp_id = 0, client_id = 0 });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Reports/CreateProjectReport
        public ActionResult CreateProjectReport(Report report)
        {
            if (ModelState.IsValid)
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/AllProjectsReport.rpt")));
                rd.SetDataSource(db.projects.Select(p => new
                {
                    project_id = p.project_id,
                    project_name = p.project_name,
                    project_location = p.project_location,
                    project_budget = p.project_budget,
                    project_assign_date = p.project_assign_date,
                    project_deadline = p.project_deadline,
                    client_id = p.client_id
                }).ToList());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "All_Projects_report.pdf");
            }
            return View();
        }
    }
}