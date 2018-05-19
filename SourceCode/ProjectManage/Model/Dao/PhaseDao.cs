using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

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
            entity.startDate = DateTime.Now;
            //Lưu vào CSDL
            db.SaveChanges();
            return entity.idPhase;
        }

        //Lấy ra list Phase
        public List<Phase> GetListPhase()
        {
            return db.Phases.ToList();
        }

        //Lấy ra List<Phase> theo idProject
        public IEnumerable<Phase> ListPhaseByProject(int idProject, int page, int pageSize)
        {
            IQueryable<Phase> model = db.Phases.Where(x => x.idProject == idProject);
            return model.OrderByDescending(x => x.startDate).ToPagedList(page, pageSize);
        }

        //Xem chi tiết của Phase
        public Phase ViewDetail(int idPhase)
        {
            return db.Phases.Find(idPhase);
        }

        //Chỉnh sửa Phase
        public bool EditPhase(Phase entity)
        {
            try
            {
                //Lấy ra project có id giống với id của project cần sửa
                var phase = db.Phases.Find(entity.idPhase);
                //Thay đổi các trường trong project
                phase.phaseName = entity.phaseName;
                phase.description = entity.description;
                phase.startDate = entity.startDate;
                phase.endDate = entity.endDate;
                phase.status = entity.status;
                phase.idProject = entity.idProject;
                //Lưu vào csdl
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Lấy ra tổng số Phase trong 1 project
        public int TotalPhaseByProject(int idProject)
        {
            try
            {
                return db.Phases.Count(x => x.idProject == idProject);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Kiểm tra 1 Phase thuộc Project nào
        public int CheckProject(int idPhase)
        {
            int idProject = db.Phases.SingleOrDefault(x => x.idPhase == idPhase).idProject;
            return idProject;
        }

        //Lấy ra tên của Phase theo id
        public string GetPhaseName(int idPhase)
        {
            return db.Phases.Find(idPhase).phaseName.ToString();
        }

        //Lấy ra 1 phase theo id
        public List<Phase> GetPhaseById(int idPhase)
        {
            List<Phase> listPhase = new List<Phase>();
            Phase phase = db.Phases.Find(idPhase);
            listPhase.Add(phase);
            return listPhase;
        }
    }
}
