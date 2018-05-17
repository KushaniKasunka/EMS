using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Emp_task_ref
    {
        public int emp_task_ref_id { get; set; }

        //foreign key
        public int emp_id { get; set; }
        [Required(ErrorMessage ="Task Should be Selected")]
        public int task_id { get; set; }

        public virtual Employee employee { get; set; }
        public virtual Task task { get; set; }
    }
}