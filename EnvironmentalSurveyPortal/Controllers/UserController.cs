using EnvironmentalSurveyPortal.Models;
using EnvironmentalSurveyPortal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentalSurveyPortal.Controllers
{
    public class UserController : Controller
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

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Survey()
        {
            return View(DAO.GetAllActiveSurveys());
        }

        public ActionResult SurveyFeedback(int ID)
        {
            Session["login"]=DAO.GetUserByID("ST1099153");
            ViewBag.UserID = ((User)Session["login"]).UserID;
            return View(DAO.GetSurveyByID(ID));
        }

        [HttpPost]
        public ActionResult SurveyFeedback(Feedback feedback)
        {
            if (feedback != null)
            {
                DAO.InsertFeedback(feedback);
                ViewBag.Successed = true;
            }
            return View();
        }
    }
}