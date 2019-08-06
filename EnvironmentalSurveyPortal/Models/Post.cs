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

        public int Score { get; set; }

        public bool Seen { get; set; } = false;

        public string UserUID { get; set; }
        public virtual User User { get; set; }

        public int CompetitionID { get; set; }
        public virtual Competition Competition { get; set; }
    }
}