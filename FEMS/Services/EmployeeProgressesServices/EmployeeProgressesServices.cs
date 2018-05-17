using FEMS.Database;
using FEMS.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.Services.EmployeeProgressesServices
{
    public class EmployeeProgressesServices
    {
        private EMSEntities db;

        public EmployeeProgressesServices()
        {
            db = new EMSEntities();
        }

        //select*
        public List<emp_progresses> getAllProgressDB()
        {
            try
            {
                return db.emp_progresses.Where(p => p.emp_progress_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select
        public emp_progresses getProgressDB(int id)
        {
            try
            {
                return db.emp_progresses.Where(p => p.emp_progress_id == id && p.emp_progress_status == 1).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert
        public int saveProgressDB(emp_progresses progress)
        {
            try
            {
                db.emp_progresses.Add(progress);
                return db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update
        public int updateProgressDB(int id, emp_progresses emp_progresses)
        {
            int flag = 0;
            try
            {
                var result = db.emp_progresses.Where(p => p.emp_progress_id == id && p.emp_progress_status == 1).FirstOrDefault();
                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(emp_progresses).State = EntityState.Modified;
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
        public int deleteProgressDB(int id, emp_progresses progress)
        {
            int flag = 0;
            try
            {
                var result = db.emp_progresses.Where(p => p.emp_progress_id == id && p.emp_progress_status == 1);
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

        public SelectList getMonthDB()
        {
            try
            {
                EnumForViews EnumForViews = new EnumForViews();
                return EnumToSelectList.ToSelectList(typeof(EnumForViews.Month), "0");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}