using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class DetailResult
    {
        public int idUser { get; set; }
        public string account { get; set; }
        public string userName { get; set; }
        public int idTask { get; set; }
        public string taskName { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public float total { get; set; }
        public float resultToday { get; set; }
    }
}
