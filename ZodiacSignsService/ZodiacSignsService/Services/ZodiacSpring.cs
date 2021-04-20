using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ZodiacSignsService
{
    public class ZodiacSpring : SpringZodiacSign.SpringZodiacSignBase
    {
        private List<Sign> signs { get; set; }
        public ZodiacSpring()
        {
            using (StreamReader r = new StreamReader(@"Resources\primavara.json"))
            {
                string json = r.ReadToEnd();
                signs = JsonConvert.DeserializeObject<List<Sign>>(json);
            }
        }

        private string GetZodiac(string birthday)
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

        public override Task<SpringZodiacSignReply> GetSpringZodiacSign(SpringZodiacSignRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SpringZodiacSignReply() { ZodiacSign = GetZodiac(request.Birthday) });
        }
    }
}
