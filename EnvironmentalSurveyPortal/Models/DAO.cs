using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class DAO
    {
        private static SurveyDB db = new SurveyDB();

        public static IEnumerable<User> GetAllUser()
        {
            return db.tbUser;
        }

        public static IEnumerable<Survey> GetAllSurvey()
        {
            return db.tbSurvey;
        }

        public static bool InsertSurvey(Survey survey)
        {
            db.tbSurvey.Add(survey);
            db.SaveChanges();
            return true;
        }

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