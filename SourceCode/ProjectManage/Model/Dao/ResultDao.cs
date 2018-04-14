using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;

namespace Model.Dao
{
    public class ResultDao
    {
        ProjectManageDbContext db = null;
        public ResultDao()
        {
            db = new ProjectManageDbContext();
        }
        //Tạo mới 1 result
        public int CreateResult(ResultTask resultTask)
        {
            Result entity = new Result();
            entity.date = resultTask.date;
            entity.idTask = resultTask.idTask;
            entity.resultToday = resultTask.resultToday;
            entity.description = resultTask.description;
            entity.type = resultTask.type;
            //Thêm 1 result vào bảng
            db.Results.Add(entity);
            //Lưu vào DB
            db.SaveChanges();
            return entity.idTask;
        }

        //Chỉnh sửa 1 result
        public bool EditResult(ResultTask resultTask)
        {
            try
            {
                Result entity = db.Results.SingleOrDefault(x => x.date == resultTask.date && x.idTask == resultTask.idTask);
                entity.date = resultTask.date;
                entity.idTask = resultTask.idTask;
                entity.resultToday = resultTask.resultToday;
                entity.description = resultTask.description;
                entity.type = resultTask.type;
                //Thêm 1 result vào bảng
                db.Results.Add(entity);
                //Lưu vào DB
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
