using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Project_progress
    {
        public int progress_id { get; set; }

        [Display(Name = "No of Tasks")]
        [Required(ErrorMessage = "No of Tasks is Required")]
        public int no_of_tasks { get; set; }

        [Display(Name = "No of Days Remaining")]
        [Required(ErrorMessage = "No of Days Remaining is Required")]
        public int days_remaining { get; set; }

        [Display(Name = "No of Finished Tasks")]
        [Required(ErrorMessage = "No of Finished Tasks is Required")]
        public int no_of_finished_tasks { get; set; }

        //foriegn key
        public int project_id { get; set; }

        public virtual Project project { get; set; }
    }
}