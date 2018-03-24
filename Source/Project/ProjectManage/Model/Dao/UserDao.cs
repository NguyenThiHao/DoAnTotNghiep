using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.Entity;

namespace Model.Dao
{
    public class UserDao
    {
        ProjectManageDbContext db = null;
        public UserDao()
        {
            db = new ProjectManageDbContext();
        }

        // Thêm mới 1 người dùng
        public int InsertUser(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.idUser;
        }

        //Login
        public bool Login(string account, string password)
        {
            var result = db.Users.Count(x => x.account == account && x.password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //lấy ra 1 user theo idUser
        public User GetUserById(string account)
        {
            return db.Users.SingleOrDefault(x => x.account == account);
        }
    }
}
