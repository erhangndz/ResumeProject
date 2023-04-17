using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class AboutController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult PartialTechs()
        {
            var x = db.TblTech.ToList();
            return PartialView(x);
        }

        public PartialViewResult PartialReferences()
        {
            var x = db.TblReferences.ToList();
            return PartialView(x);
        }

        public PartialViewResult PartialAboutBanner()
        {
            return PartialView();
        }

        public PartialViewResult PartialAboutSection()
        {
            var x = db.TblProfile.ToList();
            return PartialView(x);
        }

        public PartialViewResult PartialVideo()
        {
            return PartialView();
        }

        public PartialViewResult PartialHireMe()
        {
            return PartialView();
        }
    }

}