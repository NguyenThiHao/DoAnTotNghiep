using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class PhaseDao
    {
        ProjectManageDbContext db = null;
        public PhaseDao()
        {
            db = new ProjectManageDbContext();
        }

        //Thêm mới 1 phase
        public int CreatePhase(Phase entity)
        {
            //Thêm dữ liệu vào bảng Phase
            db.Phases.Add(entity);
            //Thiết đặt status
            entity.status = "Created";
            //Lưu vào CSDL
            db.SaveChanges();
            return entity.idPhase;
        }

        //Lấy ra list Phase
        public List<Phase> GetListPhase()
        {
            return db.Phases.ToList();
        }
    }
}
