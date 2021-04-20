using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacSignsService
{
    public class ZodiacGateService : ZodiacSign.ZodiacSignBase
    {
        private readonly ILogger<ZodiacGateService> _logger;
        public ZodiacGateService(ILogger<ZodiacGateService> logger)
        {
            _logger = logger;
        }

        private ZodiacSpring springZodiac = new ZodiacSpring();
        private ZodiacAutumn autumnZodiac = new ZodiacAutumn();
        private ZodiacWinter winterZodiac = new ZodiacWinter();

        private string ProcessBirthday(string birthday, ServerCallContext context)
        {
            DateTime date;
            if(DateTime.TryParseExact(birthday, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                if(date.Month >= 3 & date.Month <= 5) // spring
                {
                    var reply = springZodiac.GetSpringZodiacSign(new SpringZodiacSignRequest { Birthday = birthday }, context);
                    var res = reply.Result.ZodiacSign;
                    Console.WriteLine(res);
                    return res;
                } else if(date.Month >= 6 && date.Month <= 8) // summer
                {
                    return null;
                }
                else if(date.Month >= 9 && date.Month <= 11) // autumn
                {
                    var reply = autumnZodiac.GetAutumnZodiacSign(new AutumnZodiacSignRequest { Birthday = birthday }, context);
                    var res = reply.Result.ZodiacSign;
                    Console.WriteLine(res);
                    return res;
                }
                else // winter
                {
                    var reply = winterZodiac.GetWinterZodiacSign(new WinterZodiacSignRequest { Birthday = birthday }, context);
                    var res = reply.Result.ZodiacSign;
                    Console.WriteLine(res);
                    return res;
                }
            }
            return "[ERROR] Invalid date.";
        }

        public override Task<ZodiacSignReply> GetZodiacSign(ZodiacSignRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ZodiacSignReply() { ZodiacSign = ProcessBirthday(request.Birthday, context)});
        }
    }
}
