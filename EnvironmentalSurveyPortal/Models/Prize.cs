using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class Prize
    {
        [Key]
        public int PrizeID { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }
        public int SurveyID { get; set; }
        public string StudentName { get; set; }
        public string SurveyName { get; set; }
    }
}