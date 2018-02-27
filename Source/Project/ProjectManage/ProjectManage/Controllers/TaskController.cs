using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class TaskController : Controller
    {
        //Khởi tạo DB
        ProjectManageEntities db = new ProjectManageEntities();

        #region Tạo mới 1 Task
        // GET: /Creat Task/
        public ActionResult CreateTask()
        {
            return View();
        }

        #endregion

        #region Xem chi tiết 1 Task theo id
        //Xem chi tiết 1 task
        public ActionResult DetailTask(int id_task = 0)
        {
            //Tìm kiếm 1 task theo id
            Task task = db.Tasks.SingleOrDefault(n => n.id_task == id_task);
            if (task == null)
            {
                //Trả về trang báo lỗi
                Response.StatusCode = 404;
                return null;
            }
            return View(task);
        }

        #endregion 

        
        /*
         Hiển thị chi tiết 1 công việc
         */
        public PartialViewResult DetailTaskPartial()
        {
            return PartialView();
        }

        public ActionResult DetailProject()
        {
            return View();
        }
        public PartialViewResult MoreDetailTaskPartial()
        {
            return PartialView();
        }
    }
}