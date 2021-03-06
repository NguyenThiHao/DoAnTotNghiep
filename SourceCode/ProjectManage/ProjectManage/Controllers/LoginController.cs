﻿using System;
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
        //Tạo ra 1 userSession
        public UserLogin userSession = new UserLogin();
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
                var result = dao.Login(model.account, Encryptor.MD5Hash(model.password), false);
                if (result == 1)
                {
                    //lấy ra user theo account
                    var user = dao.GetUserByAccount(model.account);
                    //khởi tạo giá trị cho userSession lấy từ user
                    userSession.account = user.account;
                    
                    userSession.idUser = user.idUser;
                    userSession.idGroupUser = user.idGroupUser;
                    var listCredetial = dao.GetListCredential(model.account);
                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredetial);
                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    Session["userName"] = user.userName;
                    Session["idUser"] = user.idUser;
                    if (model.rememberMe == true)
                    {
                        HttpCookie ck = new HttpCookie("user.account");
                        ck.Expires = DateTime.Now.AddDays(15);
                        Response.Cookies.Add(ck);
                    }
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
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Your account does not have administrator!");
                }
            }
            return View("Login");
        }
    }
}