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
        //Check login status
        [NonAction]
        public bool CheckLogin()
        {
            if (Session["login"] == null)
            {
                return false;
            }
            return true;
        }
        
        //Index page
        public ActionResult Index()
        {
                ViewBag.NoF = DAO.CountFeedback();
                return View(DAO.getIndex());
        }

        // Post login infomation
        [HttpPost]
        public ActionResult Login(Login l)
        {
            if (ModelState.IsValid)
            {
                var t = DAO.GetLoginUser(l.UserID,l.Password);

                if (t != null)
                {
                    Session["login"] = t;
                    ViewBag.User = t.Name;
                    return RedirectToAction("index");
                }

                else
                {
                    ViewBag.User = "";
                    ModelState.AddModelError("", "Wrong User ID or password, please try again!");
                    return View();
                }
            }

            ModelState.AddModelError("", "Wrong User ID or password, please try again!");
            return View();
        }

        // Post feedback
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

        // Logout
        public ActionResult Logout()
        {
            Session.Remove("login");
            return RedirectToAction("login");
        }

        // Register form
        public ActionResult Register()
        {
            return View();
        }
         // Post register infomation
        [HttpPost]
        public ActionResult Register(Register r)
        {
            var t = DAO.GetUserByID(r.UserID);

            if (t == null)
            {
                var NewUser = new User() { UserID = r.UserID, Name = r.Name, Password = r.Password, Class = r.Class, Specification = r.Specification, Section = r.Section, Role = "null", Active = true };
                DAO.InsertUser(NewUser);
                return RedirectToAction("login");
            }

            else
            {
                ModelState.AddModelError("", "User ID already exist!");
                return View();
            }
        }

        // View activation status
        public ActionResult Activation()
        {
            return View();
        }
    }
}