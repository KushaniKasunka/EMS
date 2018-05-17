using FEMS.Database;
using FEMS.Services.ProjectProgressessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEMS.ControllerManager.ProjectProgressesControllerManager
{
    public class ProjectProgressesControllerManager
    {
        private ProjectProgressesServices ProjectProgressesServices;

        public ProjectProgressesControllerManager()
        {
            ProjectProgressesServices = new ProjectProgressesServices();
        }

        //select*
        public List<project_progress> getAllProjectsProgreses()
        {
            try
            {
                return ProjectProgressesServices.getAllProjectsProgresesDB();
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        //select method
        public project_progress getProjectProgress(int id)
        {
            try
            {
                return ProjectProgressesServices.getProjectProgressDB(id);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        //insert method
        public void saveProjectProgress(project_progress progress)
        {
            try
            {
                ProjectProgressesServices.saveProjectProgressDB(progress);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        //update method
        public int updateProjectProgress(int id, project_progress progress)
        {
            try
            {
                return ProjectProgressesServices.updateProjectProgressDB(id, progress);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        public int deleteProjectProgress(int id, project_progress progress)
        {
            try
            {
                return ProjectProgressesServices.deleteProjectProgressDB(id, progress);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public project_progress getProgressWithProjectId(int id)
        {
            try
            {
                return ProjectProgressesServices.getProgressWithProjectIdDB(id);
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}