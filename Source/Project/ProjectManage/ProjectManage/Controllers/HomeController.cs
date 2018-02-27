using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    public class HomeController : Controller
    {
        ProjectManageEntities db = new ProjectManageEntities();
        public ActionResult Home()
        {
            return View();
        }

        //Lay du lieu tu model len CategoryPatial
        public PartialViewResult _CategoriesPartial()
        {
            return PartialView(lsCategories);
        }

        public string lsCategories { get; set; }
    }
}