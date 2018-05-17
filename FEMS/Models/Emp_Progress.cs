using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Emp_Progress
    {
        public int emp_progress_id { get; set; }

        [Display(Name = "No of Working hrs")]
        [Required(ErrorMessage = "No of Working hrs are Required")]
        public string emp_progress_working_hrs { get; set; }

        [Display(Name = " Month of Year ")]
        [Required(ErrorMessage = "Month of Year are Required")]
        [DataType(DataType.Date)]
        public System.DateTime emp_progress_month_year { get; set; }

        [Display(Name = " No of Nopay Days ")]
        [Range(0,int.MaxValue, ErrorMessage = "No of Nopay Days should be positive value")]
        public int emp_progress_nopay_days { get; set; }

        //common data
        public int emp_progress_status { get; set; }

        //foriegn key
        public int emp_id { get; set; }
        [Display(Name = " Project Name ")]
        [Required(ErrorMessage = "Project Name should be selected")]
        public int project_id { get; set; }

        public virtual Employee employee { get; set; }
        public virtual Project project { get; set; }
    }
}