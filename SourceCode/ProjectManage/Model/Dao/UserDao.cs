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

        public List<string> GetListCredential(string account)
        {
            var user = db.Users.Single(x => x.account == account);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.idUserGroup equals b.id
                        join c in db.Roles on a.idRole equals c.id
                        where b.id == user.idGroupUser
                        select new
                        {
                            idRole = a.idRole,
                            idUserGroup = a.idUserGroup
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            idRole = x.idRole,
                            idUserGroup = x.idUserGroup
                        });
            return data.Select(x => x.idRole).ToList();

        }

        //Login
        public int Login(string account, string password, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.account == account);
            if (result == null )
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.idGroupUser == CommonConstants.ADMIN_GROUP)
                    {
                        if (result.status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.password == password)
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
        }

        //lấy ra 1 user theo idUser
        public User GetUserByAccount(string account)
        {
            return db.Users.SingleOrDefault(x => x.account == account);
        }

        //Xem chi tiết của 1 user
        public User GetUserById(int idUser)
        {
            return db.Users.Find(idUser);
        }

        //Chỉnh sửa thông tin User
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

        //Lấy ra tên của 1 idUser
        public string GetNameUser(int idUser)
        {
            try
            {
                return db.Users.SingleOrDefault(x => x.idUser == idUser).userName.ToString();
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        //Lấy ra account của 1 idUser
        public string GetAccountUser(int idUser)
        {
            try
            {
                return db.Users.SingleOrDefault(x => x.idUser == idUser).account.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        //Lấy ra danh sách User
        public List<User> ListUser()
        {
            return db.Users.ToList();
        }
    }
}

