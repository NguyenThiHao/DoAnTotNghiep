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
            return View();
        }

        #region Tạo mới 1 phase
        [HttpPost]
        public ActionResult CreatePhase(Phase phase)
        {
            //Chèn dữ liệu vào bảng Phase
            db.Phases.Add(phase);
            //Lưu vào CSDL
            db.SaveChanges();
            return View();
        }
        #endregion
    }
}