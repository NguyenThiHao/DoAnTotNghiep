using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Model.ViewModel;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class PositionUserController : BaseController
    {

        #region View Dashboard: Danh sách các Project mà 1 User đang tham gia
        public ActionResult Dashboard(int idUser)
        {
            //Lấy ra danh sách project mà user đang tham gia
            var listProjectJoined = new PositionUserDao().ListProjectJoined(idUser);
            //Khởi tạo class 1 Dashboard để lấy ra chi tiết hơn
            Dashboard dashboard = new Dashboard();
            //Khởi tạo 1 list<Dashboard> lưu trữ
            List<Dashboard> listDashboard = new List<Models.Dashboard>();
            foreach(var item in listProjectJoined)
            {
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

        #region ListTask: Danh sách các công việc Assigee cho 1 User trong project
        public ActionResult ListTask(int idUser, int idProject)
        {
            List<Phase> listPhase = new PhaseDao().ListPhaseByProject(idProject);

            //lấy ra danh sách task
            return View();
        }
        #endregion
    }
}