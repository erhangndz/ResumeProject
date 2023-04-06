using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ProfileController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var x = db.TblProfile.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult ProfileDetails(int id)
        {
            var x = db.TblProfile.Find(id);
            return View(x);
        }

        public ActionResult DeleteProfile(int id)
        {
            var x = db.TblProfile.Find(id);
            db.TblProfile.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var x = db.TblProfile.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var x = db.TblProfile.Find(p.ProfileID);
            x.Name = p.Name;
            x.profileDescription = p.profileDescription;
            x.mail = p.mail;
            x.phone = p.phone;
            x.address = p.address;
            x.socialnetwork1 = p.socialnetwork1;
            x.socialnetwork2 = p.socialnetwork2;
            x.socialnetwork3 = p.socialnetwork3;
            x.socialnetwork4 = p.socialnetwork4;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProfile(TblProfile p)
        {

            db.TblProfile.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}