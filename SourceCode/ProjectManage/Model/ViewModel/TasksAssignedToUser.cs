using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.ViewModel
{
    public class TasksAssignedToUser
    {
        public int idProject { get; set; }
        public string projectName { get; set; }
        public int idPhase { get; set; }
        public int idSprint { get; set; }
        public string sprintName { get; set; }
        public int idTask { get; set; }
        public int idAssignee { get; set; }
        public string accountAssignee { get; set; }
        public string nameAssignee { get; set; }
        public string taskName { get; set; }
        public string summary { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime due { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public int idReporter { get; set; }
        public string accountReporter { get; set; }
        public string nameReporter { get; set; }
        public double estimateTime { get; set; }
        //Thời gian còn lại
        public double remaining { get; set; }
        //Thời gian đã logwork trong 1 task
        public double loggedTime { get; set; }
    }
}