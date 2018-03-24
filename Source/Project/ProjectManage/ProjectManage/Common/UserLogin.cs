using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectManage.Common
{
    [Serializable]
    public class UserLogin
    {
        public int idUser { get; set;}
        public string account { get; set; }

        public string password { get; set; }
    }
}