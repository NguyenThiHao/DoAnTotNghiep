using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManage.Common
{
    [Serializable]
    public class UserLogin
    {
        public int idUser { get; set; }
        public string account { get; set; }

        public string idGroupUser { get; set; }
    }
}