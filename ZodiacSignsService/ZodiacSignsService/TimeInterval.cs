using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacSignsService
{
    public class TimeInterval
    {
        public string startDay { get; set; }
        public string startMonth { get; set; }
        public string endDay { get; set; }
        public string endMonth { get; set; }

        public DateTime GetStartTime(string year)
        {
            DateTime date = DateTime.ParseExact($"{startMonth}/{startDay}/{year}", "M/d/yyyy", CultureInfo.InvariantCulture);
            return date;
        }
        public DateTime GetEndTime(string year)
        {
            DateTime date = DateTime.ParseExact($"{endMonth}/{endDay}/{year}", "M/d/yyyy", CultureInfo.InvariantCulture);
            return date;
        }
    }
}
