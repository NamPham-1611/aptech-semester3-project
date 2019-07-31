using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = "Roll No/Employee Number required")]
        [StringLength(10, ErrorMessage = "User ID can not longer than 10 characters")]
        [Display(Name = "Roll No or Employee Number")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Name required")]
        [StringLength(10, ErrorMessage = "User name can not longer than 10 characters")]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password required")]
        [StringLength(30, ErrorMessage = "Password can not longer than 10 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Retype password required")]
        [StringLength(30, ErrorMessage = "Password can not longer than 10 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Retype Password")]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Class required")]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Specification required")]
        [Display(Name = "Specification")]
        public string Specification { get; set; }

        [Required(ErrorMessage = "Section required")]
        [Display(Name = "Section")]
        public string Section { get; set; }
    }
}