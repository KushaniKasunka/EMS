using CrystalDecisions.CrystalReports.Engine;
using FEMS.ControllerManager.ClientsControllerManager;
using FEMS.Database;
using System.IO;
using System.Web.Mvc;
using System.Linq;
using System;

namespace FEMS.Controllers
{
    public class ClientsController : Controller
    {
        private ClientsControllerManager ClientsControllerManager;

        public ClientsController()
        {
            ClientsControllerManager = new ClientsControllerManager();
        }

        [Authorize(Roles ="Admin,Manager")]
        // GET: Clients
        public ActionResult Index()
        {
            try
            {
                return View(ClientsControllerManager.getAllClients());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //
        [Authorize(Roles = "Admin")]
        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(ClientsControllerManager.getClient(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //
        [Authorize(Roles = "Client")]
        // GET: Clients/Create
        public ActionResult Create()
        {
            try
            {
                return View(new client() { client_username = HttpContext.User.Identity.Name });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = ClientsControllerManager.saveClient(client);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index", "Projects");
                    }
                    else
                    {
                        TempData["client_nic"] = "That NIC already registered. Use different one.";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //
        [Authorize(Roles = "Admin")]
        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(ClientsControllerManager.getClient(id));
            }

            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = ClientsControllerManager.updateClient(id, client);
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

        //
        [Authorize(Roles = "Admin")]
        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(ClientsControllerManager.getClient(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }

        // POST: Clients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = ClientsControllerManager.deleteClient(id, client);
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

        //GET/Clients/getProjectReport/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult getProjectReport(int id)
        {
            EMSEntities db = new EMSEntities();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/ProjectReport.rpt")));
            rd.SetDataSource(db.projects.Select(p=> new {
                project_id = p.project_id,
                project_name = p.project_name,
                project_location = p.project_location,
                project_budget = p.project_budget,
                project_assign_date = p.project_assign_date,
                project_deadline = p.project_deadline,
                client_id = p.client_id
            }).ToList().Where(p => p.client_id == id));
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream,"application/pdf", "Projects_of_Client.pdf");
        }
    }
}
