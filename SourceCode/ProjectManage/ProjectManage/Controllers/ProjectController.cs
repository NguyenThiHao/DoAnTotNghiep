using System.Collections.Generic;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Model.ViewModel;
using ProjectManage.Common;
using ProjectManage.Models;
using System.Web.Script.Serialization;

namespace ProjectManage.Controllers
{
    public class ProjectController : BaseController
    {
        List<string> listProjectType = new TypeDao().ListProjectType();
        List<string> listStatus = new TypeDao().ListStatus();

        #region CreateProject
        [HasCredential(RoleID = "CREATE_PROJECT")]
        [HttpGet]
        public ActionResult CreateProject()
        {
            ViewBag.ListProjectType = listProjectType;
            return View();
        }

        //Thêm mới 1 project
        [HttpPost]
        [HasCredential(RoleID = "CREATE_PROJECT")]
        public ActionResult CreateProject(Project project)
        {
            ViewBag.ListProjectType = listProjectType;
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {

                var dao = new ProjectDao();
                int idProject = dao.CreateProject(project);
                if (idProject > 0)
                {

                    PositionUser pUser = new PositionUser((int)Session["idUser"], idProject);

                    if (new PositionUserDao().AddUser(pUser))
                    {
                        SetAlert("Create project suscessful!", "success");
                        return RedirectToAction("DetailProject", "Project", new { idProject = project.idProject });
                    }

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
        [HasCredential(RoleID = "EDIT_PROJECT")]
        public ActionResult EditProject(int idProject)
        {
            ViewBag.ListProjectType = listProjectType;
            ViewBag.listStatus = listStatus;
            var project = new ProjectDao().ViewDetail(idProject);
            return View(project);
        }

        //Chỉnh sửa project
        [HttpPost]
        [HasCredential(RoleID = "EDIT_PROJECT")]
        public ActionResult EditProject(Project project)
        {
            ViewBag.ListProjectType = listProjectType;
            ViewBag.listStatus = listStatus;
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
        [HasCredential(RoleID = "VIEW_PROJECT")]
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

            //Vẽ biểu đồ
            List<ChartParse> listChart = new ProjectDao().ListChart(idProject);
            ViewBag.Chart = (new JavaScriptSerializer().Serialize(listChart));

            return View(detailProject);
        }

        //Danh sách các user ở trong 1 project
        [HasCredential(RoleID = "VIEW_PROJECT")]
        public ActionResult ListUserPartial(int idProject)
        {
            //Lấy ra danh sách User
            List<User> listUser = new UserDao().ListUser();
            //Đổ vào ViewBag hiển thị lên View
            ViewBag.ListUser = listUser;
            var dao = new PositionUserDao();
            List<UserByProject> listUserByProject = dao.ListUserByProject(idProject);
            ViewBag.idProject = idProject;
            List<Project> listProject = new ProjectDao().GetListProject();
            ViewBag.listProject = listProject; 
            return View(listUserByProject);
        }

        //Lấy ra danh sách các phase trong project
        [HasCredential(RoleID = "VIEW_PROJECT")]
        public ActionResult ListPhaseInProject(int idProject)
        {
            ViewBag.idProject = idProject;
            var listPhase = new PhaseDao().ListPhaseByProject(idProject);
            ViewBag.idProject = idProject;
            return PartialView(listPhase);
        }
        #endregion

        #region Remove user from project
        [HasCredential(RoleID = "DELETE_POSITION")]
        [HttpDelete]
        public ActionResult RemoveUser(int idUser, int idProject)
        {
            new PositionUserDao().RemoveUser(idUser, idProject);
            return RedirectToAction("ListUserPartial");
        }
        #endregion
    }
}
