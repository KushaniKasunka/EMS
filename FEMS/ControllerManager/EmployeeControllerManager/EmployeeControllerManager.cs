using FEMS.Database;
using FEMS.Services.EmployeesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEMS.ControllerManager.EmployeeControllerManager
{
    public class EmployeeControllerManager
    {
        private EmployeesServices EmployeesServices;

        public EmployeeControllerManager()
        {
            EmployeesServices = new EmployeesServices();
        }

        //select*
        public List<employee> getAllEmp()
        {
            try { return EmployeesServices.getAllEmpDB(); }
            catch (Exception)
            {
                throw;
            }
           
        }

        //select
        public employee getEmp(int id)
        {
            try
            {
                return EmployeesServices.getEmpDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert
        public int saveEmp(employee employee)
        {
            try
            {
                employee.emp_status = 1;
                return EmployeesServices.saveEmpDB(employee);
            }
            catch(Exception)
            {
                throw;
            }
        }

        //update
        public int updateEmp(int id, employee employee)
        {
            try
            {
                return EmployeesServices.updateEmpDB(id, employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //delete
        public int deleteEmp(int id, employee employee)
        {
            try
            {
                employee.emp_status = 0;
                return EmployeesServices.deleteEmpDB(id, employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SelectList getEmpGender()
        {
            try
            {
                return EmployeesServices.getEmpGenderDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SelectList getEmpDes()
        {
            try
            {
                return EmployeesServices.getEmpDesDB();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public emp_task_ref getTaskWithEmployeeId(int id)
        {
            try
            {
                return EmployeesServices.getTaskWithEmployeeIdDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SelectList getAllTasks()
        {try
            {
                return EmployeesServices.getAllTasksDB();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void saveEmp_Task(emp_task_ref emp_task_ref)
        {
            try
            {
                EmployeesServices.saveEmp_TaskDB(emp_task_ref);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public emp_progresses getProgressWithEmpId(int id)
        {try
            {
                return EmployeesServices.getProgressWithEmpIdDB(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SelectList getPorjectList()
        {
            try
            {
                return EmployeesServices.getPorjectListDB();
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public int saveProgress(emp_progresses emp_progresses)
        {
            try
            {
                emp_progresses.emp_progress_status = 1;
                emp_progresses.emp_progress_month_year = emp_progresses.emp_progress_month_year.Substring(0, 7);
                return EmployeesServices.saveProgressDB(emp_progresses);
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}