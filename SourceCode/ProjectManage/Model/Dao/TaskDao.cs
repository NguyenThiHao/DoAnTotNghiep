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
                foreach(var item in listTask)
                {
                    if(CheckProject(item.idTask, idProject))
                    {
                        TasksAssignedToUser task = new TasksAssignedToUser();
                        task.idTask = item.idTask;
                        task.idUser = item.assignee;
                        task.idProject = idProject;
                        task.priority = item.priority;
                        task.status = item.status;
                        task.summary = item.summary;
                        task.description = item.description;
                        task.due = item.due;
                        task.createdDate = item.createdDate;
                        task.projectName = new ProjectDao().GetProjectName(idProject);
                        task.taskName = item.taskName;
                        listTasksAssigned.Add(task);
                    }
                }
                return listTasksAssigned;
            }
            catch(Exception ex)
            {
                return null;
            }
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
            if(idPrj == idProject)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public string GetTaskName (int idTask)
        {
            return db.Tasks.SingleOrDefault(x => x.idTask == idTask).taskName;
        }
    }
}
