using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnvironmentalSurveyPortal.Models;
namespace EnvironmentalSurveyPortal.Controllers
{
    public class HomeController : Controller
    {

        /*----------------------------------
        Get /Home
         -----------------------------------*/
        public ActionResult Index(int? id)
        {
            int currentPage = id != null ? int.Parse(id.ToString()) : 1;
            ViewBag.User = Auth.CheckLoginState(Request);
            ViewBag.Prizes = DAO.GetAllPrize().ToList();
            ViewBag.Popular = DAO.GetPopularSurveys(5);
            ViewBag.Competitions = DAO.GetLatestCompetitions(4);
            return View(DAO.GetPaginationData(currentPage));
        }

        /*----------------------------------
        Get /Home/SurveyBoard
         -----------------------------------*/
        public ActionResult SurveyBoard(int? id)
        {
            int currentPage = id != null ? int.Parse(id.ToString()) : 1;
            ViewBag.User = Auth.CheckLoginState(Request);
            ViewBag.Prizes = DAO.GetAllPrize();
            ViewBag.Popular = DAO.GetPopularSurveys(5);
            return View(DAO.GetPaginationData(currentPage));
        }

        /*----------------------------------
        Get /Home/Survey
         -----------------------------------*/
        public ActionResult Survey(int id)
        {
            ViewBag.User = Auth.CheckLoginState(Request);
            ViewBag.Prizes = DAO.GetAllPrize();
            ViewBag.Popular = DAO.GetPopularSurveys(5);
            return View(DAO.GetSurveyByID(id));
        }

        /*----------------------------------
        Get /Home/Competitions
         -----------------------------------*/
        public ActionResult Competitions()
        {
            ViewBag.User = Auth.CheckLoginState(Request);
            ViewBag.Prizes = DAO.GetAllPrize();
            ViewBag.Popular = DAO.GetPopularSurveys(5);
            return View(DAO.GetAllCompetition());
        }

        /*----------------------------------
        Get /Home/Competition
         -----------------------------------*/
        public ActionResult Competition(int id)
        {
            ViewBag.User = Auth.CheckLoginState(Request);
            ViewBag.Prizes = DAO.GetAllPrize();
            ViewBag.Popular = DAO.GetPopularSurveys(5);
            return View(DAO.GetCompetitionByID(id));
        }

        /*----------------------------------
        Get /Home/Post
         -----------------------------------*/
        public ActionResult Post(Post post)
        {
            if (DAO.InsertPost(post))
            {
                return new HttpStatusCodeResult(200);
            }
            return new HttpStatusCodeResult(201);
        }

        /*----------------------------------
        Post /Home/Feedback
         -----------------------------------*/
        [HttpPost]
        public HttpStatusCodeResult Feedback(Feedback feedback)
        {
            if (DAO.InsertFeedback(feedback))
            {
                return new HttpStatusCodeResult(200);
            }
            return new HttpStatusCodeResult(201);
        }

        /*----------------------------------
        Post /Home/CheckLogin
         -----------------------------------*/
        [HttpPost]
        public PartialViewResult CheckLogin(LoginAccount l)
        {
            if (ModelState.IsValid)
            {
                var u = Auth.CheckAccount(l);
                if (u != null)
                {
                    if (u.isActive)
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
                }
                else
                {
                    Response.StatusCode = 201;
                    ModelState.AddModelError("", "Account or password incorrect !");
                }
                
                return PartialView("LoginForm");
            }
            Response.StatusCode = 201;
            return PartialView("LoginForm");
        }

        /*----------------------------------
        Post /Home/CheckRegister
         -----------------------------------*/
        [HttpPost]
        public ActionResult CheckRegister(RegisterAccount acc)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UID = acc.UID, Name = acc.Name, Password = acc.Password, Class = acc.Class, Specification = acc.Specification, Role = acc.Role, Section = acc.Section };

                if (!DAO.InsertUser(user))
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
        Get /Home/Logout
         -----------------------------------*/
        public ActionResult Logout()
        {
            HttpCookie authCookie = new HttpCookie("UID", "");
            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Index");
        }

        /*----------------------------------
        Get /Home/Search
         -----------------------------------*/
        public ActionResult Search(string q)
        {
            ViewBag.TXT = q;
            ViewBag.Prizes = DAO.GetAllPrize();
            ViewBag.Popular = DAO.GetPopularSurveys(5);
            return View(DAO.SearchSurvey(q));
        }

        /*----------------------------------
        Get /Home/Support
         -----------------------------------*/
        public ActionResult Support()
        {
            return View(DAO.GetSupportInfo());
        }

        /*----------------------------------
        Get /Home/Support
        -----------------------------------*/
        public ActionResult FAQ()
        {
            return View(DAO.GetAllFAQ());
        }

        /*----------------------------------
        Get /Home/Edit Profile
         -----------------------------------*/
        public ActionResult EditUser(string id)
        {
            ViewBag.InActiveUsers = DAO.GetInActiveUsers();
            return View(DAO.GetUserByUID(id));
        }

        [HttpPost]
        public ActionResult EditUser(User eUser)
        {

            DAO.UpdateUser(eUser);
            return RedirectToAction("Index");
        }

    }
}