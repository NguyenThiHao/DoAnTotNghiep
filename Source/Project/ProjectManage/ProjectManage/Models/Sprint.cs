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
    
    public partial class Sprint
    {
        public int id_sprint { get; set; }
        public string name_sprint { get; set; }
        public string id_phase { get; set; }
        public System.DateTime plan_start_date { get; set; }
        public System.DateTime plan_end_date { get; set; }
        public int estimate_time { get; set; }
        public System.DateTime real_start_date { get; set; }
        public System.DateTime real_end_date { get; set; }
        public int reporter { get; set; }
        public string description { get; set; }
        public int type { get; set; }
        public string link { get; set; }
        public int status { get; set; }
    }
}
