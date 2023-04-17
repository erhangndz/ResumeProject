using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ReferenceController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var x = db.TblReferences.ToList();
            return View(x);
        }

        public ActionResult DeleteReference(int id)
        {
            var x = db.TblReferences.Find(id);
            db.TblReferences.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateReference(int id)
        {
            var x = db.TblReferences.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateReference(TblReferences p)
        {
            var x = db.TblReferences.Find(p.ReferenceID);
            x.NameSurname = p.NameSurname;
            x.Job = p.Job;
            x.ImageURL = p.ImageURL;
            x.Comment = p.Comment;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddReference()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReference(TblReferences p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.TblReferences.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}