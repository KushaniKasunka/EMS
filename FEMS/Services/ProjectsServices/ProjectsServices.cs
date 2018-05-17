using FEMS.Database;
using FEMS.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Services.ProjectsServices
{
    public class ProjectsServices
    {
        private EMSEntities db;

        public ProjectsServices()
        {
            db = new EMSEntities();
        }

        //select all
        public List<project> getAllProjectsDB()
        {
            try
            {
                if (HttpContext.Current.User.IsInRole("Client"))
                {
                    return db.projects.Where(p => p.project_status == 1 && p.client.client_username.Equals(HttpContext.Current.User.Identity.Name)).ToList();
                }
                else
                {
                    return db.projects.Where(p => p.project_status == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select
        public project getProjectDB(int id)
        {
            try
            {
                return db.projects.Where(p => p.project_id == id && p.project_status == 1).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert
        public void saveProjectDB(project project)
        {
            try
            {
                db.projects.Add(project);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateProjectDB(int id, project project)
        {
            int flag = 0;
            try
            {
                var result = db.projects.Where(p => p.project_id == id && p.project_status == 1).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //delete
        public int deleteProjectDB(int id, project project)
        {
            int flag = 0;
            try
            {
                var result = db.projects.Where(p => p.project_id == id && p.project_status == 1).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public project getProjectWithClientIdDB()
        {
            client client = null;
            project project = new project();
            try
            {
                client = db.clients.Where(c => c.client_username.Equals(HttpContext.Current.User.Identity.Name) &&
                c.client_status == 1).FirstOrDefault();
                project.client_id = client.client_id;
                project.project_approval_status = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return project;
        }

        public task getTaskWithProjectIdDB(int id)
        {
            task task = new task();
            try
            {
                task.project_id = id;
                task.task_state = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return task;
        }

        public int saveTaskDB(task task)
        {
            int flag = 0;
            try
            {
                var result = db.tasks.Where(t => t.task_name.Equals(task.task_name)).FirstOrDefault();
                if (result == null)
                {
                    db.tasks.Add(task);
                    db.SaveChanges();
                    flag = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        public SelectList getProjectApprovalDB()
        {
            try
            {
                EnumForViews EnumForViews = new EnumForViews();
                return EnumToSelectList.ToSelectList(typeof(EnumForViews.Approval), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<project> getPendingProjectsDB()
        {
            try
            {
                return db.projects.Where(p => p.project_approval_status == 1 && p.project_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}