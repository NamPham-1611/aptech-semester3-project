using EnvironmentalSurveyPortal.Models;
using Newtonsoft.Json;
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
            if (Session["User"] != null)
            {
                return RedirectToAction("SurveyBoard");
            }
            return RedirectToAction("Login");
        }


        /*----------------------------------
        Login Page Get Action
         -----------------------------------*/
        public ActionResult Login()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("SurveyBoard");
            }
            return View();
            
        }

        /*----------------------------------
        Login Post Action
         -----------------------------------*/
        [HttpPost]
        public string Login(LoginAccount user)
        {
            var x = DAO.GetLoginUser(user.UID, user.Password);
            if (x != null)
            {
                if (x.Role.ToLower() == "admin")
                {
                    Session["User"] = x;
                    return "OK";
                }
                return "User is not authorized !";
            }
            return "Username or password incorrect !";
        }

        /*----------------------------------
        Logout Get Action
         -----------------------------------*/
        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Login");
        }

        /*----------------------------------
        Edit User Page Get Action
         -----------------------------------*/
        public ActionResult EditUser(string id)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetUserByUID(id));
            }
            return RedirectToAction("Login");
        }

        /*----------------------------------
        Edit User Post Action
         -----------------------------------*/
        [HttpPost]
        public ActionResult EditUser(User eUser)
        {
            if (Session["User"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (DAO.UpdateUser(eUser))
                    {
                        return RedirectToAction("AllUsers");
                    }
                }
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(eUser);
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Delete User Get Action
         -----------------------------------*/
        public ActionResult DeleteUser(string id)
        {
            if (Session["User"] != null)
            {
                DAO.DeleteUser(id);
                return RedirectToAction("AllUsers");
            }
            return RedirectToAction("Login");
        }

        /*----------------------------------
        User List Page Get Action
         -----------------------------------*/
        public ActionResult AllUsers()
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetAllUser());
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Active User Get Action
         -----------------------------------*/
        public ActionResult ActiveUser(string id)
        {
            if (Session["User"] != null)
            {
                DAO.SetActiveUser(id);
                return RedirectToAction("AllUsers");
            }
            return RedirectToAction("Login");

        }

        public ActionResult SurveyBoard()
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetAllSurvey());
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Create Survey Page Get Action
         -----------------------------------*/
        public ActionResult CreateSurvey()
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View();
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Create Survey Post Action
         -----------------------------------*/
        [HttpPost]
        public ActionResult CreateSurvey(Survey survey)
        {
            if (Session["User"] != null)
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
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Edit Survey Page Get Action
         -----------------------------------*/
        public ActionResult EditSurvey(int ID)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetSurveyByID(ID));
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Edit Survey Post Action
         -----------------------------------*/
        [HttpPost]
        public ActionResult EditSurvey(Survey survey)
        {
            if (Session["User"] != null)
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

                return PartialView("EditSurveyForm", DAO.GetSurveyByID(survey.ID));
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Delete Survey Get Action
         -----------------------------------*/
        public ActionResult DeleteSurvey(int ID)
        {
            if (Session["User"] != null)
            {
                DAO.DeleteSurvey(ID);
                return RedirectToAction("SurveyBoard");
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Feedbacks Get Action
         -----------------------------------*/
        public ActionResult Feedbacks(int ID)
        {
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View(DAO.GetFeedbackBySurveyID(ID));
        }

        /*----------------------------------
        Feedback Details Get Action
         -----------------------------------*/
        public ActionResult Feedback(int ID)
        {
            if (Session["User"] != null)
            {
                DAO.SetFeedbackIsSeen(ID);
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetFeedbackByID(ID));
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Feedback Analysis Get Action
         -----------------------------------*/
        public ActionResult SurveyAnalysis(int ID)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                ViewBag.FeedbackAnswers = DAO.GetFeedbackAnswers(ID);
                return View(DAO.GetSurveyByID(ID));
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Create Account Page Get Action
         -----------------------------------*/
        public ActionResult CreateAccount()
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View();
            }
            return RedirectToAction("Login");

        }


        /*----------------------------------
        Create Account Post Action
         -----------------------------------*/
        [HttpPost]
        public ActionResult CreateAccount(RegisterAccount acc)
        {
            if (Session["User"] != null)
            {
                if (ModelState.IsValid)
                {
                    var user = new User { UID = acc.UID, Name = acc.Name, Password = acc.Password, Class = acc.Class, Specification = acc.Specification, Role = acc.Role, Section = acc.Section };

                    if (DAO.InsertUser(user))
                    {
                        ViewBag.Successed = true;
                    }
                }
                return PartialView("CreateAccountForm");
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Edit Support Infomation Page Get Action
        -----------------------------------*/
        public ActionResult EditSupportInfo()
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetSupportInfo());
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
       Edit Support Infomation Post Action
        -----------------------------------*/
        [HttpPost]
        public ActionResult EditSupportInfo(Support e)
        {
            if (Session["User"] != null)
            {
                DAO.EditSupportInfo(e);
                return RedirectToAction("EditSupportInfo");
            }
            return RedirectToAction("Login");

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

        /*----------------------------------
        Add Answer Post Action
        -----------------------------------*/
        [HttpPost]
        public int AddAnswer(SurveyAnswer answer)
        {
            return DAO.InsertAnswer(answer);
        }

        /*----------------------------------
        Delete Answer Post Action
        -----------------------------------*/
        [HttpPost]
        public string DeleteAnswer(int answerID)
        {
            if (DAO.DeleteAnswer(answerID))
            {
                return "OK";
            }
            return "Error";
        }

        /*----------------------------------
        Add Question Post Action
        -----------------------------------*/
        [HttpPost]
        public int AddQuestion(SurveyQuestion question)
        {
            return DAO.InsertQuestion(question);
        }

        /*----------------------------------
        Delete Answer Post Action
        -----------------------------------*/
        [HttpPost]
        public string DeleteQuestion(int questionID)
        {
            if (DAO.DeleteQuestion(questionID))
            {
                return "OK";
            }
            return "Error";
        }
    }
}