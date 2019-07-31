using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class DAO
    {
        private static SurveyDB db = new SurveyDB();

        /*----------------------------------
        Get Data For Index Page Method
         -----------------------------------*/
        public static Index GetDataForIndex()
        {
            var indexModel = new Index { surveys = GetAllSurvey(), prizes = GetAllPrize() };
            return indexModel;
        }

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
        Delete User Method
         -----------------------------------*/
        public static void DeleteUser(string ID)
        {
            db.tbUser.Remove(GetUserByUID(ID));
            db.SaveChanges();
        }


        /*----------------------------------
        Get Survey By ID Method
         -----------------------------------*/
        public static Survey GetSurveyByID(int ID)
        {
            return db.tbSurvey.Where(x => x.ID == ID).FirstOrDefault();
        }

        /*----------------------------------
        Get Popular Surveys Method
         -----------------------------------*/
        //public static IEnumerable<Survey> GetPopularSurvey()
        //{
            
        //}

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
                t.Participants = survey.Participants;
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
        Count Feedback of Surveys Method
         -----------------------------------*/
        public static IDictionary<int, int> CountFeedback()
        {
            return db.tbFeedback
                   .GroupBy(f => f.SurveyID)
                   .Select(g => new { sid = g.Key, count = g.Count() })
                   .ToDictionary(k => k.sid, i => i.count);
        }

    }
}