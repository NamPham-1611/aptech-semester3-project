using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        public string UserUID { get; set; }
        public User User { get; set; }

        public int CompetitionID { get; set; }
        public Competition Competition { get; set; }
    }
}