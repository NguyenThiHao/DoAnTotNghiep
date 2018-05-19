using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using Model.ViewModel;

namespace ProjectManage.Controllers
{
    public class ResultController : BaseController
    {
        List<string> listTaskType = new TypeDao().ListTaskType();
        #region Logwork
        // GET: Logworks
        public ActionResult Logworks(int idTask)
        {
            ViewBag.listTaskType = listTaskType;
            ResultTask resultTask = new ResultTask();
            resultTask.idTask = idTask;
            resultTask.taskName = new TaskDao().GetTaskName(idTask);
            resultTask.idUser = new TaskDao().GetAssignee(idTask);
            resultTask.userName = new UserDao().GetNameUser(resultTask.idUser);
            resultTask.summary = new TaskDao().GetSummary(idTask);
            return View(resultTask);
        }

        [HttpPost]
        public ActionResult Logworks(ResultTask resultTask)
        {
            ViewBag.listTaskType = listTaskType;
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new ResultDao();
                long idTask = dao.CreateResult(resultTask);
                if (idTask > 0)
                {
                    SetAlert("Logworks suscessful!", "success");
                    return RedirectToAction("DetailTask", "Task", new { idTask = resultTask.idTask });
                }
                else
                {
                    ModelState.AddModelError("", "Logworks failed!");
                }
            }
            return RedirectToAction("DetailTask", "Task", new { idTask = resultTask.idTask, Show = "block" });
        }

        #endregion

        #region Edit logworks
        [HttpPost]
        public ActionResult EditLogwork(ResultTask resultTask)
        {
            ViewBag.listTaskType = listTaskType;
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new ResultDao();
                var result = dao.EditResult(resultTask);
                if (result)
                {
                    SetAlert("Edit Task suscessful!", "success");
                    return RedirectToAction("DetailTask", "Task", new { idTask = resultTask.idTask });
                }
                else
                {
                    ModelState.AddModelError("", "Edit logwork failed!");
                }
            }
            return View("EditLogwork");
        }
        [HttpGet]
        public ActionResult EditLogwork(int idTask, DateTime date)
        {
            ViewBag.listTaskType = listTaskType;
            var dao = new ResultDao();
            var result = dao.GetResult(idTask, date);
            return View(result);
        }
        #endregion
    }
}