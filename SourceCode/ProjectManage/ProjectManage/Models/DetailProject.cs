using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManage.Models
{
    //Class chi tiết project
    public class DetailProject
    {
        public int idProject { get; set; }
        public string projectName { get; set; }
        public int idLeader { get; set; }
        public string leaderName { get; set; }
        public string description { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string status { get; set; }
        public string typeProject { get; set; }
        public int totalPhase { get; set; }
        public int totalTask { get; set; }
        public int totalMembers { get; set; }

    }
}