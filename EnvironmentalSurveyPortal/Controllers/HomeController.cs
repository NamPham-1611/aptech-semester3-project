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
            ViewBag.Counter = DAO.CountFeedback();
            ViewBag.User = Auth.CheckLoginState(Request);
            return View(DAO.GetDataForIndex());
        }

        /*----------------------------------
        Check Login Post Action
         -----------------------------------*/
        [HttpPost]
        public PartialViewResult CheckLogin(LoginAccount l)
        {
            if (ModelState.IsValid)
            {
                var u = Auth.CheckAccount(l);
                if (u != null)
                {
                    HttpCookie authCookie = new HttpCookie("UID", u.UID);
                    authCookie.Expires = DateTime.Now.AddDays(60);
                    Response.Cookies.Add(authCookie);
                    Response.Flush();
                }
                else
                {
                    Response.StatusCode = 201;
                    ModelState.AddModelError("", "Account has not been activated !");
                }
                
                return PartialView("LoginForm");
            }
            Response.StatusCode = 201;
            ModelState.AddModelError("", "Wrong User ID or password, please try again!");
            return PartialView("LoginForm");
        }

        /*----------------------------------
        Check Register Post Action
         -----------------------------------*/
        [HttpPost]
        public PartialViewResult CheckRegister(User u)
        {
            if (ModelState.IsValid)
            {
                if (DAO.InsertUser(u))
                {
                   
                }
                else
                {
                    Response.StatusCode = 201;
                    ModelState.AddModelError("", "Account already exist !");
                }
                return PartialView("RegisterForm");
            }

            Response.StatusCode = 201;
            return PartialView("RegisterForm");
        }

        /*----------------------------------
        Logout Get Action
         -----------------------------------*/
        public ActionResult Logout()
        {
            HttpCookie authCookie = new HttpCookie("UID", "");
            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Index");
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
        Search Get Action
         -----------------------------------*/
        public ActionResult Search(string q)
        {
            ViewBag.TXT = q;
            ViewBag.prizes = DAO.GetAllPrize();
            return View(DAO.SearchSurvey(q));
        }

        /*----------------------------------
        Support Get Action
         -----------------------------------*/
        public ActionResult Support()
        {
            return View(DAO.);
        }

    }
}