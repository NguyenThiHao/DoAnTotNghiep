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
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

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
                    return RedirectToAction("DetailTask", "Task");
                }
                else
                {
                    ModelState.AddModelError("", "Create task failed!");
                }
            }
            return View("CreateTask");
        }
        #endregion
        public ActionResult DetailTaskPartial()
        {
            return View();
        }

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
                    return RedirectToAction("DetailTask", "Task");
                }
                else
                {
                    ModelState.AddModelError("", "Edit Task failed!");
                }
            }
            return View("EditTask");
        }
        #endregion

    }
}