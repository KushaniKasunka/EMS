//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FEMS.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Models;
    [MetadataType(typeof(Task))]

    public partial class task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public task()
        {
            this.emp_task_ref = new HashSet<emp_task_ref>();
        }
    
        public int task_id { get; set; }
        public string task_name { get; set; }
        public string task_description { get; set; }
        public string task_started_date { get; set; }
        public string task_end_date { get; set; }
        public int task_state { get; set; }
        public int task_status { get; set; }
        public int project_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emp_task_ref> emp_task_ref { get; set; }
        public virtual project project { get; set; }
    }
}
