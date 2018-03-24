using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

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
        public int CreateUser(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.idUser;
        }

        //Login
        public int Login(string account, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.account == account);
            if (result == null )
            {
                return 0;
            }
            else
            {
                if(result.status == false)
                {
                    return -1;
                }
                else
                {
                    if(result.password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        //lấy ra 1 user theo idUser
        public User GetUserById(string account)
        {
            return db.Users.SingleOrDefault(x => x.account == account);
        }

        //Xem chi tiết của 1 user
        public User ViewDetail(int idUser)
        {
            return db.Users.Find(idUser);
        }

        public bool EditUser(User entity)
        {
            try
            {
                //lấy ra user có id giống với user truyền vào
                var user = db.Users.Find(entity.idUser);
                //Thay đổi các trường giá trị trong user
                user.userName = entity.userName;
                user.account = entity.account;
                user.idGroup = entity.idGroup;
                user.mail = entity.mail;
                user.password = entity.password;
                user.status = entity.status;
                //lưu vào DB
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                //Log
                return false;
            }
        }
    }
}

