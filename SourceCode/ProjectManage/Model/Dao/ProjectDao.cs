using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;
namespace Model.Dao
{
    public class ProjectDao
    {
        ProjectManageDbContext db = null;
        public ProjectDao()
        {
            db = new ProjectManageDbContext();
        }

        //Thêm mới 1 project
        public int CreateProject(Project entity)
        {
            //Thêm dữ liệu vào bảng Project
            db.Projects.Add(entity);
            //Thay đổi trạng thái cho trường status
            entity.status = "Created";
            //Lưu bảng mới thêm vào DB
            db.SaveChanges();
            return entity.idProject;
        }


        //Tìm kiếm project theo Id
        public Project GetProjectById(int idProject)
        {
            var project = db.Projects.SingleOrDefault(n => n.idProject == idProject);
            return project;
        }

        //Xem chi tiết của Project
        public Project ViewDetail(int idProject)
        {
            return db.Projects.Find(idProject);
        }

        //Chỉnh sửa Project
        public bool EditProject(Project entity)
        {
            try
            {
                //Lấy ra project có id giống với id của project cần sửa
                var project = db.Projects.Find(entity.idProject);
                //Thay đổi các trường trong project
                project.projectName = entity.projectName;
                project.description = entity.description;
                project.startDate = entity.startDate;
                project.endDate = entity.endDate;
                project.status = entity.status;
                //Lưu vào csdl
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }  
        }

        //Lấy ra tên của project theo idProject
        public string GetProjectName(int idProject)
        {
            return db.Projects.Find(idProject).projectName.ToString();
        }

        //Lấy ra List project
        public List<Project> GetListProject()
        {
            return db.Projects.ToList();
        }

        //Vẽ biểu đồ
        public List<ChartParse> ListChart(int idProject)
        {
            List<ChartParse> listChart = new List<ChartParse>();
            
            DateTime startdate = db.Projects.Find(idProject).startDate;
            
            while (DateTime.Compare(startdate, DateTime.Today) < 0)
            {
                ChartParse chart = new ChartParse();
                startdate = startdate.AddDays(1);//dang ra ham nay phai ađ duoc chu nho. thi t cung hoc tren mang thoi :v
                chart.date = startdate.ToString("dd/MM/yyyy");
                chart.create = new TaskDao().TotalCreatedTask(startdate, idProject);
                chart.inprogress = new ResultDao().TotalInProgress(idProject, startdate);
                chart.done = new TaskDao().TotalDoneTask(startdate, idProject);
                listChart.Add(chart);
            }
            return listChart;
        }
        
    }
}

//hinh nhu phải dùng for ms đúng chứ nhỉ. Lấy từ ngày bắt đầu dự án đến ngày hôm nay. 
//    hình như đang sai ở đây rồi (
//    nuhhuwng nói chung ý t là: muốn tính toán công việc từng ngày, từ ngày bắt đầu đến ngày hôm nay
//    m sua xem, testc thay hinh nhu no dang bi sao. uh. giơ t cũng thấy sai sai :d :v
//    giờ sửa thé nào dc.
//    cai db.Prọect kia la lay duoc t chua hieu cai ni 

//    hàm totalCreate kia là tính trong ngày nào đó, 1 project có bao nhiêu task dc tạo ra
//    total inprogress ngày nào đó dc truyền vào 1 project --> task đang thực hiện
//    à, run di