using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class PhaseController : Controller
    {
        ProjectManageEntities db = new ProjectManageEntities();
        //
        // GET: /Phase/
        public ActionResult CreatePhase()
        {
            var listProject = db.Projects.ToList();
            ViewBag.listProject = listProject;
            return View();
        }

        #region Tạo mới 1 phase
        [HttpPost]
        public ActionResult CreatePhase(Phase phase)
        {
            //Kiểm tra tất cả validation
            if (ModelState.IsValid)
            {
                phase.status = 1;
                //Chèn dữ liệu vào bảng Phase
                db.Phases.Add(phase);
                //Lưu vào CSDL
                db.SaveChanges();
            }
            return View();
        }
        #endregion

        public ActionResult DetailPhase()
        {
            return View();
        }
    }
}