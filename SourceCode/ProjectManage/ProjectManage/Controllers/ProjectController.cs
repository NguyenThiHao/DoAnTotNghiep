using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using ProjectManage.Common;


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
                    return RedirectToAction("DetailProject", "Project");
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
                    return RedirectToAction("DetailProject", "Project");
                }
                else
                {
                    ModelState.AddModelError("", "Edit project failed!");
                }
            }
            return View("EditProject");
        }
        #endregion

        public ActionResult DetailProject(int idProject)
        {
            var project = new ProjectDao().ViewDetail(idProject);
            return View(project);
        }

        public ActionResult ListUserPartial()
        {
            return View();
        }
    }
}