using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class SurveyAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public string Content { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual SurveyQuestion Question { get; set; }

    }
}