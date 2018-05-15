using ProjectManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManage.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Menu()
        {
            ViewBag.username = Session["userName"];
            List<Dashboard> listProject = (List<Dashboard>)Session["listProject"];
            return View(listProject);
        }
    }
}