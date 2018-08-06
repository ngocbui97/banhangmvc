using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.Areas.admin.Models;
using BanHang.common;
using ClassLibrary1.DAO;

namespace BanHang.Areas.admin.Controllers
{
    public class loginController : Controller
    {
        // GET: admin/login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.UserName, MaHoaMD5.MD5Hash(model.PassWord));
                if (res == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserId = user.UserID;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "home");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tai khoan khong ton tai");

                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tai khoan dang bi khoa");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mat khau sai");

                }
                else ModelState.AddModelError("", "Thong tin dang nhap sai");

            }
            return View("Index");

        }
    }
}