using FEMS.ControllerManager.EmployeeControllerManager;
using FEMS.Database;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System;

namespace FEMS.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeControllerManager EmployeeControllerManager;

        public EmployeesController()
        {
            EmployeeControllerManager = new EmployeeControllerManager();
        }


        [Authorize(Roles = "Admin,Manager")]
        // GET: Employees
        public ActionResult Index()
        {
            try
            {
                return View(EmployeeControllerManager.getAllEmp());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }


        [Authorize(Roles = "Admin,Manager")]
        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(EmployeeControllerManager.getEmp(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }


        [Authorize(Roles = "Admin")]
        // GET: Employees/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.gender = EmployeeControllerManager.getEmpGender();
                ViewBag.designation = EmployeeControllerManager.getEmpDes();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = EmployeeControllerManager.saveEmp(employee);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "This Employee is already taken");
                        ViewBag.gender = EmployeeControllerManager.getEmpGender();
                        ViewBag.designation = EmployeeControllerManager.getEmpDes();
                        return View();
                    }
                }
                ViewBag.gender = EmployeeControllerManager.getEmpGender();
                ViewBag.designation = EmployeeControllerManager.getEmpDes();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }

        [Authorize(Roles = "Admin")]
        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.gender = EmployeeControllerManager.getEmpGender();
                ViewBag.designation = EmployeeControllerManager.getEmpDes();
                return View(EmployeeControllerManager.getEmp(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        EmployeeControllerManager.updateEmp(id, employee);
                        return RedirectToAction("Index");

                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
                ViewBag.gender = EmployeeControllerManager.getEmpGender();
                ViewBag.designation = EmployeeControllerManager.getEmpDes();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }


        [Authorize(Roles = "Admin")]
        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(EmployeeControllerManager.getEmp(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        int flag = EmployeeControllerManager.deleteEmp(id, employee);
                        if (flag == 1)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [Authorize(Roles = "Admin,Manager")]
        //GET/Employees/getTaskReport
        public ActionResult getTaskReport(int id)
        {
            EMSEntities db = new EMSEntities();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/TaskReport.rpt")));
            rd.SetDataSource(db.emp_task_ref.Select(t => new
            {
                task_id = t.task.task_id,
                task_name = t.task.task_name,
                task_description = t.task.task_description,
                task_started_date = t.task.task_started_date,
                task_end_date = t.task.task_end_date,
                emp_id  = t.employee.emp_id
            }).ToList().Where(t => t.emp_id == id));
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EmployeeReport.pdf");
        }


        [Authorize(Roles = "Admin")]
        // GET: Employees/AssignTask/5
        public ActionResult AssignTask(int id)
        {
            try
            {
                ViewBag.tasks = EmployeeControllerManager.getAllTasks();
                return View(EmployeeControllerManager.getTaskWithEmployeeId(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        //POST: Employees/AssignTask
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignTask(emp_task_ref emp_task_ref)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        EmployeeControllerManager.saveEmp_Task(emp_task_ref);
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.tasks = EmployeeControllerManager.getAllTasks();
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [Authorize(Roles = "Admin")]
        //GET: Employees/AddProgress
        public  ActionResult AddProgress(int id)
        {
            try
            {
                ViewBag.projectList = EmployeeControllerManager.getPorjectList();
                return View(EmployeeControllerManager.getProgressWithEmpId(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProgress(emp_progresses emp_progresses)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = EmployeeControllerManager.saveProgress(emp_progresses);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.projectList = EmployeeControllerManager.getPorjectList();
                        return View();
                    }
                }
                else
                {
                    ViewBag.projectList = EmployeeControllerManager.getPorjectList();
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
