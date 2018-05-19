using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class SprintDao
    {
        ProjectManageDbContext db = null;
        public SprintDao()
        {
            db = new ProjectManageDbContext();
        }

        //Thêm mới 1 sprint
        public int CreateSprint(Sprint entity)
        {
            //Thêm 1 sprint vào bảng
            db.Sprints.Add(entity);
            //Thay đổi status của Sprint
            entity.status = "Created";
            //Khởi tạo createDate
            entity.createdDate = DateTime.Now;
            //Lưu vào DB
            db.SaveChanges();
            return entity.idPhase;
        }

        //Lấy ra danh sách các Sprint
        public List<Sprint> GetListSprint()
        {
            return db.Sprints.ToList();
        }

        //Lấy ra List<Sprint> theo idPhase
        public List<Sprint> ListSprintByPhase(int idPhase)
        {
            return db.Sprints.Where(x => x.idPhase == idPhase).ToList();
        }

        //Xem chi tiết của Sprint
        public Sprint ViewDetail(int idSprint)
        {
            return db.Sprints.Find(idSprint);
        }

        //Chỉnh sửa Project
        public bool EditSprint(Sprint entity)
        {
            try
            {
                //Lấy ra project có id giống với id của project cần sửa
                var sprint = db.Sprints.Find(entity.idSprint);
                //Thay đổi các trường trong project
                sprint.sprintName = entity.sprintName;
                sprint.description = entity.description;
                sprint.createdDate = entity.createdDate;
                sprint.endDate = entity.endDate;
                sprint.status = entity.status;
                //Lưu vào csdl
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Kiểm tra 1 sprint thuộc phase nào
        public int CheckPhase(int idSprint)
        {
            int idPhase = db.Sprints.SingleOrDefault(x => x.idSprint == idSprint).idPhase;
            return idPhase;
        }

        //Lấy ra tên của 1 sprint
        public string GetSprintName(int idSprint)
        {
            return db.Sprints.Find(idSprint).sprintName.ToString();
        }

        //Lấy ra id người tạo ra sprint
        public int GetReporter(int idSprint)
        {
            return db.Sprints.Find(idSprint).reporter;
        }

        //Lấy ra sprint theo id
        public List<Sprint> GetSprint(int idSprint)
        {
            List<Sprint> listSprint = new List<Sprint>();
            listSprint.Add(db.Sprints.Find(idSprint));
            return listSprint;
        }
    }
}
