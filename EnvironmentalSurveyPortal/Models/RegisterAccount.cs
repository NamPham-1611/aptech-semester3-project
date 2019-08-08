using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class RegisterAccount
    {
        [Key]
        [Required(ErrorMessage = "Roll No/Employee Number required")]
        [StringLength(10, ErrorMessage = "User SurveyID can not longer than 10 characters")]
        [Display(Name = "Roll No or Employee Number")]
        public string UID { get; set; }

        [Required(ErrorMessage = "Name required")]
        [StringLength(30, ErrorMessage = "User name can not longer than 30 characters")]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password required")]
        [StringLength(30, ErrorMessage = "Password can not longer than 30 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Retype password required")]
        [StringLength(30, ErrorMessage = "Password can not longer than 30 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Retype Password")]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Display(Name = "Class")]
        [StringLength(20)]
        public string Class { get; set; }

        [Display(Name = "Specification")]
        [StringLength(20)]
        public string Specification { get; set; }

        [Display(Name = "Section")]
        [StringLength(20)]
        public string Section { get; set; }

        [StringLength(15)]
        public string Role { get; set; }

        [ScaffoldColumn(true)]
        public bool isActive { get; set; }
    }
}