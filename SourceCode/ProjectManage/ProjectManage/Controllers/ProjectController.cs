using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Model.ViewModel;
using ProjectManage.Common;
using ProjectManage.Models;


namespace ProjectManage.Controllers
{
    public class ProjectController : BaseController
    {
        public ActionResult Index()
        {
            var dao = new PositionUserDao();
            var userLogin = new UserLogin();
            var listPositionUser = dao.ListProjectJoined(userLogin.idUser);
            return View(listPositionUser);
        }

        #region CreateProject
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        //Thêm mới 1 project
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new ProjectDao();
                long idProject = dao.CreateProject(project);
                if (idProject > 0)
                {
                    SetAlert("Create project suscessful!", "success");
                    return RedirectToAction("DetailProject", "Project", new { idProject = project.idProject});
                }
                else
                {
                    ModelState.AddModelError("", "Create project failed!");
                }
            }
            return View("CreateProject");
        }
        #endregion

        #region EditProject
        [HttpGet]
        public ActionResult EditProject(int idProject)
        {
            var project = new ProjectDao().ViewDetail(idProject);
            return View(project);
        }

        //Chỉnh sửa project
        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new ProjectDao();
                var result = dao.EditProject(project);
                if (result)
                {
                    SetAlert("Edit project suscessful!", "success");
                    return RedirectToAction("DetailProject", "Project", new { idProject = project.idProject });
                }
                else
                {
                    ModelState.AddModelError("", "Edit project failed!");
                }
            }
            return View("EditProject");
        }
        #endregion

        #region Detail Project
        public ActionResult DetailProject(int idProject)
        {
            var project = new ProjectDao().ViewDetail(idProject);
            var detailProject = new DetailProject();
            //Gán giá trị cho DetailProject
            detailProject.idProject = project.idProject;
            detailProject.projectName = project.projectName;
            detailProject.startDate = project.startDate;
            detailProject.status = project.status;
            detailProject.endDate = project.endDate;
            detailProject.description = project.description;
            detailProject.typeProject = project.typeProject;
            //Lấy ra id của người là Leader của Project
            detailProject.idLeader = new PositionUserDao().GetLeaderOfProject(idProject);
            //Lấy ra tên của Leader
            detailProject.leaderName = new UserDao().GetNameUser(detailProject.idLeader);
            //Lấy ra tổng số người tham gia project
            detailProject.totalMembers = new PositionUserDao().TotalUserByProject(idProject);
            //Lấy ra tổng số Phase trong 1 project
            detailProject.totalPhase = new PhaseDao().TotalPhaseByProject(idProject);
            return View(detailProject);
        }

        //Danh sách các user ở trong 1 project
        public ActionResult ListUserPartial(int idProject)
        {
            List<PositionUser> listPosition = new PositionUserDao().ListUserByProject(idProject);
            List<Model.ViewModel.UserByProject> listUserByProject = new List<UserByProject>();
            foreach(PositionUser i in listPosition)
            {
                int idUser = i.idUser;
                var userByProject = new UserByProject();
                userByProject.idUser = idUser;
                userByProject.position = i.position;
                userByProject.idProject = i.idProject;
                userByProject.account = new UserDao().GetAccountUser(idUser);
                userByProject.status = i.status;
                userByProject.joinedDate = i.joinedDate;
                listUserByProject.Add(userByProject);
            }
            return View(listUserByProject);
        }

        //Lấy ra danh sách các phase trong project
        public ActionResult ListPhaseInProject(int idProject)
        {
            List<Phase> listPhase = new PhaseDao().ListPhaseByProject(idProject);
            return PartialView(listPhase);
        }
        #endregion

        #region Remove user from project
        [HttpDelete]
        public ActionResult RemoveUser(int idUser, int idProject)
        {
            new PositionUserDao().RemoveUser(idUser, idProject);
            return RedirectToAction("ListUserPartial");
        }
        #endregion
    }
}