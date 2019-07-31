using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnvironmentalSurveyPortal.Models
{
    public class Support
    {
        [Key]
        public int SupportID { get; set; }

        [StringLength(100)]
        [Required]
        public string Address { get; set; }

        [StringLength(70)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength =10)]
        public string Phone { get; set; }

        [StringLength(100)]
        [Required]
        public string Website { get; set; }
    }
}