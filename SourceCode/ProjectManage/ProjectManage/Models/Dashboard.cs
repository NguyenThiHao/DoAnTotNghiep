using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManage.Models
{
    //Chi tiết của một user trong 1 project
    public class Dashboard
    {
        public int idProject { get; set; }
        public string projectName { get; set; }
        public int idUser { get; set; }
        public string userName { get; set; }
        public string position { get; set; }
        public DateTime? joinedDate { get; set; }
        public DateTime? leaveDate { get; set; }
        public long status { get; set; }
    }
}