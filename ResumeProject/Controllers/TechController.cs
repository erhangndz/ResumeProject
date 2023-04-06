using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class TechController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblTech.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTech()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTech(TblTech p)
        {
            db.TblTech.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTech(int id)
        {
            var value = db.TblTech.Find(id);
            db.TblTech.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTech(int id)
        {
            var value = db.TblTech.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTech(TblTech p)
        {
            var value = db.TblTech.Find(p.TechID);
            value.TechTitle = p.TechTitle;
            value.TechValue = p.TechValue;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}