using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class Auth
    {
        public static User Login(string uid, string pwd)
        {
            return DAO.GetLoginUser(uid, pwd);
        }
    }
}