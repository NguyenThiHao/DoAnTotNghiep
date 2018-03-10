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
            var listUser = db.Users.ToList();
            ViewBag.listUser = listUser;
            return View();
        }

        #region Tạo mới 1 Project
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateProject(Project project)
        {
            // Kiểm tra tất cả Validation
            if(ModelState.IsValid){
                //Set giá trị cho trường Status
                project.status = 1;
                //Chèn dữ liệu vào bảng Project
                db.Projects.Add(project);
                //Lưu vào CSDL       
                db.SaveChanges();
            }
            CreateProject();
            return View();
        }
        #endregion

        #region Danh sách user tham gia project
        /*
         DetailProject: Hiển thị những Task đang thực hiện trong project
         */
        public PartialViewResult ListUserPartial()
        {
            // Lấy ra danh sách User trong dự án (Đang sai, chưa truy vấn đúng)
            var listUser = db.Users.ToList();
            return PartialView(listUser);
        }
        #endregion

        public ActionResult DetailProject()
        {
            return View();
        }
    }
}