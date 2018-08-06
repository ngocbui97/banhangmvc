using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.common;
using ClassLibrary1.DAO;
using ClassLibrary1.EF;

namespace BanHang.Areas.admin.Controllers
{
    public class UserController : BaseController
    {

        
        // GET: admin/User
        public ActionResult Index(string searchString, int ? page, int pageSize = 2) // chua noi dung trang user khi da create va dang nhap
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(searchString,page ?? 1, pageSize);// get so doi tuong record co the tra ve
            ViewBag.ChuoiTimKiem = searchString;
            return View(model);// view theo so record do
        }
        
        public ActionResult Create() // chay dau tien -< load len trang add user
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)// chay sau khi nhan nut create tren tren user
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var MhMd5 = common.MaHoaMD5.MD5Hash(user.Password);
                user.Password = MhMd5;
                var db = new DBcontext();
                if (db.Users.Any(x => x.Username == user.Username))
                {
                    //ModelState.AddModelError("ThongBao", "Ten User nay da ton tai");// vs key la thong bao se hien ra ben html co validateMessage voi key la ThongBao
                    SetAlert("Tên đăng nhập này đã tồn tại", "error");
                }
                else
                {
                    long id = dao.Insert(user);
                    if (id > 0)
                    {
                        SetAlert("Thêm User thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                       // ModelState.AddModelError("", "Thêm user không thành công.");
                        SetAlert("Thêm user không thành công", "error");
                    }
                }
                
            }
            
        return View("Create");
        }

        public ActionResult Edit(int id)// hien thi dao dien edit
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User u)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!String.IsNullOrEmpty(u.Password))
                {
                    var pass = MaHoaMD5.MD5Hash(u.Password);
                    u.Password = pass;
                }
                var res = dao.Update(u);
                if (res) return RedirectToAction("Index", "User");
                else ModelState.AddModelError("ThongBao", "Cap nhat khong thanh cong");
            }
            return View("Index");
        }

        // tai day khong de HttpDelete duoc ???
       
        public ActionResult Delete(int id)
        {
            var dao = new UserDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
            
        }
    }
}