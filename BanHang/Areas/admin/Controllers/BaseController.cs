﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.common;

namespace BanHang.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: admin/Base
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext) // day la ham mà truoc khi thuc hien bat ki phuong thuc nao deu phải goi ham nay truoc, no co ho tro ca kieu phuong thuc dong bo
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary( new { Controller = "login", Action = "Index", Areas = "admin" }));
                // neu session rong tuc chua có dang nhap thanh cong thi se dieu huong sang hàm index( trang login) của controler login thuoc areas admin
            }
            base.OnActionExecuted(filterContext);// thuc thi bo loc
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

    }
}