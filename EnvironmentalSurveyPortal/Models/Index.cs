using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class Index
    {
        public IEnumerable<Survey> surveys;
        public IEnumerable<Prize> prizes;
    }
}