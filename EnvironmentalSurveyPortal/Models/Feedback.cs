using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentalSurveyPortal.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int SurveyID { get; set; }

        [Required]
        [StringLength(10)]
        public string UserID { get; set; }

        [AllowHtml]
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;
    }
}