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
        #region Logwork
        // GET: Logworks
        public ActionResult Logworks(int idTask)
        {
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
            return View("Logworks");
        }

        #endregion

        #region Edit logworks
        [HttpPost]
        public ActionResult EditLogwork(ResultTask resultTask)
        {
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
            var dao = new ResultDao();
            var result = dao.GetResult(idTask, date);
            return View(result);
        }
        #endregion
    }
}