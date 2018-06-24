using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogManagement.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryBLL categoryBLL;
        DAL.UnitOfWork.UnitOfWork uow;
        public CategoryController()
        {
            uow = new DAL.UnitOfWork.UnitOfWork(new DAL.Entities.BlogDBContext());
            categoryBLL = new CategoryBLL(uow);
        }

        // GET: Admin/Category
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryBLL.Add(category);
            return RedirectToAction("Home/Index");
        }
        public ActionResult Edit(int idCate)
        {
            return View(categoryBLL.get(idCate));
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryBLL.Update(category);
            return RedirectToAction("Home/Index");
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoryBLL.Delete(category);
            return RedirectToAction("Home/Index");
        }
        public ActionResult List()
        {
            return View(categoryBLL.getAll());
        }


    }
}