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
                    Session.Timeout = 60;
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
                        return new HttpStatusCodeResult(200);
                    }
                }
                Response.StatusCode = 201;
                return PartialView("CreateAccountForm");
            }
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
                if (DAO.DeleteUser(id))
                {
                    return RedirectToAction("AllUsers");
                }
                return new HttpStatusCodeResult(201);
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


        /*----------------------------------
        Get /Admin/SurveyBorad
         -----------------------------------*/
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
        Get /Admin/AllCompetitions
         -----------------------------------*/
        public ActionResult AllCompetitions()
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetAllCompetition());
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Get /Admin/CreateCompetition
         -----------------------------------*/
        public ActionResult CreateCompetition()
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View();
            }
            return RedirectToAction("Login");

        }


        /*----------------------------------
        Post /Admin/CreateCompetition
         -----------------------------------*/
        [HttpPost]
        public ActionResult CreateCompetition(Competition competition)
        {
            if (Session["User"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (competition.StartDate > competition.EndDate)
                    {
                        Response.StatusCode = 201;
                        ModelState.AddModelError("", "End date must be greater than start date !");
                        return PartialView("CreateCompetitionForm", competition);
                    }

                    if (!DAO.InsertCompetition(competition))
                    {
                        Response.StatusCode = 201;
                        ModelState.AddModelError("", "Error. Server cannot insert competition now !");
                        return PartialView("CreateCompetitionForm", competition);
                    }
                    return new HttpStatusCodeResult(200);
                }
                Response.StatusCode = 201;
                return PartialView("CreateCompetitionForm", DAO.GetCompetitionByID(competition.ID));
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Get /Admin/EditCompetition
         -----------------------------------*/
        public ActionResult EditCompetition(int ID)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetCompetitionByID(ID));
            }
            return RedirectToAction("Login");

        }


        /*----------------------------------
        Post /Admin/EditCompetition
         -----------------------------------*/
        [HttpPost]
        public ActionResult EditCompetition(Competition competition)
        {
            if (Session["User"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (competition.StartDate < competition.EndDate)
                    {
                        if (DAO.EditCompetition(competition))
                        {
                            return new HttpStatusCodeResult(200);
                        }

                        Response.StatusCode = 201;
                        ModelState.AddModelError("", "Error. Server cannot edit competition now !");
                    }
                    else
                    {
                        Response.StatusCode = 201;
                        ModelState.AddModelError("", "End date must be greater than start date !");
                    }
                }
                else
                {
                    Response.StatusCode = 201;
                }

                return PartialView("EditCompetitionForm", competition);
            }
            return RedirectToAction("Login");

        }

        /*----------------------------------
        Get /Admin/DeleteCompetition
         -----------------------------------*/
        public ActionResult DeleteCompetiton(int ID)
        {
            if (Session["User"] != null)
            {
                DAO.DeleteCompetition(ID);
                return RedirectToAction("AllCompetitions");
            }
            return RedirectToAction("Login");
        }

        /*----------------------------------
        Get /Admin/Posts
         -----------------------------------*/
        public ActionResult Posts(int ID)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetPostsByCompetitionID(ID));
            }
            return RedirectToAction("Login");
        }

        /*----------------------------------
        Get /Admin/Post
         -----------------------------------*/
        public ActionResult Post(int ID)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                DAO.SetPostIsSeen(ID);
                return View(DAO.GetPostByID(ID));
            }
            return RedirectToAction("Login");
        }

        /*----------------------------------
        Get /Admin/Award
         -----------------------------------*/
        public ActionResult Award(int ID)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetCompetitionByID(ID));
            }
            return RedirectToAction("Login");
        }

        /*----------------------------------
        Post /Admin/UpdateScore
         -----------------------------------*/
        [HttpPost]
        public ActionResult UpdateScore(int postID, int score)
        {
            if (Session["User"] != null)
            {
                if (DAO.UpdateScore(postID, score))
                {
                    return new HttpStatusCodeResult(200);
                }
                return new HttpStatusCodeResult(201);
            }
            return RedirectToAction("Login");
        }

        /*----------------------------------
        Feedbacks Get Action
         -----------------------------------*/
        public ActionResult Feedbacks(int ID)
        {
            if (Session["User"] != null)
            {
                ViewBag.InActiveUsers = DAO.GetInActiveUsers();
                return View(DAO.GetFeedbackBySurveyID(ID));
            }
            return RedirectToAction("Login");
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
            if (Session["User"] != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var physicPath = Server.MapPath("~/Images/" + fileName);
                file.SaveAs(physicPath);
                return "/Images/" + fileName;
            }
            return "Not Authorized";

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
            if (Session["User"] != null)
            {
                if (DAO.DeleteAnswer(answerID))
                {
                    return "OK";
                }
                return "Error";
            }
            return "Not Authorized";

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
            if (Session["User"] != null)
            {
                if (DAO.DeleteQuestion(questionID))
                {
                    return "OK";
                }
                return "Error";
            }
            return "Not Authorized";

        }
    }
}