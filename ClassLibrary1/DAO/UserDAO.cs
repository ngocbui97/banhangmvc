using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using ClassLibrary1.EF;

namespace ClassLibrary1.DAO
{
    public class UserDAO
    {
        public DBcontext db = null;
       public UserDAO()
        {
            db = new DBcontext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }
        public Boolean Update(User u) // thuc hien update sau nhan button
        {
            try
            {
                var user = db.Users.Find(u.UserID);
                user.Username = u.Username;
                if(u.Password!=null|| u.Password == "")
                {
                    user.Password = u.Password;
                }
                user.Email = u.Email;
                user.Phone = u.Phone;
                user.Status = u.Status;
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        public User ViewDetail(int id) // hien thi thong tin chi tiet cua nguoi dung
        {
            return db.Users.Find(id);
        }

        public Boolean Delete(int id)
        {
            try
            {
                var u = db.Users.Find(id);
                db.Users.Remove(u);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }
        //public bool Login(String name, string pass)
        //{
        //    var a = db.Users.Count(x => x.Username == name && x.Password == pass);
        //    if (a > 0) return true;
        //    else return false;
        //}
        // nang cap login
        public int Login(String name, string pass)
        {
            var res = db.Users.SingleOrDefault(x => x.Username == name);
            if (res == null) return 0;
            else if (res.Status == false) return -1;// dang bi khoa
            else
            {
                if (res.Password == pass) return 1;
                else return -2;// sai pass
            }
        }
        public User GetByName(string Name)
        {
            return db.Users.SingleOrDefault(x => x.Username == Name);
        }



        //ho tro phan trang
        //    public IEnumerable<User> ListAllPaging(int page, int pageSize)
        //{
        //    return db.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page,
        //   pageSize);
        //}

        public IEnumerable<User> ListAllPaging(string searchString, int ? page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (String.IsNullOrEmpty(searchString)==false)
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.Email.Contains(searchString));

            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page ?? 1, pageSize);

        }
    }
}
