using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace ProjectManage.Controllers
{
    public class TaskController : BaseController
    {
        #region CreateTask
        [HttpGet]
        public ActionResult CreateTask()
        {
            ViewBag.GetListSprint = new SprintDao().GetListSprint();
            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(Task task )
        {
            //Tạo ViewBag lưu danh sách project
            ViewBag.GetListSprint = new SprintDao().GetListSprint();
            //Lưu danh sách User theo project vào ViewBag
            //List<UserByProject> listUserByProject = new PositionUserDao.ListUserByProject(idProject)
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new TaskDao();
                long idTask = dao.CreateTask(task);
                if (idTask > 0)
                {
                    SetAlert("Create task suscessful!", "success");
                    return RedirectToAction("DetailTask", "Task", new {idTask = task.idTask });
                }
                else
                {
                    ModelState.AddModelError("", "Create task failed!");
                }
            }
            return View("CreateTask");
        }
        #endregion
        
        #region EditTask: Chỉnh sửa thông tin Task
        [HttpGet]
        public ActionResult EditTask(int idTask)
        {
            var task = new TaskDao().ViewDetail(idTask);
            return View(task);
        }

        //Chỉnh sửa project
        [HttpPost]
        public ActionResult EditTask(Task task)
        {
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new TaskDao();
                var result = dao.EditTask(task);
                if (result)
                {
                    SetAlert("Edit Task suscessful!", "success");
                    return RedirectToAction("DetailTask", "Task", new { idTask = task.idTask });
                }
                else
                {
                    ModelState.AddModelError("", "Edit Task failed!");
                }
            }
            return View("EditTask");
        }
        #endregion

        #region Detail Task
        public ActionResult DetailTask(int idTask)
        {
            int idProject = new TaskDao().GetProject(idTask);
            var result = new TaskDao().TaskAsigneeToUser(idTask, idProject);
            return View(result);
        }

        public ActionResult LogworkPartial(int idTask)
        {
            List<Result> listResultTask = new ResultDao().ListResultLogwork(idTask);
            return View(listResultTask);
        }
        #endregion

        #region ListTask (Dashboard):  Lấy ra list task được chỉ định cho 1 người trong 1 project 
        public ActionResult ListTask(int idUser, int idProject)
        {
            var result = new TaskDao().ListTaskAsigneeToUser(idUser, idProject);
            ViewBag.ProjectName = new ProjectDao().GetProjectName(idProject);
            return View(result);
        }
        #endregion
    }
}