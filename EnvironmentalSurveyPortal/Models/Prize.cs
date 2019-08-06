using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class Prize
    {
        [Key]
        public int ID { get; set; }

        public virtual User User { get; set; }

        public virtual Competition Competition { get; set; }
    }
}