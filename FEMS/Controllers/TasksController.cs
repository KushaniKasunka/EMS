using FEMS.Common;
using FEMS.ControllerManager.TasksControllerManager;
using FEMS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Controllers
{
    public class TasksController : Controller
    {
        private TasksControllerManager TasksControllerManager;
        private DateValidate DateValidate;

        public TasksController()
        {
            TasksControllerManager = new TasksControllerManager();
        }

        [Authorize(Roles = "Admin")]
        // GET: Tasks
        public ActionResult Index()
        {
            try
            {
                return View(TasksControllerManager.getAllTasks());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [Authorize(Roles = "Admin")]
        // GET: Tasks/GetTaskForProject
        public ActionResult GetTaskForProject(int id)
        {
            try
            {
                return View(TasksControllerManager.GetTaskForProject(id));

            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        [Authorize(Roles = "Admin")]
        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(TasksControllerManager.getTask(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //// GET: Tasks/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Tasks/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(task task)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TasksControllerManager.saveTask(task);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.taskState = TasksControllerManager.getTaskState();
                return View(TasksControllerManager.getTask(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, task task)
        {
            try
            {
                DateValidate = new DateValidate();
                if (ModelState.IsValid)
                {
                    if (DateValidate.IsDateLessThanToday(task.task_started_date) && DateValidate.IsDateLessThanToday(task.task_end_date))
                    {
                        int flag = TasksControllerManager.updateTask(id, task);
                        if (flag == 1)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Dates are Invalid");
                        return View();
                    }
                }
                ViewBag.taskState = TasksControllerManager.getTaskState();

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(TasksControllerManager.getTask(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = TasksControllerManager.deleteTask(id, task);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
