using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class DAO
    {
        private static SurveyDB db = new SurveyDB();
        public static Index getIndex()
        {
            var indexModel = new Index { surveys = GetAllSurvey(), prizes = GetAllPrize() };
            return indexModel;
        }

        // User DAO

        // Get all users
        public static IEnumerable<User> GetAllUser()
        {
            return db.tbUser;
        }

        // Get all users
        public static IEnumerable<Survey> SearchSurvey(string txt)
        {
            txt = txt.ToLower();
            return db.tbSurvey.Where(item => item.Name.ToLower().Contains(txt) || item.Content.ToLower().Contains(txt));
        }

        //Get user by user id
        public static User GetUserByID(string ID)
        {
            return db.tbUser.Where(x => x.UserID == ID).FirstOrDefault();
        }

        //Get user by login information
        public static User GetLoginUser(string ID, string Password)
        {
            return db.tbUser.Where(x => x.UserID == ID && x.Password == Password).FirstOrDefault();
        }

        //Insert user
        public static void InsertUser(User u)
        {
            db.tbUser.Add(u);
            db.SaveChanges();
        }

        //Delete user
        public static void DeleteUser(string ID)
        {
            db.tbUser.Remove(GetUserByID(ID));
            db.SaveChanges();
        }

        //Check activation status
        public bool CheckActivation(string ID)
        {
            var t = GetUserByID(ID);
            if (t != null && t.Active == true)
            {
                return true;
            }
            return false;
        }


        // Survey DAO

        //Get survey by survey id
        public static Survey GetSurveyByID(int ID)
        {
            return db.tbSurvey.Where(x => x.ID == ID).FirstOrDefault();
        }
        //public static IEnumerable<Survey> GetPopularSurvey()
        //{
        //    var surveyNum = db.tbSurvey.Count();
        //    List<Survey> topPopular = new List<Survey>();
        //    db.tbSurvey.Find()
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < surveyNum; j++)
        //        {

        //        }
        //        if (db.tbSurvey.par > db.tbSurvey[i + 1])
        //        {

        //        }

        //        if (topPopular.Count() == 4)
        //        {
        //            return topPopular;
        //        }
        //    }
        //    return topPopular;
        //}

        //Get all surveys
        public static IEnumerable<Survey> GetAllSurvey()
        {
            return db.tbSurvey;
        }

        // Insert new survey
        public static bool InsertSurvey(Survey survey)
        {
            db.tbSurvey.Add(survey);
            db.SaveChanges();
            return true;
        }

        // Update survey
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

        // Delete survey by ID
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
        // Prized participants
        public static IEnumerable<Prize> GetAllPrize()
        {
            return db.tbPrize;
        }

        // Feed back DAO
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

        public static IDictionary<int, int> CountFeedback()
        {
            return db.tbFeedback
                   .GroupBy(f => f.SurveyID)
                   .Select(g => new { sid = g.Key, count = g.Count() })
                   .ToDictionary(k => k.sid, i => i.count);
        }
    }
}