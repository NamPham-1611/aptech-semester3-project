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

        public static User GetUser(string id)
        {
            return db.tbUser.FirstOrDefault(item => item.UserID == id);
        }

        public static IEnumerable<Survey> GetAllSurvey()
        {
            return db.tbSurvey;
        }

        public static bool Delete(string id)
        {
            var u = db.tbUser.FirstOrDefault(item => item.UserID == id);
            if (u != null)
            {
                db.tbUser.Remove(u);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool EditProfile(User eUser)
        {
            var u = db.tbUser.FirstOrDefault(item => item.UserID == eUser.UserID);
            if (u != null)
            {
                u.Name = eUser.Name;
                u.Password = eUser.Password;
                u.Role = eUser.Role;
                u.Section = eUser.Section;
                u.Specification = eUser.Specification;
                db.SaveChanges();
                return true;
            }
            return false;
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