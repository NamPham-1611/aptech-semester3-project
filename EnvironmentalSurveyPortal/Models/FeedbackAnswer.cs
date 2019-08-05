using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class FeedbackAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public virtual Feedback Feedback { get; set; }

        public virtual SurveyQuestion Question { get; set; }

        [ForeignKey("Answer")]
        public int AnswerID { get; set; }
        public virtual SurveyAnswer Answer { get; set; }
    }
}