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
        /*----------------------------------
        Home Page Get Action
         -----------------------------------*/
        public ActionResult Index()
        {
            ViewBag.NoF = DAO.CountFeedback();
            return View(DAO.getIndex());
        }

        /*----------------------------------
        Check Login Post Action
         -----------------------------------*/
        [HttpPost]
        public PartialViewResult CheckLogin(Login l)
        {
            if (ModelState.IsValid)
            {
                return PartialView("LoginForm");
            }

            ModelState.AddModelError("", "Wrong User ID or password, please try again!");
            return PartialView("LoginForm");
        }

        /*----------------------------------
        Feedback Post Action
         -----------------------------------*/
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

        /*----------------------------------
        Logout Post Action
         -----------------------------------*/
         [HttpPost]
        public ActionResult Logout()
        {
            Session.Remove("login");
            return RedirectToAction("login");
        }

        /*----------------------------------
        Check Register Post Action
         -----------------------------------*/
        [HttpPost]
        public PartialViewResult CheckRegister(Register r)
        {
            if (ModelState.IsValid)
            {
                return PartialView("RegisterForm");
            }

            ModelState.AddModelError("", "User ID already exist!");
            return PartialView("RegisterForm");
        }

        /*----------------------------------
        Search Get Action
         -----------------------------------*/
        public ActionResult Search(string q)
        {
            ViewBag.TXT = q;
            ViewBag.prizes = DAO.GetAllPrize();
            return View(DAO.SearchSurvey(q));
        }

    }
}