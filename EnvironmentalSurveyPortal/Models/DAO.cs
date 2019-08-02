using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class DAO
    {
        private static SurveyDB db = new SurveyDB();
        private static int limitItem = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LimitItem"]);
        private static int limitAlert = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LimitAlert"]);

        /*----------------------------------
        Get All User Method
         -----------------------------------*/
        public static IEnumerable<User> GetAllUser()
        {
            return db.tbUser;
        }

        /*----------------------------------
        Get All Survey Method
         -----------------------------------*/
        public static IEnumerable<Survey> SearchSurvey(string txt)
        {
            txt = txt.ToLower();
            return db.tbSurvey.Where(item => item.Name.ToLower().Contains(txt) || item.Content.ToLower().Contains(txt));
        }

        /*----------------------------------
        Get User By UID Method
         -----------------------------------*/
        public static User GetUserByUID(string UID)
        {
            return db.tbUser.FirstOrDefault(item => item.UID == UID);
        }

        /*----------------------------------
        Get User Request Login Method
         -----------------------------------*/
        public static User GetLoginUser(string ID, string Password)
        {
            return db.tbUser.Where(x => x.UID == ID && x.Password == Password).FirstOrDefault();
        }

        /*----------------------------------
        Insert User Method
         -----------------------------------*/
        public static bool InsertUser(User u)
        {
            var x = db.tbUser.FirstOrDefault(item => item.UID == u.UID);
            if (x == null)
            {
                db.tbUser.Add(u);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /*----------------------------------
        Active User Method
         -----------------------------------*/
        public static bool SetActiveUser(string uid)
        {
            var x = db.tbUser.FirstOrDefault(item => item.UID == uid);
            if (x != null)
            {
                x.isActive = true;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /*----------------------------------
        Get User InActive Method
         -----------------------------------*/
        public static IEnumerable<User> GetInActiveUsers()
        {
            return db.tbUser.Where(item => item.isActive == false).Take(limitAlert).ToList();
        }

        /*----------------------------------
        Update User Method
        -----------------------------------*/
        public static bool UpdateUser(User user)
        {
            var u = db.tbUser.FirstOrDefault(item => item.UID == user.UID);
            if (u != null)
            {
                u.Name = user.Name;
                u.Password = user.Password;
                u.Role = user.Role;
                u.Section = user.Section;
                u.Specification = user.Specification;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /*----------------------------------
        Delete User Method
         -----------------------------------*/
        public static bool DeleteUser(string uid)
        {
            var x = GetUserByUID(uid);
            if (x != null)
            {
                db.tbUser.Remove(x);
                db.SaveChanges();
            }
            return false;
        }


        /*----------------------------------
        Get Survey By ID Method
         -----------------------------------*/
        public static Survey GetSurveyByID(int ID)
        {
            return db.tbSurvey.Where(x => x.ID == ID).FirstOrDefault();
        }

        /*----------------------------------
        Get Pagination Data Method
         -----------------------------------*/
        public static Pagination GetPaginationData(int pageNumber)
        {
            int skip = limitItem * (pageNumber - 1);
            var count = db.tbSurvey.Count();
            var surveys = db.tbSurvey.OrderByDescending(item => item.CreateDate).Skip(skip).Take(limitItem);

            decimal numPage = (decimal) count / limitItem;
            int totalPage = (int)Math.Ceiling(numPage);

            return new Pagination { CurrentPage = pageNumber, TotalItem = count,TotalPage = totalPage, Surveys = surveys };
        }

        /*----------------------------------
        Get Popular Surveys Method
         -----------------------------------*/
        public static IEnumerable<Survey> GetPopularSurveys(int quantity)
        {
            return db.tbSurvey.Where(item => item.Feedbacks.Count > 0).OrderByDescending(item => item.Feedbacks.Count).Take(quantity); ;
        }

        /*----------------------------------
        Get All Surveys Method
         -----------------------------------*/
        public static IEnumerable<Survey> GetAllSurvey()
        {
            return db.tbSurvey;
        }

        /*----------------------------------
        Insert Surveys Method
         -----------------------------------*/
        public static bool InsertSurvey(Survey survey)
        {
            db.tbSurvey.Add(survey);
            db.SaveChanges();
            return true;
        }

        /*----------------------------------
        Update Surveys Method
         -----------------------------------*/
        public static bool UpdateSurvey(Survey survey)
        {
            var t = GetSurveyByID(survey.ID);

            if (t != null)
            {
                t.Name = survey.Name;
                t.Content = survey.Content;
                t.For = survey.For;
                t.StartDate = survey.StartDate;
                t.EndDate = survey.EndDate;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /*----------------------------------
        Delete The Survey Method
         -----------------------------------*/
        public static bool DeleteSurvey(int ID)
        {
            try
            {
                var t = GetSurveyByID(ID);
                db.tbSurvey.Remove(t);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /*----------------------------------
        Get All Prize Method
         -----------------------------------*/
        public static IEnumerable<Prize> GetAllPrize()
        {
            return db.tbPrize;
        }

        /*----------------------------------
        Insert Feedback Method
         -----------------------------------*/
        public static bool InsertFeedback(Feedback feedback)
        {
            db.tbFeedback.Add(feedback);
            db.SaveChanges();
            return true;
        }

        public static IEnumerable<Feedback> GetAllFeedback()
        {
            return db.tbFeedback;
        }

        /*----------------------------------
        Get Support Infomation Method
         -----------------------------------*/
        public static Support GetSupportInfo()
        {
            return db.tbSupport.FirstOrDefault();
        }

        /*----------------------------------
        Edit Support Infomation Method
         -----------------------------------*/
        public static bool EditSupportInfo(Support e)
        {
            var u = db.tbSupport.FirstOrDefault();
            if (u != null)
            {
                u.Address = e.Address;
                u.Email = e.Email;
                u.Phone = e.Phone;
                u.Website = e.Website;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /*----------------------------------
        Counter For Dashboard Method
         -----------------------------------*/
        public static IDictionary<string, int> CounterForDashboard()
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            counter.Add("survey", db.tbSurvey.Count());
            counter.Add("feedback", db.tbFeedback.Count());
            counter.Add("user", db.tbUser.Count());

            return counter;
        }
    }
}