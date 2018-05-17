using FEMS.Database;
using System;
using FEMS.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Services.EmployeesServices
{
    public class EmployeesServices
    {
        private EMSEntities db;

        public EmployeesServices()
        {
            db = new EMSEntities();
        }

        //select*
        public List<employee> getAllEmpDB()
        {
            try
            {
                return db.employees.Where(e => e.emp_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select
        public employee getEmpDB(int id)
        {
            try
            {
                return db.employees.Where(e => e.emp_id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert
        public int saveEmpDB(employee employee)
        {
            try
            {
                int flag = 0;
                var result = db.employees.Where(e => e.emp_nic.Equals(employee.emp_nic)).FirstOrDefault();
                if (result == null)
                {
                    db.employees.Add(employee);
                    db.SaveChanges();
                    flag = 1;
                }
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update
        public int updateEmpDB(int id, employee employee)
        {
            try
            {
                int flag = 0;
                var result = db.employees.Where(e => e.emp_id == id && e.emp_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete
        public int deleteEmpDB(int id, employee employee)
        {
            try
            {
                int flag = 0;
                var result = db.employees.Where(e => e.emp_id == id && e.emp_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SelectList getEmpGenderDB()
        {
            try
            {
                EnumForViews EnumForViews = new EnumForViews();
                return EnumToSelectList.ToSelectList(typeof(EnumForViews.Gender), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SelectList getEmpDesDB()
        {
            try
            {
                EnumForViews EnumForViews = new EnumForViews();
                return EnumToSelectList.ToSelectList(typeof(EnumForViews.Designation), "0");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public emp_task_ref getTaskWithEmployeeIdDB(int id)
        {
            try
            {
                emp_task_ref emp_task_ref = new emp_task_ref();
                emp_task_ref.emp_id = id;
                return emp_task_ref;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SelectList getAllTasksDB()
        {
            try
            {
                return new SelectList(db.tasks.Where(t => t.task_status == 1 && t.task_state == 1).OrderBy(p => p.project_id), "task_id", "task_name");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void saveEmp_TaskDB(emp_task_ref emp_task_ref)
        {
            try
            {
                db.emp_task_ref.Add(emp_task_ref);
                db.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public emp_progresses getProgressWithEmpIdDB(int id)
        {
            try
            {
                emp_progresses emp_progresses = new emp_progresses();
                emp_progresses.emp_id = id;
                emp_progresses.emp_progress_status = 1;
                return emp_progresses;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public SelectList getPorjectListDB()
        {
            try
            {
                return new SelectList(db.projects.Where(p => p.project_status == 1).OrderBy(p => p.project_name), "project_id", "project_name");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int saveProgressDB(emp_progresses emp_progresses)
        {
            int flag = 0;
            try
            {
                db.emp_progresses.Add(emp_progresses);
                db.SaveChanges();
                flag = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }
    }
}