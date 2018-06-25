using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogManagement.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private DAL.UnitOfWork.UnitOfWork uow;
        private AccountBLL accountBLL;
        private PostBLL postBLL;
        public HomeController()
        {
            uow = new DAL.UnitOfWork.UnitOfWork(new DAL.Entities.BlogDBContext());
            accountBLL = new AccountBLL(uow);
            postBLL = new PostBLL(uow);
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            if(isAdmin())
            {
                int max = 0;
                Account account = new Account();
                foreach (var item in accountBLL.getAll())
                {
                    int count = 0;
                    foreach (var i in postBLL.getAll())
                    {
                        if (i.AccountId == item.AccountId) count++;
                    }
                    if (max < count)
                    {
                        max = count;
                        account = item;
                    }
                }
                ViewBag.Max = max;
                ViewBag.AccMax = account;
                ViewBag.UserCount = accountBLL.getAll().Count();
                return View(accountBLL.getAll());
            }
            return RedirectToAction("Notification");
        }
        public ActionResult Edit(int id)
        {
            if(isAdmin())
            {
                return View(accountBLL.getById(id));
            }
            return RedirectToAction("Notification");
        }
        [HttpPost]
        public ActionResult Edit(Account model)
        {
            accountBLL.Update(model);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            if (isAdmin())
            {
                return View();
            }
            return RedirectToAction("Notification");
        }
        [HttpPost]
        public ActionResult Create(Account model)
        {
            accountBLL.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if(isAdmin())
            {
                accountBLL.Delete(accountBLL.getById(id));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Account");
        }
        public bool isAdmin()
        {
            if(User.Identity.IsAuthenticated)
            {
                Account account = accountBLL.getByEmail(User.Identity.Name);
                if (account.isAdmin) return true;
            }
            return false;
        }
        public ActionResult Notification()
        {
            return View();
        }
    }
}