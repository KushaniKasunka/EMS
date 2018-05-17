using FEMS.Database;
using FEMS.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Services.TasksServices
{
    public class TasksServices
    {
        private EMSEntities db;

        public TasksServices()
        {
            db = new EMSEntities();
        }

        //select all
        public List<task> getAllTasksDB()
        {
            try
            {
                return db.tasks.Where(t => t.task_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select task for projects
        public List<task> GetTaskForProjectDB(int id)
        {
            try
            {
                return db.tasks.Where(t => t.task_status == 1 && t.project_id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select
        public task getTaskDB(int id)
        {
            try
            {
                return db.tasks.Where(t => t.task_id == id && t.task_status == 1).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update method
        public int updateTaskDB(int id, task task)
        {
            int flag = 0;
            try
            {
                var result = db.tasks.Where(t => t.task_id == id && t.task_status == 1).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(task).State = EntityState.Modified;
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
        public int deleteTaskDB(int id, task task)
        {
            int flag = 0;
            try
            {
                var result = db.tasks.Where(t => t.task_id == id && t.task_status == 1).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(task).State = EntityState.Modified;
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

        //set Task State
        public SelectList getTaskStateDB()
        {
            try
            {
                EnumForViews EnumForViews = new EnumForViews();
                return EnumToSelectList.ToSelectList(typeof(EnumForViews.TaskState), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}