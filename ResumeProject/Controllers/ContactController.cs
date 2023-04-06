using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ContactController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var x = db.TblContact.Find(id);
            db.TblContact.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var x = db.TblContact.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateContact(TblContact p)
        {
            var x = db.TblContact.Find(p.ContactID);
            x.NameSurname = p.NameSurname;
            x.TblCategory.CategoryName = p.TblCategory.CategoryName;
            x.Date = p.Date;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult OpenContact(int id)
        {
            var x = db.TblContact.Find(id);
            return View(x);
        }
    }
}