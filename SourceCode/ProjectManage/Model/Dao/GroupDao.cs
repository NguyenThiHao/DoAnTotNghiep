using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class GroupDao
    {
        ProjectManageDbContext db = null;
        public GroupDao()
        {
            db = new ProjectManageDbContext();
        }

        //Lấy ra danh sách của group
        public List<Group> listGroup()
        {
            return db.Groups.ToList();
        }

    }
}
