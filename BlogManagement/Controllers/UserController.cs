using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogManagement.Controllers
{
    public class UserController : Controller
    {
        BlogDBContext db = new BlogDBContext();
        // GET: User
        public ActionResult Index()
        {
            return View(db.Accounts.First(x=>x.Email == User.Identity.Name));
        }
        //KIEM TRA ID
        [HttpGet]
        public ActionResult Thaydoianh(int ID)
        {
            //truy van den co so du lieu lay id ra
            Account user = db.Accounts.SingleOrDefault(n => n.AccountId == ID);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ////Dua du lieu cao dropdownList 
            ViewBag.ID = new SelectList(db.Accounts.ToList().OrderBy(n => n.UserName), "AccountId", "Image", user.AccountId);


            return View(user);
        }


        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Thaydoianh(Account user, HttpPostedFileBase updateFile)
        {

            if (ModelState.IsValid)
            {
                //lưu tên file ảnh
                if (updateFile != null)
                {
                    var fileName = Path.GetFileName(updateFile.FileName);
                    //lưu đường dẫn file ảnh

                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.HinhAnh = "Hình ảnh đã lưu";
                    }
                    else
                    {
                        updateFile.SaveAs(path);
                    }
                    user.Image = updateFile.FileName;
                    db.SaveChanges();
                }
                //kiem tra hình anh đã tồn tại chưa


            }
            if (ModelState.IsValid)
            {
                db.Accounts.Attach(user);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                ViewBag.Ten = "Thay đổi tên thành công";
                db.SaveChanges();
            }
            if (updateFile == null)
            {
                ViewBag.HinhAnh = "Chưa thay ảnh mới";
            }
            return View();


        }
        public ActionResult IndexGT()
        {
            return View(db.Accounts.First(x => x.Email == User.Identity.Name));
        }

        //KIEM TRA ID
        [HttpGet]
        public ActionResult ChinhSua(int ID)
        {
            //truy van den co so du lieu lay id ra
            Account user = db.Accounts.SingleOrDefault(n => n.AccountId == ID);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }


            return View(user);
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(Account user, HttpPostedFileBase updateFile)
        {
            if (ModelState.IsValid)
            {
                //lưu tên file ảnh
                if (updateFile != null)
                {
                    var fileName = Path.GetFileName(updateFile.FileName);
                    //lưu đường dẫn file ảnh

                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.HinhAnh = "Hình ảnh đã lưu";
                    }
                    else
                    {
                        updateFile.SaveAs(path);
                    }
                    user.Image = updateFile.FileName;
                    db.SaveChanges();
                } 
                //kiem tra hình anh đã tồn tại chưa
                

            }
            if (ModelState.IsValid)
            {
                db.Accounts.Attach(user);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                ViewBag.Ten = "Thay đổi tên thành công";
                db.SaveChanges();
            }
                if (updateFile == null)
                {
                    ViewBag.HinhAnh = "Chưa thay ảnh mới";
                }
            return View();
        }
    }
}
 