using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class Pagination
    {
        public int TotalItem { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public IEnumerable<Survey> Surveys { get; set; }
    }
}