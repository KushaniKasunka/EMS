using FEMS.Database;
using FEMS.Services.TasksServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.ControllerManager.TasksControllerManager
{
    public class TasksControllerManager
    {
        private TasksServices TasksServices;

        public TasksControllerManager()
        {
            TasksServices = new TasksServices();
        }

        //select all
        public List<task> getAllTasks()
        {
            try
            {
                return TasksServices.getAllTasksDB();
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        //select task for projects
        public List<task> GetTaskForProject(int id)
        {
            try
            {
                return TasksServices.GetTaskForProjectDB(id);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        //select
        public task getTask(int id)
        {
            try
            {
                return TasksServices.getTaskDB(id);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        //update method
        public int updateTask(int id, task task)
        {
            try
            {
                return TasksServices.updateTaskDB(id, task);
            }
           catch(Exception)
            {
                throw;
            }
        }

        //delete
        public int deleteTask(int id, task task)
        {
            try
            {
                task.task_status = 0;
                return TasksServices.deleteTaskDB(id, task);
            }
            catch(Exception)
            {
                throw;
            }
        }

        //set Task State
        public SelectList getTaskState()
        {
            try
            {
                return TasksServices.getTaskStateDB();
            }
            catch
            {
                throw;
            }
        }
    }
}