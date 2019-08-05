using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class SurveyQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Content { get; set; }

        [ForeignKey("Survey")]
        public int SurveyID { get; set; }
        public virtual Survey Survey { get; set; }

        public virtual ICollection<SurveyAnswer> Answers { get; set; }
    }
}