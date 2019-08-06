using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentalSurveyPortal.Models
{
    public class Competition
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(3000)]
        public string Content { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual ICollection<Prize> Prizes { get; set; }
    }
}