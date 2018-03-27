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
            //Lưu danh sách User theo project
            //
            //
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
    }
}