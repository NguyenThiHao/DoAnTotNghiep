using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ProjectManage.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "{0} must not be empty! ")]  //Kiểm tra rỗng
        public string account { get; set; }

        [Required(ErrorMessage = "{0} must not be empty! ")]  //Kiểm tra rỗng
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}