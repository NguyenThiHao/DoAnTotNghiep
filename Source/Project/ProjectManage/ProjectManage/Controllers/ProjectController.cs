using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class ProjectController : Controller
    {
        //Khởi tạo DB
        ProjectManageEntities db = new ProjectManageEntities();

        //
        // GET: /Project/
        public ActionResult CreateProject()
        {
            
            return View();
        }

        #region Tạo mới 1 Project
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {

            //Chèn dữ liệu vào bảng Project
            db.Projects.Add(project);
            //Lưu vào CSDL
            db.SaveChanges();
            return View();
        }
        #endregion 

        #region Danh sách Task trong 1 project
        /*
         DetailProject: Hiển thị những Task đang thực hiện trong project
         */
        public PartialViewResult ListTaskPartial()
        {
            // Khai báo biến List các công việc trong Project
            var lsTaskOfProject = db.Tasks.ToList();
            return PartialView(lsTaskOfProject);
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