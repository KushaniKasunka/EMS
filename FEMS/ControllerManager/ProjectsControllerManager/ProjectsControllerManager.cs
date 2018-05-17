using FEMS.Database;
using FEMS.Services.ProjectsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.ControllerManager.ProjectsControllerManager
{
    public class ProjectsControllerManager
    {
        private ProjectsServices ProjectsServices;

        public ProjectsControllerManager()
        {
            ProjectsServices = new ProjectsServices();
        }

        //select*
        public List<project> getAllProjects()
        {
            try
            {
                return ProjectsServices.getAllProjectsDB();
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        //select
        public project getProject(int id)
        {
            try
            {
                return ProjectsServices.getProjectDB(id);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        //insert
        public void saveProject(project project)
        {
            try
            {
                project.project_status = 1;
                ProjectsServices.saveProjectDB(project);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        //update
        public int updateProject(int id, project project)
        {
            try
            {
                return ProjectsServices.updateProjectDB(id, project);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        //delete
        public int deleteProject(int id, project project)
        {
            try
            {
                project.project_status = 0;
                return ProjectsServices.deleteProjectDB(id, project);
            }
            catch(Exception)
            {
                throw;
            }
          
        }

        public project getProjectWithClientId()
        {
            try
            {
                return ProjectsServices.getProjectWithClientIdDB();
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public task getTaskWithProjectId(int id)
        {
            try
            {
                return ProjectsServices.getTaskWithProjectIdDB(id);
            }
            catch(Exception)
            {
                throw;
            }         
        }

        public int saveTask(task task)
        {
            try
            {
                task.task_status = 1;
                return ProjectsServices.saveTaskDB(task);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        public SelectList getProjectApproval()
        {
            try
            {
                return ProjectsServices.getProjectApprovalDB();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<project> getPendingProjects()
        {
            try
            {
                return ProjectsServices.getPendingProjectsDB();

            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}