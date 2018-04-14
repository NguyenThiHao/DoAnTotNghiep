using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;
using Model.Dao;

namespace Model.Dao
{
    public class TaskDao
    {
        ProjectManageDbContext db = null;
        public TaskDao()
        {
            db = new ProjectManageDbContext();
        }

        //Thêm mới 1 Task
        public int CreateTask(EF.Task entity)
        {
            //Thêm 1 sprint vào bảng
            db.Tasks.Add(entity);
            //Thay đổi status của Task
            entity.status = "Created";
            //Khởi tạo createDate
            entity.createdDate = DateTime.Now;
            //Lưu vào DB
            db.SaveChanges();
            return entity.idTask;
        }

        //Lấy ra List<Task> theo idSprint
        public List<EF.Task> ListTaskBySprint(int idSprint)
        {
            List<EF.Task> listTask = db.Tasks.Where(x => x.idSprint == idSprint).ToList();
            return listTask;
        }

        //Xem chi tiết của Task
        public EF.Task ViewDetail(int idTask)
        {
            return db.Tasks.Find(idTask);
        }

        //Chỉnh sửa Project
        public bool EditTask(EF.Task entity)
        {
            try
            {
                //Lấy ra project có id giống với id của project cần sửa
                var task = db.Tasks.Find(entity.idTask);
                //Thay đổi các trường trong project
                task.taskName = entity.taskName;
                task.description = entity.description;
                task.due = entity.due;
                task.status = entity.status;
                task.assignee = entity.assignee;
                task.priority = entity.priority;
                task.summary = entity.summary;
                task.estimateTime = entity.estimateTime;
                //Lưu vào csdl
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Lấy ra danh sách Task được asignee cho 1 người
        public List<TasksAssignedToUser> ListTaskAsigneeToUser(int idUser, int idProject)
        {
            try
            {
                List<TasksAssignedToUser> listTasksAssigned = new List<TasksAssignedToUser>();
                List<EF.Task> listTask = db.Tasks.Where(x => x.assignee == idUser).ToList();
                foreach (var item in listTask)
                {
                    if (CheckProject(item.idTask, idProject))
                    {
                        TasksAssignedToUser task = new TasksAssignedToUser();
                        task.idTask = item.idTask;
                        task.idAssignee = item.assignee;
                        task.idSprint = item.idSprint;
                        task.sprintName = new SprintDao().GetPhaseName(task.idSprint);
                        task.idProject = idProject;
                        task.priority = item.priority;
                        task.status = item.status;
                        task.summary = item.summary;
                        task.description = item.description;
                        task.due = item.due;
                        task.type = item.type;
                        task.estimateTime = item.estimateTime;
                        task.createdDate = item.createdDate;
                        task.projectName = new ProjectDao().GetProjectName(idProject);
                        task.taskName = item.taskName;
                        task.loggedTime = new TaskDao().GetLogedTime(task.idTask);
                        listTasksAssigned.Add(task);
                    }
                }
                return listTasksAssigned;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Lấy ra chi tiết của 1 task
        public TasksAssignedToUser TaskAsigneeToUser(int idTask, int idProject)
        {

            EF.Task item = db.Tasks.Find(idTask);
            TasksAssignedToUser task = new TasksAssignedToUser();
            task.idTask = item.idTask;
            task.idAssignee = item.assignee;
            task.accountAssignee = new UserDao().GetAccountUser(task.idAssignee);
            task.nameAssignee = new UserDao().GetNameUser(task.idAssignee);
            task.idSprint = item.idSprint;
            task.sprintName = new SprintDao().GetPhaseName(task.idSprint);
            task.idReporter = new SprintDao().GetReporter(task.idSprint);
            task.accountReporter = new UserDao().GetAccountUser(task.idReporter);
            task.nameReporter = new UserDao().GetNameUser(task.idReporter);
            task.idProject = idProject;
            task.priority = item.priority;
            task.status = item.status;
            task.summary = item.summary;
            task.description = item.description;
            task.due = item.due;
            task.type = item.type;
            task.estimateTime = item.estimateTime;
            task.createdDate = item.createdDate;
            task.projectName = new ProjectDao().GetProjectName(idProject);
            task.taskName = item.taskName;
            task.loggedTime = new TaskDao().GetLogedTime(idTask);
            return task;
        }

        //Kiểm tra 1 task thuộc Sprint nào
        public int CheckSprint(int idTask)
        {
            int idSprint = db.Tasks.SingleOrDefault(x => x.idTask == idTask).idSprint;
            return idSprint;
        }

        //Kiểm tra 1 task có phải thuộc project đó k
        public bool CheckProject(int idTask, int idProject)
        {
            int idSprint = CheckSprint(idTask);
            int idPhase = new SprintDao().CheckPhase(idSprint);
            int idPrj = new PhaseDao().CheckProject(idPhase);
            if (idPrj == idProject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Kiểm tra 1 task thuộc project nào
        public int GetProject(int idTask)
        {
            int idSprint = CheckSprint(idTask);
            int idPhase = new SprintDao().CheckPhase(idSprint);
            int idProject = new PhaseDao().CheckProject(idPhase);
            return idProject;
        }

        //Lấy ra người thực hiện 1 task
        public int GetAssignee(int idTask)
        {
            int idUser = db.Tasks.SingleOrDefault(x => x.idTask == idTask).assignee;
            return idUser;
        }

        //Lấy ra summary của 1 task
        public string GetSummary(int idTask)
        {
            return db.Tasks.SingleOrDefault(x => x.idTask == idTask).summary;
        }

        //Lấy ra taskName của 1 task
        public string GetTaskName(int idTask)
        {
            return db.Tasks.SingleOrDefault(x => x.idTask == idTask).taskName;
        }


        //% thời gian đã làm trong 1 task
        public double GetLogedTime(int idTask)
        {
            double estimateTime = db.Tasks.Find(idTask).estimateTime;
            double loggedTime = 0;
            List<Result> listResultTask = db.Results.Where(x => x.idTask == idTask).ToList();
            foreach (var item in listResultTask)
            {
                loggedTime = loggedTime + item.resultToday;
            }
            double logged = loggedTime / estimateTime * 100;
            return logged;
        }


    }
}
