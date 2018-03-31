using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

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
                task.idSprint = entity.idSprint;
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

    }
}
