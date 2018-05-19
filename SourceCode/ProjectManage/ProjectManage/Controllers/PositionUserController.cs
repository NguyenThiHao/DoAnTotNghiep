using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Model.ViewModel;
using ProjectManage.Models;
using ProjectManage.Controllers;
using ProjectManage.Common;

namespace ProjectManage.Controllers
{
    public class PositionUserController : BaseController
    {
        #region View Dashboard: Danh sách các Project mà 1 User đang tham gia
        public ActionResult Dashboard(int idUser)
        {
            //Lấy ra danh sách project mà user đang tham gia
            var listProjectJoined = new PositionUserDao().ListProjectJoined(idUser);



            //Khởi tạo 1 list<Dashboard> lưu trữ
            List<Dashboard> listDashboard = new List<Dashboard>();
            foreach (var item in listProjectJoined)
            {
                //Khởi tạo class 1 Dashboard để lấy ra chi tiết hơn
                Dashboard dashboard = new Dashboard();
                //lấy ra tên của Project
                dashboard.projectName = new ProjectDao().GetProjectName(item.idProject);
                dashboard.idProject = item.idProject;
                dashboard.idUser = item.idUser;
                dashboard.joinedDate = item.joinedDate;
                dashboard.leaveDate = item.leaveDate;
                dashboard.status = item.status;
                //Lưu dashboard vào List
                listDashboard.Add(dashboard);
            }
            Session["listProject"] = listDashboard;

            return View(listDashboard);
        }
        #endregion

        #region ViewDetail: Chi tiết vai trò của User trong Project
        [HttpGet]
        public ActionResult ViewDetail(int idUser, int idProject)
        {
            //Lấy ra positionUser trong project
            PositionUser result = new PositionUserDao().DetailUserInProject(idUser, idProject);
            UserByProject userByProject = new UserByProject();
            userByProject.idUser = result.idUser;
            userByProject.idProject = result.idProject;
            userByProject.position = result.position;
            userByProject.status = result.status;
            userByProject.joinedDate = result.joinedDate;
            userByProject.projectName = new ProjectDao().GetProjectName(idProject);

            //Lấy ra ViewDetail của user theo idUser
            User user = new UserDao().GetUserById(idUser);
            userByProject.userName = user.userName;
            userByProject.account = user.account;
            userByProject.idGroup = user.idGroup;
            userByProject.email = user.mail;
            //Lấy ra tên group
            userByProject.groupName = new GroupDao().GetGroupName(userByProject.idGroup);

            return View(userByProject);
        }
        #endregion

        #region Thêm một user vào trong project
        //public ActionResult AddUser()
        //{
        //    //Lấy ra danh sách User
        //    List<User> listUser = new UserDao().ListUser();
        //    //Đổ vào ViewBag hiển thị lên View
        //    ViewBag.ListUser = listUser;
        //    //Lấy ra list position user
        //    List<string> listPosition = new TypeDao().ListPosition();
        //    ViewBag.ListPosition = listPosition;
        //    return View();
        //}
        public ActionResult AddUser(PositionUser entity)
        {
            //Lấy ra danh sách User
            List<User> listUser = new UserDao().ListUser();
            //Đổ vào ViewBag hiển thị lên View
            ViewBag.ListUser = listUser;
            //Lấy ra list position user
            List<string> listPosition = new TypeDao().ListPosition();
            ViewBag.ListPosition = listPosition;
            //Tạo ViewBag lưu danh sách project
            ViewBag.GetListProject = new ProjectDao().GetListProject();
            //Kiểm tra validation

            if (entity.idUser != null || entity.position != null || entity.idProject != null)
            {
                var dao = new PositionUserDao();
                bool result = dao.AddUser(entity);
                if (result)
                {
                    SetAlert("Add users to the project successfully!", "success");
                    return RedirectToAction("DetailProject", "Project", new { idProject = entity.idProject });
                }
                else
                {
                    ModelState.AddModelError("", "Add users to the project failed!");
                }
            }
            
            return RedirectToAction("DetailProject", "Project", new { idProject = entity.idProject, Show = "block" });
        }
        #endregion
    }
}