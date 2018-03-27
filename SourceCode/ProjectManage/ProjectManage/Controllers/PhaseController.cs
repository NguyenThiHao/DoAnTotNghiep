using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
namespace ProjectManage.Controllers
{
    public class PhaseController : BaseController
    {
        // GET: Phase
        public ActionResult Index()
        {
            return View();
        }

        #region CreatePhase
        [HttpGet]
        public ActionResult CreatePhase()
        {
            //Tạo ViewBag lưu danh sách project
            ViewBag.GetListProject = new ProjectDao().GetListProject();
            return View();
        }
        [HttpPost]
        public ActionResult CreatePhase(Phase phase)
        {
            //Tạo ViewBag lưu danh sách project
            ViewBag.GetListProject = new ProjectDao().GetListProject();
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new PhaseDao();
                long idPhase = dao.CreatePhase(phase);
                if (idPhase > 0)
                {
                    SetAlert("Create phase suscessful!", "success");
                    return RedirectToAction("DetailPhase", "Phase");
                }
                else
                {
                    ModelState.AddModelError("", "Create phase failed!");
                }
            }
            return View("CreatePhase");
        }
        #endregion
    }
}