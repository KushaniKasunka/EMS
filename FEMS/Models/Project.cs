using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.emp_progresses = new HashSet<Emp_Progress>();
            this.project_progress = new HashSet<Project_progress>();
            this.tasks = new HashSet<Task>();
        }

        public int project_id { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Project Description is Required")]
        public string project_name { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Project Location is Required")]
        public string project_location { get; set; }

        [Display(Name = "Budget")]
        [Required(ErrorMessage = "Project Budget is Required")]
        public string project_budget { get; set; }

        [Display(Name = "Assigned Date")]
        [Required(ErrorMessage = "Project Assigned Date is Required")]
        [DataType(DataType.Date)]
        public System.DateTime project_assign_date { get; set; }

        [Display(Name = "Deadline")]
        [Required(ErrorMessage = "Project Deadline is Required")]
        [DataType(DataType.Date)]
        public System.DateTime project_deadline { get; set; }

        [Display(Name = "Approval Status")]
        [Required(ErrorMessage = "Project Approval Status is Required")]
        public int project_approval_status { get; set; }

        //common data
        public int project_status { get; set; }

        //foriegn key
        public int client_id { get; set; }

        public virtual Client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_Progress> emp_progresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project_progress> project_progress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> tasks { get; set; }
    }
}