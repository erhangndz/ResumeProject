using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class StatisticController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            //ViewBag.skillcount = db.TblSkill.Count();
            ViewBag.countprojetalebi = db.countprojetalebi().FirstOrDefault();
            ViewBag.techcount = db.TblTech.Count();
            ViewBag.csharpValue = db.TblTech.Where(x => x.TechTitle == "C#").Select(y => y.TechValue).FirstOrDefault();
            ViewBag.contactCount = db.TblContact.Count();
            ViewBag.subjectTesekkur = db.TblContact.Where(x => x.TblCategory.CategoryName == "Teşekkür").Count();
            ViewBag.sumTechValue = db.TblTech.Sum(x => x.TechValue);
            ViewBag.avgTechValue = db.TblTech.Average(x => x.TechValue);
            ViewBag.GetBy3ID = db.TblSkill.Where(x => x.SkillID == 3).Select(y => y.SkillTitle).FirstOrDefault();
            ViewBag.maxTechValue = db.TblTech.Max(x => x.TechValue);
            return View();
        }
    }
}