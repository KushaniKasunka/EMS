using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEMS.Models
{
    public class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.projects = new HashSet<Project>();
        }

        public int client_id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string client_fname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string client_lname { get; set; }

        [Display(Name = "NIC")]
        [Required(ErrorMessage = "NIC is Required")]
        public string client_nic { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string client_address { get; set; }

        [Display(Name = "Mobile")]
        [Phone]
        [Required(ErrorMessage = "Mobile number is Required")]
        public string client_mobile { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company name is Required")]
        public string client_company { get; set; }

        [Display(Name = "Username")]
        public string client_username { get; set; }

          //common data
        public int client_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> projects { get; set; }
    }
}