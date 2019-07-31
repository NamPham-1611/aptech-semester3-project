using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class LoginAccount
    {
        [Required(ErrorMessage = "User name required")]
        [StringLength(10, ErrorMessage = "User name can not longer than 10 characters")]
        [Display(Name = "User ID")]
        public string UID { get; set; }

        [Required(ErrorMessage = "Password required")]
        [StringLength(30, ErrorMessage = "Password can not longer than 30 characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}