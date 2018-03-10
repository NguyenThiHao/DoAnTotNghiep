using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class DevelopGroupController : Controller
    {
        ProjectManageEntities db = new ProjectManageEntities();
        //
        // GET: /DevelopGroup/
        public ActionResult CreateGroup()
        {
            return View();
        }

        #region Thêm mới 1 Group vào CSDL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(DevelopGroup group)
        {
            //Kiểm tra Tất cả validation hợp lệ
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu vào bảng DevelopGroup
                db.DevelopGroups.Add(group);
                //Lưu vào CSDL
                db.SaveChanges();
            }
            return View();
        }
        #endregion

        public ActionResult DetailGroup()
        {
            return View();
        }
    }
}