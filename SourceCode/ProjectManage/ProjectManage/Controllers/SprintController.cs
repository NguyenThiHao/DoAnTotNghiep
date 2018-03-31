using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using ProjectManage.Common;
using ProjectManage.Controllers;

namespace ProjectManage.Controllers
{
    public class SprintController : BaseController
    {
        // GET: Sprint
        public ActionResult Index()
        {
            return View();
        }

        #region CreateSprint: Tạo mới 1 Sprint
        [HttpGet]
        public ActionResult CreateSprint()
        {
            ViewBag.GetListPhase = new PhaseDao().GetListPhase();
            return View();
        }

        public ActionResult CreateSprint(Sprint sprint)
        {
            //Tạo ViewBag lưu danh sách Phase
            ViewBag.GetListPhase = new PhaseDao().GetListPhase();
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new SprintDao();
                //Lấy lại idUser đang đăng nhập
                UserLogin userSession = (UserLogin)Session[CommonConstants.USER_SESSION];
                //Gán user trong session hiện tại cho người tạo sprint
                sprint.reporter = userSession.idUser;
                long idSprint = dao.CreateSprint(sprint);
                if (idSprint > 0)
                {
                    SetAlert("Create sprint suscessful!", "success");
                    return RedirectToAction("DetailSprint", "Sprint");
                }
                else
                {
                    ModelState.AddModelError("", "Create sprint failed!");
                }
            }
            return View("CreateSprint");
        }
        #endregion

        #region EditSprint: Chỉnh sửa thông tin Sprint
        [HttpGet]
        public ActionResult EditSprint(int idSprint)
        {
            var sprint = new SprintDao().ViewDetail(idSprint);
            return View(sprint);
        }

        //Chỉnh sửa project
        [HttpPost]
        public ActionResult EditSprint(Sprint sprint)
        {
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new SprintDao();
                var result = dao.EditSprint(sprint);
                if (result)
                {
                    SetAlert("Edit sprint suscessful!", "success");
                    return RedirectToAction("DetailSprint", "Sprint");
                }
                else
                {
                    ModelState.AddModelError("", "Edit sprint failed!");
                }
            }
            return View("EditSprint");
            #endregion

        }
    }
}