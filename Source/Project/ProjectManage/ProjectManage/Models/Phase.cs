//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phase
    {
        public Phase()
        {
            this.Tasks = new HashSet<Task>();
        }
    
        public int id_phase { get; set; }
        public string phase_name { get; set; }
        public string description { get; set; }
        public int id_project { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public string status_phase { get; set; }
    
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
