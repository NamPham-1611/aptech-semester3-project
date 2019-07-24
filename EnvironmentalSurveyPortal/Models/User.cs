using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class User
    {
        [Key]
        [StringLength(10)]
        public string UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Class { get; set; }

        [StringLength(20)]
        public string Specification { get; set; }

        [StringLength(20)]
        public string Section { get; set; }

        [Required]
        [StringLength(10)]
        public string Role { get; set; }
    }
}