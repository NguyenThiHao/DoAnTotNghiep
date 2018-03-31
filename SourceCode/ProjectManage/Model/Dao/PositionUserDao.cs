using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

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
                if (result.position == "Leader")
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

        ////lấy ra danh sách user theo project
        //public List<UserByProject> listUserByProject(int idProject)
        //{
        //    var listUserByProject = (List<UserByProject>)from p in db.Projects
        //                            where p.idProject == idProject
        //                            join pu in db.PositionUsers
        //                            on p.idProject equals pu.idProject
        //                            join u in db.Users
        //                            on pu.idUser equals u.idUser
        //                            select new
        //                            {
        //                                idUser = p.idProject,
        //                                userName = u.userName,
        //                            };
        //    return listUserByProject;
        //}

        //Tìm kiếm PositionUser theo idUser và IdProject
        public PositionUser DetailUserInProject(int idUser, int idProject)
        {
            PositionUser result = db.PositionUsers.SingleOrDefault(x => x.idProject == idProject && x.idUser == idUser);
            return result;
        }
    }
}
