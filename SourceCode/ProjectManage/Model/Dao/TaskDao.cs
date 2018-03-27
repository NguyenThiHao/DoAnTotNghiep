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

        //Thêm mới 1 sprint
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


       
    }
}
