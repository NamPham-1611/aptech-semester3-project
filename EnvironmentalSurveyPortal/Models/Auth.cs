using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class Auth
    {
        public static User CheckAccount(LoginAccount l)
        {
            return DAO.GetLoginUser(l.UID, l.Password);
        }

        public static User CheckLoginState(HttpRequestBase req)
        {
            string uid = "";
            try
            {
                uid = req.Cookies.Get("UID").Value;
            }
            catch (Exception) { }

            return DAO.GetUserByUID(uid);
        }

        
    }
}