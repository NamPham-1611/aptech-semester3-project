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
        public int ID { get; set; }
        public virtual User User { get; set; }
        public virtual Survey Survey { get; set; }
    }
}