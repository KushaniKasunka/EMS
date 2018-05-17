using FEMS.ControllerManager.ProjectProgressesControllerManager;
using FEMS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Controllers
{
    public class ProjectProgressesController : Controller
    {
        private ProjectProgressesControllerManager ProjectProgressesControllerManager;

        public ProjectProgressesController()
        {
            ProjectProgressesControllerManager = new ProjectProgressesControllerManager();
        }

        [Authorize(Roles = "Admin,Manager,Client")]
        // GET: ProjectProgresses
        public ActionResult Index()
        {
            try
            {
                return View(ProjectProgressesControllerManager.getAllProjectsProgreses());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }


        [Authorize(Roles = "Admin,Manager,Client")]
        // GET: ProjectProgresses/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(ProjectProgressesControllerManager.getProjectProgress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }


        [Authorize(Roles = "Admin")]
        // GET: ProjectProgresses/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }

        // POST: ProjectProgresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(project_progress progress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProjectProgressesControllerManager.saveProjectProgress(progress);
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }


        [Authorize(Roles = "Admin")]
        // GET: ProjectProgresses/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(ProjectProgressesControllerManager.getProjectProgress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: ProjectProgresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, project_progress progress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = ProjectProgressesControllerManager.updateProjectProgress(id, progress);
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

        [Authorize(Roles = "Admin")]
        // GET: ProjectProgresses/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(ProjectProgressesControllerManager.getProjectProgress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: ProjectProgresses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, project_progress progress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = ProjectProgressesControllerManager.deleteProjectProgress(id, progress);
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
