﻿using System;
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

        public DateTime Time { get; set; } = DateTime.Now;

        public bool Seen { get; set; } = false;

        [ForeignKey("Survey")]
        public int SurveyID { get; set; }
        public virtual Survey Survey { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<FeedbackAnswer> Answers { get; set; }
    }
}