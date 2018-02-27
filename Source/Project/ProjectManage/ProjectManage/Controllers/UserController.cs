using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class UserController : Controller
    {
        //Khởi tạo DB
        ProjectManageEntities db = new ProjectManageEntities();
        //
        // GET: /User/
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            //Chèn dữ liệu vào bảng User
            db.Users.Add(user);   //Chưa lưu vào CSDL, mới chỉ lưu vào Models, là cái ánh xạ của CSDL
            //Lưu vào CSDL
            db.SaveChanges();
            return View();
        }

        public ActionResult CreateUser1()
        {
            return View();
        }
	}
}