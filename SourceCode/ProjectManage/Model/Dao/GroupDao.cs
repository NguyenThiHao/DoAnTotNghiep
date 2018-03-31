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

        //Lấy ra tên của group theo id
        public string GetGroupName(int idGroup)
        {
            return db.Groups.Find(idGroup).groupName.ToString();
        }

    }
}
