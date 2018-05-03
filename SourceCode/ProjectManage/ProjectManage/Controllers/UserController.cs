using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using ProjectManage.Common;

namespace ProjectManage.Controllers
{
    public class UserController : BaseController
    {
        #region Create User
        [HasCredential(RoleID = "CREATE_USER")]
        //Thêm mới 1 user
        public ActionResult CreateUser(User user)
        {
            //Kiểm tra validation
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryteMd5Pas = Encryptor.MD5Hash(user.password);
                user.password = encryteMd5Pas;
                long idUser = dao.CreateUser(user);
                if (idUser > 0)
                {
                    SetAlert("Create user suscessful!", "success");
                    return RedirectToAction("Detail", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Create user failed!");
                }
            }
            return View("CreateUser");
        }

        #endregion

        //Xem chi tiết 1 user
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult DetailUser(int idUser)
        {       
            return View();
        }

        #region Edit User: Chỉnh sửa thông tin User
        //Load trang Edit user, truyền vào tham số idUser
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult EditUser(int idUser)
        {
            var user = new UserDao().GetUserById(idUser);
            return View(user);
        }

        [HttpPost]
        //Chỉnh sửa user
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult EditUser(User user)
        {
            //Kiểm tra validation
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //So sánh nếu như thay đổi mật khẩu của user thì mới thực hiện mã hóa MD5
                if (!string.IsNullOrEmpty(user.password))
                {
                    var encryteMd5Pas = Encryptor.MD5Hash(user.password);
                    user.password = encryteMd5Pas;
                }
                //Edit user
                var result = dao.EditUser(user);
                if (result)
                {
                    SetAlert("Edit user suscessful!", "success");
                    return RedirectToAction("Detail", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Edit user failed!");
                }
            }
            return View("EditUser");
        }
        #endregion

    }
}