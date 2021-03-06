﻿using System;
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
            //Đổi trạng thái cho task
            EF.Task task = new TaskDao().ViewDetail(entity.idTask);
            task.status = "Inprogress"; 
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

        //Lấy ra danh sách các logwork của 1 task
        public List<Result> ListResultLogwork(int idTask)
        {
            List<Result> listResult = db.Results.Where(x => x.idTask == idTask).ToList();
            return listResult;
        }

        //Lấy ra 1 result
        public ResultTask GetResult(int idTask, DateTime date)
        {
            var result =  db.Results.SingleOrDefault(x => x.idTask == idTask & x.date == date);
            var resultTask = new ResultTask();
            resultTask.idTask = result.idTask;
            resultTask.date = result.date;
            resultTask.description = result.description;
            resultTask.type = result.type;
            resultTask.taskName = new TaskDao().GetTaskName(idTask);
            resultTask.resultToday = result.resultToday;
            resultTask.summary = new TaskDao().GetSummary(idTask);
            return resultTask;
        }

        //Delete 1 logwork
        public bool DeleteLogwork(int idTask, DateTime date)
        {
            try
            {
                var result = db.Results.SingleOrDefault(x => x.idTask == idTask & x.date == date);
                db.Results.Remove(result);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Tổng các task được thực hiện trong ngày
        public int TotalInProgress(int idProject, DateTime date)
        {
            var model = from a in db.Projects
                        join b in db.Phases
                        on a.idProject equals b.idProject
                        where a.idProject == idProject
                        join c in db.Sprints
                        on b.idPhase equals c.idPhase
                        join d in db.Tasks
                        on c.idSprint equals d.idSprint
                        join e in db.Results
                        on d.idTask equals e.idTask
                        where e.date == date
                        select e.idTask;
            return model.Count();
        }

    }
}
