using EnvironmentalSurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            return RedirectToAction("SurveyBoard");
        }

        /*----------------------------------
        Edit User Page Get Action
         -----------------------------------*/
        public ActionResult EditUser(string id)
        {
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View(DAO.GetUserByUID(id));
        }

        /*----------------------------------
        Edit User Post Action
         -----------------------------------*/
        [HttpPost]
        public ActionResult EditUser(User eUser)
        {

            DAO.UpdateUser(eUser);
            return RedirectToAction("AllUsers");
        }

        /*----------------------------------
        Delete User Get Action
         -----------------------------------*/
        public ActionResult DeleteUser(string id)
        {
            DAO.DeleteUser(id);            
            return RedirectToAction("AllUsers");
        }

        /*----------------------------------
        User List Page Get Action
         -----------------------------------*/
        public ActionResult AllUsers()
        {
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
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
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View(DAO.GetAllSurvey());
        }

        /*----------------------------------
        Create Survey Page Get Action
         -----------------------------------*/
        public ActionResult CreateSurvey()
        {
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View();
        }

        /*----------------------------------
        Create Survey Post Action
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
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View(DAO.GetSurveyByID(ID));
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
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View();
        }

        /*----------------------------------
        Edit Support Infomation Page Get Action
        -----------------------------------*/
        public ActionResult EditSupportInfo()
        {
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View(DAO.GetSupportInfo());
        }

        /*----------------------------------
       Edit Support Infomation Post Action
        -----------------------------------*/
        [HttpPost]
        public ActionResult EditSupportInfo(Support e)
        {
            DAO.EditSupportInfo(e);
            return RedirectToAction("EditSupportInfo");
        }

        /*----------------------------------
      Upload File Post Action
        -----------------------------------*/
        [HttpPost]
        public string Upload(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var physicPath = Server.MapPath("~/Images/" + fileName);
            file.SaveAs(physicPath);
            return "/Images/" + fileName;
        }
    }
}