using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ServiceController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblService.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var x = db.TblService.Find(p.ServiceID);
            x.ServiceTitle = p.ServiceTitle;
            x.ServiceDescription = p.ServiceDescription;
            x.ServiceIcon = p.ServiceIcon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}