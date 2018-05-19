using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;

namespace Model.Dao
{
    //Xử lý công việc liên quan đến Vai trò của người dùng trong project
    public class PositionUserDao
    {
        ProjectManageDbContext db = null;
        public PositionUserDao()
        {
            db = new ProjectManageDbContext();
        }

        //lấy ra danh sách các project mà 1 user đang tham gia
        public List<EF.PositionUser> ListProjectJoined(int idUser)
        {
            var listPositionUser = db.PositionUsers.Where(x => x.idUser == idUser).ToList();
            return listPositionUser;
        }

        //Kiểm tra 1 người có phải là leader của 1 project hay không
        public bool IsLeader(int idUser, int idProject)
        {
            try
            {
                var result = db.PositionUsers.SingleOrDefault(x => x.idUser == idUser & x.idProject == idProject);
                if (result.position == "Project Manager")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Lấy ra chi tiết danh sách user trong 1 project
        public List<UserByProject> ListUserByProject(int idProject)
        {
            List<PositionUser> listPosition = db.PositionUsers.Where(x => x.idProject == idProject).ToList();
            List<UserByProject> listUserByProject = new List<UserByProject>();
            foreach (PositionUser i in listPosition)
            {
                int idUser = i.idUser;
                var userByProject = new UserByProject();
                userByProject.idUser = idUser;
                userByProject.position = i.position;
                userByProject.idProject = i.idProject;
                userByProject.account = new UserDao().GetAccountUser(idUser);
                userByProject.status = i.status;
                userByProject.joinedDate = i.joinedDate;
                userByProject.userName = new UserDao().GetNameUser(idUser);
                listUserByProject.Add(userByProject);
            }
            return listUserByProject;
        }

        //Tìm kiếm PositionUser theo idUser và IdProject
        public PositionUser DetailUserInProject(int idUser, int idProject)
        {
            PositionUser result = db.PositionUsers.SingleOrDefault(x => x.idProject == idProject && x.idUser == idUser);
            return result;
        }

        //Tổng số người tham gia 1 project
        public int TotalUserByProject(int idProject)
        {
            return db.PositionUsers.Count(x => x.idProject == idProject);
        }

        //Tìm kiếm Leader của 1 Project
        public int GetLeaderOfProject(int idProject)
        {
            try
            {
                return db.PositionUsers.SingleOrDefault(x => x.idProject == idProject && x.position == "Project Manager").idUser;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        //Xóa 1 người ra khỏi project
        public bool RemoveUser(int idUser, int idProject)
        {
            try
            {
                var result = db.PositionUsers.SingleOrDefault(x => x.idUser == idUser & x.idProject == idProject);
                db.PositionUsers.Remove(result);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Thêm 1 người vào project
        public bool AddUser(PositionUser entity)
        {
            try
            {
                db.PositionUsers.Add(entity);
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
