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
        public ActionResult CreateGroup(DevelopGroup group)
        {
            //Chèn dữ liệu vào bảng DevelopGroup
            db.DevelopGroups.Add(group);
            //Lưu vào CSDL
            db.SaveChanges();
            return View();
        }
        #endregion
    }
}