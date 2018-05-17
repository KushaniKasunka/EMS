using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.emp_progresses = new HashSet<Emp_Progress>();
            this.emp_task_ref = new HashSet<Emp_task_ref>();
        }

        public int emp_id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string emp_fname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string emp_lname { get; set; }

        [Display(Name = "NIC")]
        [Required(ErrorMessage = "NIC is Required")]
        public string emp_nic { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date)]
        public string emp_dob { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is Required")]
        public string emp_gender { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string emp_address { get; set; }

        [Display(Name = "Mobile No.")]
        [Phone]
        [Required(ErrorMessage = "Mobile is Required")]
        public string emp_mobile { get; set; }

        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Designation is Required")]
        public string emp_designation { get; set; }

        [Display(Name = "Work started Date")]
        [Required(ErrorMessage = "Work started Date is Required")]
        [DataType(DataType.Date)]
        public string emp_work_started_date { get; set; }

        //Common data
        public int emp_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_Progress> emp_progresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_task_ref> emp_task_ref { get; set; }
    }
}