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

        public static User CheckLoginState(HttpRequest req)
        {
            string uid = req.Cookies["UID"].Value;
            return DAO.GetUserByID(uid);
        }
    }
}