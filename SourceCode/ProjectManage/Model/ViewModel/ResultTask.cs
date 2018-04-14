using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ResultTask
    {
        public int idTask { get; set; }
        public string taskName { get; set; }
        public DateTime date { get; set; }
        public string summary { get; set; }
        public int idUser { get; set; }
        public string userName { get; set; }
        public string account { get; set; }
        public string description { get; set; }
        public double resultToday { get; set; }
        public string type { get; set; }
    }
}
