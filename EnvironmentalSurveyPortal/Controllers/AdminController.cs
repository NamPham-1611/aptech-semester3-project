﻿using EnvironmentalSurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentalSurveyPortal.Controllers
{
    public class AdminController : Controller
    {
        /*----------------------------------
        Dashboard Page Get Action
         -----------------------------------*/
        public ActionResult Index()
        {
            return View();
        }

        /*----------------------------------
        Edit User Page Get Action
         -----------------------------------*/
        public ActionResult EditProfile(string id)
        {
            return View(DAO.GetUserByUID(id));
        }

        /*----------------------------------
        Edit User Post Action
         -----------------------------------*/
        [HttpPost]
        public ActionResult EditProfile(User eUser)
        {

            DAO.EditProfile(eUser);
            return RedirectToAction("Index");

        }

        /*----------------------------------
        Delete User Action
         -----------------------------------*/
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

        /*----------------------------------
        User List Page Get Action
         -----------------------------------*/
        public ActionResult AllUsers()
        {
            return View(DAO.GetAllUser());
        }

        /*----------------------------------
        Active User Get Action
         -----------------------------------*/
        public ActionResult ActiveUser(string id)
        {
            DAO.SetActiveUser(id);
            return RedirectToAction("AllUsers");
        }

        public ActionResult SurveyBoard()
        {
            return View(DAO.GetAllSurvey());
        }

        /*----------------------------------
        Create User Page Get Action
         -----------------------------------*/
        public ActionResult CreateSurvey()
        {
            return View();
        }

        /*----------------------------------
        Create User Post Action
         -----------------------------------*/
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

        /*----------------------------------
        Edit Survey Page Get Action
         -----------------------------------*/
        public ActionResult EditSurvey(int ID)
        {
            var t = DAO.GetSurveyByID(ID);
            return View(t);
        }

        /*----------------------------------
        Edit Survey Post Action
         -----------------------------------*/
        [HttpPost]
        public ActionResult EditSurvey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                if (survey.StartDate < survey.EndDate)
                {
                    if (DAO.UpdateSurvey(survey))
                    {
                        ViewBag.Successed = true;
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occur! Please try again!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "End date must be greater than start date");
                }
            }
            return PartialView("EditSurveyForm", survey);
        }

        /*----------------------------------
        Delete Survey Get Action
         -----------------------------------*/
        public ActionResult DeleteSurvey(int ID)
        {
            DAO.DeleteSurvey(ID);
            return RedirectToAction("SurveyBoard");
        }

        /*----------------------------------
        Create Account Page Get Action
         -----------------------------------*/
        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}