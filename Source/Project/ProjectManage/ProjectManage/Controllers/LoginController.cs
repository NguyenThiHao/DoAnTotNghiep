using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;
using Model.Dao;
using ProjectManage.Common;
using System.Data.Entity;

namespace ProjectManage.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/
        public ActionResult Login(LoginModel model)
        {
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.account, model.password);
                if (result)
                {
                    //lấy ra user theo account
                    var user = dao.GetUserById(model.account);
                    //Tạo ra 1 userSession
                    var userSession  = new UserLogin();
                    //khởi tạo giá trị cho userSession lấy từ user
                    userSession.account = user.account;
                    userSession.idUser = user.idUser;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //Đăng nhập thành công trả về trang chủ
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    //Trả về messege thông báo lỗi
                    ModelState.AddModelError("", "Login failed!");
                }
            }
            return View("Login");
        }
	}
}