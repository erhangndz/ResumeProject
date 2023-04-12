using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class CategoryController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var x = db.TblCategory.ToList();
            return View(x);
        }

        public ActionResult DeleteCategory(int id)
        {
            var x = db.TblCategory.Find(id);
            db.TblCategory.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var x = db.TblCategory.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateCategory(TblCategory p)
        {
            var x = db.TblCategory.Find(p.CategoryID);
            x.CategoryName = p.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory p)
        {
            db.TblCategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetMessage(int id)
        {
            var values = db.TblContact.Where(x => x.Subject == id).ToList();
            return View(values);
        }
    }
}