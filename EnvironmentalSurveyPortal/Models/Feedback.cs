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

        public virtual Survey Survey { get; set; }
        public virtual User User { get; set; }

        [AllowHtml]
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;
    }
}