using FEMS.Database;
using FEMS.Services.EmployeeProgressesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.ControllerManager.EmployeeProgressesControllerManager
{
    public class EmployeeProgressesControllerManager
    {
        private EmployeeProgressesServices EmployeeProgressesServices;

        public EmployeeProgressesControllerManager()
        {
            EmployeeProgressesServices = new EmployeeProgressesServices();
        }

        public List<emp_progresses> getAllProgress()
        {
            try
            {
                return EmployeeProgressesServices.getAllProgressDB();
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        public emp_progresses getProgress(int id)
        {
            try
            {
                return EmployeeProgressesServices.getProgressDB(id);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        public int saveProgress(emp_progresses progress)
        {
            try
            {
                progress.emp_progress_status = 1;
                progress.emp_progress_month_year = progress.emp_progress_month_year.Substring(0, 7);
                return EmployeeProgressesServices.saveProgressDB(progress);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        public int updateProgress(int id, emp_progresses emp_progresses)
        {
            try
            {
                emp_progresses.emp_progress_month_year = emp_progresses.emp_progress_month_year.Substring(0, 7);
                return EmployeeProgressesServices.updateProgressDB(id, emp_progresses);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public int deleteProgress(int id, emp_progresses progress)
        {
            try
            {
                progress.emp_progress_status = 0;
                return EmployeeProgressesServices.deleteProgressDB(id, progress);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public SelectList getMonth()
        {
            try
            {
                return EmployeeProgressesServices.getMonthDB();
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}