using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class SprintController : Controller
    {
        ProjectManageEntities db = new ProjectManageEntities();
        //
        // GET: /Sprint/
        [HttpGet]
        public ActionResult CreateSprint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSprint(Sprint sprint)
        {
            //Kiểm tra tất cả các Validation
            if (ModelState.IsValid)
            {
                //Thêm dữ liệu vào bảng Sprint
                db.Sprints.Add(sprint);
                //Lưu vào DB
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult DetailSprint()
        {
            return View();
        }
	}
}