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
        public List<PositionUser> ListProjectJoined(int idUser)
        {
            var listPositionUser = db.PositionUsers.Where(x => x.idUser == idUser).ToList();
            return listPositionUser;
        }
    }
}
