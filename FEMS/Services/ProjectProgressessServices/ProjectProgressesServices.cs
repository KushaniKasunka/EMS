using FEMS.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FEMS.Services.ProjectProgressessServices
{
    public class ProjectProgressesServices
    {
        private EMSEntities db;

        public ProjectProgressesServices()
        {
            db = new EMSEntities();
        }

        //select*
        public List<project_progress> getAllProjectsProgresesDB()
        {
            try
            {
                return db.project_progress.Where(p => p.progress_id == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select method
        public project_progress getProjectProgressDB(int id)
        {
            try
            {
                return db.project_progress.Where(p => p.progress_id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public void saveProjectProgressDB(project_progress progress)
        {
            try
            {
                db.project_progress.Add(progress);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateProjectProgressDB(int id, project_progress progress)
        {
            int flag = 0;
            try
            {
                var result = db.project_progress.Where(p => p.progress_id == id).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(progress).State = EntityState.Modified;
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

        //delete method
        public int deleteProjectProgressDB(int id, project_progress progress)
        {
            int flag = 0;
            try
            {
                var result = db.project_progress.Where(p => p.progress_id == id).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(progress).State = EntityState.Modified;
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

        public project_progress getProgressWithProjectIdDB(int id)
        {
            try
            {
                project_progress project_progress = new project_progress();
                project_progress.project_id = id;
                return project_progress;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}