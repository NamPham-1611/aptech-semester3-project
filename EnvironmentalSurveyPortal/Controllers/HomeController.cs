using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnvironmentalSurveyPortal.Models;
namespace EnvironmentalSurveyPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.NoF = DAO.CountFeedback();
            return View(DAO.GetAllSurvey());
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCodeResult Feedback(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                if (DAO.InsertFeedback(feedback))
                {
                    return new HttpStatusCodeResult(200);
                }
            }
            return new HttpStatusCodeResult(304);
        }
    }
}