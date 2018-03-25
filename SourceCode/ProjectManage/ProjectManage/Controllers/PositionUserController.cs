using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class PositionUserController : Controller
    {

        #region View Dashboard
        //Lấy ra danh sách project mà user đang tham gia
        public ActionResult Dashboard(int idUser)
        { 
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
    }
}