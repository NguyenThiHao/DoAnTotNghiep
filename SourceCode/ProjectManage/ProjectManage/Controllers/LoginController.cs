using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Common;
using Model.Dao;
using ProjectManage.Models;


namespace ProjectManage.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.account, Encryptor.MD5Hash(model.password));
                if (result == 1)
                {
                    //lấy ra user theo account
                    var user = dao.GetUserByAccount(model.account);
                    //Tạo ra 1 userSession
                    var userSession = new UserLogin();
                    //khởi tạo giá trị cho userSession lấy từ user
                    userSession.account = user.account;
                    userSession.idUser = user.idUser;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //Đăng nhập thành công trả về trang chủ
                    return RedirectToAction("Dashboard", "PositionUser", new {idUser = userSession.idUser });
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account is not exist!");


                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account is locked!");


                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Password is incorrect!");
                }
            }
            return View("Login");
        }
    }
}