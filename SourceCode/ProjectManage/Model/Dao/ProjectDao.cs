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
                project.typeProject = entity.typeProject;
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
                startdate = startdate.AddDays(1);
                chart.day = startdate.ToString("yyyy-MM-dd");
                chart.create = new TaskDao().TotalCreatedTask(startdate, idProject);
                chart.inprogress = new TaskDao().TotalInprogress(startdate, idProject);
                chart.done = new TaskDao().TotalDoneTask(startdate, idProject);
                listChart.Add(chart);
            }
            return listChart;
        }
        
    }
}
