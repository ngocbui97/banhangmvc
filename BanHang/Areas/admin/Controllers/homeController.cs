﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHang.Areas.admin.Controllers
{
    public class homeController : BaseController
    {
        // GET: admin/home
        public ActionResult Index()
        {
            return View();
        }
    }
}