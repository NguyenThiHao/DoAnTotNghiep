﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using Model.ViewModel;
using ProjectManage.Common;

namespace ProjectManage.Controllers
{
    public class TaskController : BaseController
    {
        List<string> listTypeTask = new TypeDao().ListTaskType();
        List<string> listStatus = new TypeDao().ListStatus();
        #region CreateTask
        [HttpGet]
        [HasCredential(RoleID = "CREARE_TASK")]
        public ActionResult CreateTask()
        {
            ViewBag.listTypeTask = listTypeTask;
            //Lấy ra danh sách User
            List<User> listUser = new UserDao().ListUser();
            //Đổ vào ViewBag hiển thị lên View
            ViewBag.ListUser = listUser;
            if (Request.QueryString["idSprint"] != null)
            {
                List<Sprint> listSprint = new SprintDao().GetSprint(Int32.Parse(Request.QueryString["idSprint"]));
                ViewBag.GetListSprint = listSprint;
            }
            else
            {
                //Tạo ViewBag lưu danh sách project
                ViewBag.GetListSprint = new SprintDao().GetListSprint();
            }
            return View();
        }

        [HttpPost]
        [HasCredential(RoleID = "CREARE_TASK")]
        public ActionResult CreateTask(Task task )
        {
            ViewBag.listTypeTask = listTypeTask;
            if (Request.QueryString["idSprint"] != null)
            {
                List<Sprint> listSprint = new SprintDao().GetSprint(Int32.Parse(Request.QueryString["idSprint"]));
                ViewBag.GetListSprint = listSprint;
            }
            else
            {
                //Tạo ViewBag lưu danh sách project
                ViewBag.GetListSprint = new SprintDao().GetListSprint();
            }
            //Lấy ra danh sách User
            List<User> listUser = new UserDao().ListUser();
            //Đổ vào ViewBag hiển thị lên View
            ViewBag.ListUser = listUser;
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new TaskDao();
                int idTask = dao.CreateTask(task);
                int idProject = dao.GetProject(idTask);
                task.idProject = idProject;
                if (idTask > 0)
                {
                    SetAlert("Create task suscessful!", "success");
                    return RedirectToAction("DetailTask", "Task", new {idTask = task.idTask });
                }
                else
                {
                    ModelState.AddModelError("", "Create task failed!");
                }
            }
            return View("CreateTask");
        }
        #endregion
        
        #region EditTask: Chỉnh sửa thông tin Task
        [HttpGet]
        [HasCredential(RoleID = "EDIT_TASK")]
        public ActionResult EditTask(int idTask)
        {
            ViewBag.listStatus = listStatus;
            //Lấy ra danh sách User
            List<User> listUser = new UserDao().ListUser();
            //Đổ vào ViewBag hiển thị lên View
            ViewBag.ListUser = listUser;
            ViewBag.listTypeTask = listTypeTask;
            var task = new TaskDao().ViewDetail(idTask);
            int idSprint = task.idSprint;
            //lấy ra tên Sprint
            string sprintName = new SprintDao().GetSprintName(idSprint);
            ViewBag.SprintName = sprintName;
            return View(task);
        }

        //Chỉnh sửa project
        [HttpPost]
        [HasCredential(RoleID = "EDIT_TASK")]
        public ActionResult EditTask(Task task)
        {
            ViewBag.listStatus = listStatus;
            //Lấy ra danh sách User
            List<User> listUser = new UserDao().ListUser();
            //Đổ vào ViewBag hiển thị lên View
            ViewBag.ListUser = listUser;
            ViewBag.listTypeTask = listTypeTask;
            int idSprint = task.idSprint;
            //lấy ra tên Sprint
            string sprintName = new SprintDao().GetSprintName(idSprint);
            ViewBag.SprintName = sprintName;
            //Kiểm tra Validation
            if (ModelState.IsValid)
            {
                var dao = new TaskDao();
                var result = dao.EditTask(task);
                if (result)
                {
                    SetAlert("Edit Task suscessful!", "success");
                    return RedirectToAction("DetailTask", "Task", new { idTask = task.idTask });
                }
                else
                {
                    ModelState.AddModelError("", "Edit Task failed!");
                }
            }
            return View("EditTask");
        }
        #endregion

        #region Detail Task
        [HasCredential(RoleID = "VIEW_TASK")]
        public ActionResult DetailTask(int idTask)
        {
            ViewBag.listTypeTask = listTypeTask;
            int idProject = new TaskDao().GetProject(idTask);
            var result = new TaskDao().TaskAsigneeToUser(idTask, idProject);
            return View(result);
        }

        public ActionResult LogworkPartial(int idTask)
        {
            List<Result> listResultTask = new ResultDao().ListResultLogwork(idTask);
            return View(listResultTask);
        }
        #endregion

        #region ListTask (Dashboard):  Lấy ra list task được chỉ định cho 1 người trong 1 project 
        [HasCredential(RoleID = "VIEW_RESULT")]
        public ActionResult ListTask(int idUser, int idProject)
        {
            var result = new TaskDao().ListTaskAsigneeToUser(idUser, idProject);
            ViewBag.ProjectName = new ProjectDao().GetProjectName(idProject);
            return View(result);
        }
        #endregion

        #region Delete Logwork
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_RESULT")]
        public ActionResult DeleteLogwork(int idTask, DateTime date)
        {
            new ResultDao().DeleteLogwork(idTask, date);
            return RedirectToAction("LogworkPartial");
        }
        #endregion
    }
}