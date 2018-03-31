using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManage.Models
{
    public class TasksAssignedToUser
    {
        public int idProject { get; set; }
        public int idPhase { get; set; }
        public int idSprint { get; set; }
        public int idTask { get; set; }
        public int idUser { get; set; }
        public string taskName { get; set; }
        public string summary { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime due { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
    }
}