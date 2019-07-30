using EnvironmentalSurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentalSurveyPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditProfile(string id)
        {
            return View(DAO.GetUser(id));
        }
        [HttpPost]
        public ActionResult EditProfile(User eUser)
        {

            DAO.EditProfile(eUser);
            return RedirectToAction("Index");

        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            if (DAO.Delete(id))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Delete User failed");
            return RedirectToAction("Index");
        }
        public ActionResult AllUsers()
        {
            return View(DAO.GetAllUser());
        }

        public ActionResult CreateSurvey()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSurvey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                if (survey.StartDate < survey.EndDate)
                {
                    if (DAO.InsertSurvey(survey))
                    {
                        ViewBag.Successed = true;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "End date must be greater than start date");
                }
            }
            return PartialView("CreateSurveyForm");
        }

        public ActionResult SurveyBoard()
        {
            return View(DAO.GetAllSurvey());
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}