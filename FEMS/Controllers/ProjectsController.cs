using FEMS.Common;
using FEMS.ControllerManager.ProjectsControllerManager;
using FEMS.Database;
using System;
using System.Web.Mvc;

namespace FEMS.Controllers
{
    public class ProjectsController : Controller
    {

        private ProjectsControllerManager ProjectsControllerManager;
        private DateValidate DateValidate;

        public ProjectsController()
        {
            ProjectsControllerManager = new ProjectsControllerManager();
        }
       
        //
        [Authorize(Roles = "Admin,Manager,Client")]
        // GET: Projects
        public ActionResult Index()
        {
            try
            {
                return View(ProjectsControllerManager.getAllProjects());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        //
        [Authorize(Roles = "Admin,Manager,Client")]
        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(ProjectsControllerManager.getProject(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //
        [Authorize(Roles = "Client")]
        // GET: Projects/Create
        public ActionResult Create()
        {
            try
            {
                return View(ProjectsControllerManager.getProjectWithClientId());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(project project)
        {
            try
            {
                DateValidate = new DateValidate();
                if (ModelState.IsValid)
                {
                    if (DateValidate.IsDateLessThanToday(project.project_assign_date) && DateValidate.IsDateLessThanToday(project.project_deadline))
                    {
                        ProjectsControllerManager.saveProject(project);
                        return RedirectToAction("Index", "Projects");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Project assign date or deadline is invalid");
                        return View();
                    }

                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //
        [Authorize(Roles = "Admin")]
        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.approval = ProjectsControllerManager.getProjectApproval();
                return View(ProjectsControllerManager.getProject(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, project project)
        {
            try
            {
                DateValidate = new DateValidate();
                if (ModelState.IsValid)
                {
                    int flag = ProjectsControllerManager.updateProject(id, project);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.approval = ProjectsControllerManager.getProjectApproval();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //
        [Authorize(Roles = "Admin")]
        // GET: Projects/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(ProjectsControllerManager.getProject(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Projects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, project project)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    int flag = ProjectsControllerManager.deleteProject(id, project);
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

        [Authorize(Roles ="Admin")]
        // GET: Projects/AddTask/5
        public ActionResult AddTask(int id)
        {
            try
            {
                return View(ProjectsControllerManager.getTaskWithProjectId(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //POST: Project/AddTak/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTask(task task)
        {
           try
            {
                DateValidate = new DateValidate();
                if (ModelState.IsValid)
                {
                    if (DateValidate.IsDateLessThanToday(task.task_started_date) && DateValidate.IsDateLessThanToday(task.task_end_date))
                    {
                        int flag = ProjectsControllerManager.saveTask(task);
                        if (flag == 1)
                        {
                            return RedirectToAction("Index", "Projects");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Task name is already taken, Please use unique Task Names");
                            return View();
                        }
                       
                    }
                    else
                    {
                        ModelState.AddModelError("", "Dates are Invalid");
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Projects/PendingProjects
        public ActionResult PendingProjects()
        {
            try
            {
                return View(ProjectsControllerManager.getPendingProjects());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
