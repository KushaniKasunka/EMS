using FEMS.ControllerManager.EmployeeProgressesControllerManager;
using FEMS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Controllers
{
    public class EmployeeProgressesController : Controller
    {
        private EmployeeProgressesControllerManager EmployeeProgressesControllerManager;

        public EmployeeProgressesController()
        {
            EmployeeProgressesControllerManager = new EmployeeProgressesControllerManager();
        }

        [Authorize(Roles = "Admin")]
        // GET: EmployeeProgresses
        public ActionResult Index()
        {
            try
            {
                return View(EmployeeProgressesControllerManager.getAllProgress());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: EmployeeProgresses/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(EmployeeProgressesControllerManager.getProgress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        //[Authorize(Roles = "Admin")]
        //// GET: EmployeeProgresses/Create
        //public ActionResult Create()
        //{
        //    ViewBag.month = EmployeeProgressesControllerManager.getMonth();
        //    return View();
        //}

        // POST: EmployeeProgresses/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(emp_progresses emp_progresses)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int flag = EmployeeProgressesControllerManager.saveProgress(emp_progresses);
        //        if (flag == 1)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            //error message
        //        }
        //    }
        //    ViewBag.month = EmployeeProgressesControllerManager.getMonth();
        //    return View();
        //}


        [Authorize(Roles = "Admin")]
        // GET: EmployeeProgresses/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.month = EmployeeProgressesControllerManager.getMonth();
                return View(EmployeeProgressesControllerManager.getProgress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }

        // POST: EmployeeProgresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, emp_progresses emp_progresses)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = EmployeeProgressesControllerManager.updateProgress(id, emp_progresses);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.month = EmployeeProgressesControllerManager.getMonth();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }



        }


        [Authorize(Roles = "Admin")]
        // GET: EmployeeProgresses/Delete/5
        public ActionResult Delete(int id)
        {   try
            {
                return View(EmployeeProgressesControllerManager.getProgress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: EmployeeProgresses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, emp_progresses emp_progresses)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    int flag = EmployeeProgressesControllerManager.deleteProgress(id, emp_progresses);
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
