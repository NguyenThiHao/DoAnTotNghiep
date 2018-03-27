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
    }
}
