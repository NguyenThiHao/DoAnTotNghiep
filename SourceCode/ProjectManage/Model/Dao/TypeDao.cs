using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TypeDao
    {
        ProjectManageDbContext db = null;
        public TypeDao()
        {
            db = new ProjectManageDbContext();
        }
        //Lấy ra danh sách loại dự án
        public List<string> ListProjectType()
        {
            List<EF.Type> list = db.Types.Where(x=>x.table == "p").ToList();
            List<string> listProjectType = new List<string>();
            foreach(var item in list)
            {
                string type = item.typeName;
                listProjectType.Add(type);
            }
            return listProjectType;
        }

        //Lấy ra danh sách loại công việc
        public List<string> ListTaskType()
        {
            List<EF.Type> list = db.Types.Where(x => x.table == "t").ToList();
            List<string> listTaskType = new List<string>();
            foreach (var item in list)
            {
                string type = item.typeName;
                listTaskType.Add(type);
            }
            return listTaskType;
        }

        //Lấy ra danh sách status của công việc
        public List<string> ListStatus()
        {
            List<EF.Type> list = db.Types.Where(x => x.table == "s").ToList();
            List<string> listStatus = new List<string>();
            foreach (var item in list)
            {
                string type = item.typeName;
                listStatus.Add(type);
            }
            return listStatus;
        }

        //Lấy ra danh sách trạng thái của người dùng
        public List<string> ListStatusUser()
        {
            List<EF.Type> list = db.Types.Where(x => x.table == "s").ToList();
            List<string> listStatusUser = new List<string>();
            foreach (var item in list)
            {
                string type = item.typeName;
                listStatusUser.Add(type);
            }
            return listStatusUser;
        }

        //Lấy ra danh sách vai trò của người dùng trong dự án
        public List<string> ListPosition()
        {
            List<EF.Type> list = db.Types.Where(x => x.table == "su").ToList();
            List<string> listPosition = new List<string>();
            foreach (var item in list)
            {
                string type = item.typeName;
                listPosition.Add(type);
            }
            return listPosition;
        }
    }
}
