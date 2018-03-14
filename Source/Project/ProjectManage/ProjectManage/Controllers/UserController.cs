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
            //Kiểm tra tất cả Validation
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu vào bảng User
                db.Users.Add(user);   //Chưa lưu vào CSDL, mới chỉ lưu vào Models, là cái ánh xạ của CSDL
                //Lưu vào CSDL
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            // Lấy giá trị Account từ form đăng nhập
            string sAccount = f.Get("txtAccount").ToString();
            //Lấy giá trị Password từ form đăng nhập
            string sPass = f.Get("txtPassword").ToString();
            //So sánh Account và Password nhập vào với acc và pass trong DB
            User user = db.Users.SingleOrDefault(n=> n.account == sAccount && n.password == sPass);
            if (user != null)
            {
                Session["Account"] = user;
                return Redirect("Home/Home");
            }
            ViewBag.Mess = "Account or Password is incorrect!";
            return View();
        }
	}
}