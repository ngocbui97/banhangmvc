using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1.DAO;
namespace BanHang.Areas.admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: admin/Content
        public ActionResult Index()
        {
            return View();
        }

        // GET: admin/Content/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/Content/Create
       
        public ActionResult Create()
        {
            SetViewBag();
            return View();
            
        }

        private void SetViewBag(long? selectedID= null)
        {
            
                var dao = new ProductCategoryDAO();
                ViewBag.Link = new SelectList(dao.ListAll(), "CategoryID", "Name", selectedID);
            //list-gan colum value cho tung selection tuong ung- chon truong coloum tren db se hien thi- chon selected item hien thi
        }

        // POST: admin/Content/Create
        

        // GET: admin/Content/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin/Content/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Content/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin/Content/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
