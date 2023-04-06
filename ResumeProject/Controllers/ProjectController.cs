using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ProjectController : Controller
    {

        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var x = db.TblProject.ToList();
            return View(x);
        }

        public ActionResult DeleteProject(int id)
        {
            var x = db.TblProject.Find(id);
            db.TblProject.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var x = db.TblProject.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var x = db.TblProject.Find(p.ProjectID);
            x.ProjectTitle = p.ProjectTitle;
            x.ProjectDescription = p.ProjectDescription;
            x.projectimageurl = p.projectimageurl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProject p)
        {
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}