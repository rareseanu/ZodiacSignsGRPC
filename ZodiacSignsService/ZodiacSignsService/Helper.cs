using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacSignsService
{
    public class Helper
    {
        public static string GetZodiac(string birthday, List<Sign> signs)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime date = DateTime.ParseExact(birthday, "M/d/yyyy", provider);

            foreach (Sign s in signs)
            {
                DateTime start = s.Interval.GetStartTime(date.Year.ToString());
                DateTime end = s.Interval.GetEndTime(date.Year.ToString());
                if (date >= start && date <= end)
                {
                    return s.Name;
                }
            }

            return null;
        }
    }
}
