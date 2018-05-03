using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using ProjectManage.Common;

namespace ProjectManage.Controllers
{
    public class PhaseController : BaseController
    {
        // GET: Phase
        public ActionResult Index()
        {
            return View();
        }

        #region CreatePhase: Tạo mới 1 Phase
        [HttpGet]
        [HasCredential(RoleID = "CREATE_PHASE")]
        public ActionResult CreatePhase()
        {
            //Tạo ViewBag lưu danh sách project
            ViewBag.GetListProject = new ProjectDao().GetListProject();
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "CREATE_PHASE")]
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
                    return RedirectToAction("DetailPhase", "Phase", new { idPhase = phase.idPhase });
                }
                else
                {
                    ModelState.AddModelError("", "Create phase failed!");
                }
            }
            return View("CreatePhase");
        }
        #endregion

        #region EditPhase: Chỉnh sửa thông tin Phase
        [HttpGet]
        [HasCredential(RoleID = "EDIT_PHASE")]
        public ActionResult EditPhase(int idPhase)
        {
            var phase = new PhaseDao().ViewDetail(idPhase);
            return View(phase);
        }

        //Chỉnh sửa project
        [HttpPost]
        [HasCredential(RoleID = "EDIT_PHASE")]
        public ActionResult EditPhase(Phase phase)
        {
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new PhaseDao();
                var result = dao.EditPhase(phase);
                if (result)
                {
                    SetAlert("Edit phase suscessful!", "success");
                    return RedirectToAction("DetailPhase", "Phase", new { idPhase = phase.idPhase });
                }
                else
                {
                    ModelState.AddModelError("", "Edit phase failed!");
                }
            }
            return View("EditPhase");
        }
        #endregion

        #region DetailPhase: Xem chi tiết một Phase
        [HasCredential(RoleID = "VIEW_PHASE")]
        public ActionResult DetailPhase(int idPhase)
        {
            var dao = new PhaseDao();
            var detailPhase = dao.ViewDetail(idPhase);
            string nameProject = new ProjectDao().GetProjectName(detailPhase.idProject);
            ViewBag.nameProject = nameProject;
            return View(detailPhase);
        }

        public ActionResult ListSprintInPhase(int idPhase)
        {
            var dao = new SprintDao();
            var listSprint = dao.ListSprintByPhase(idPhase);
            return PartialView(listSprint);
        }
        #endregion
    }
}