using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TopTal.PageObjects.TestDataModels
{
    public class DetailsPageData
    {
        public string DesiredCommitment { get; set; }
        public string TimeZone { get; set; }
        public string HoursOfOverlap { get; set; }
        public string DesiredStartDate { get; set; }
        public string EstimatedLength { get; set; }
        public List<string> SpokenLanguages { get; set; }
    }
}
