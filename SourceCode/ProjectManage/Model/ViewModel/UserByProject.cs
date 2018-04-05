using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class UserByProject
    {
        public int? idProject { get; set; }
        public string projectName { get; set; }
        public int idUser { get; set; }
        public string userName { get; set; }

        public string account { get; set; }
        public string position { get; set; }
        public int idGroup { get; set; }
        public string groupName { get; set;  }

        public DateTime? joinedDate { get; set; }
        public string status { get; set; }

    }
}
