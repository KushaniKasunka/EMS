using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.emp_task_ref = new HashSet<Emp_task_ref>();
        }

        [Required(ErrorMessage = "Task should be assigned")]
        public int task_id { get; set; }

        [Display(Name = "Task Name")]
        [Required(ErrorMessage = "Task Name is Required")]
        public string task_name { get; set; }

        [Display(Name = "Task Description")]
        [Required(ErrorMessage = "Task Description is Required")]
        public string task_description { get; set; }

        [Display(Name = "Task Started Date")]
        [Required(ErrorMessage = "Task Started Date is Required")]
        [DataType(DataType.Date)]
        public string task_started_date { get; set; }

        [Display(Name = "Task End Date")]
        [Required(ErrorMessage = "Task End Date is Required")]
        [DataType(DataType.Date)]
        public string task_end_date { get; set; }

        [Display(Name = "Task State")]
        [Required(ErrorMessage = "Task State is Required")]
        public int task_state { get; set; }

        //common data
        public int task_status { get; set; }

        //foriegn key
        public int project_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_task_ref> emp_task_ref { get; set; }
        public virtual Project project { get; set; }
    }
}