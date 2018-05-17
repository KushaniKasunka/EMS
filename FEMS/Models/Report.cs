using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Report
    {
        [Display(Name ="Client Company")]
        public int client_id { get; set; }

        [Display(Name = "Employee Name")]
        public int emp_id { get; set; }

        [Required(ErrorMessage = "Date From is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date From")]
        public string reportDateFrom { get; set; }

        [Required(ErrorMessage = "Date To is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date To")]
        public string reportDateTo { get; set; }
    }
}