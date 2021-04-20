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
    public class ZodiacSummer : SummerZodiacSign.SummerZodiacSignBase
    {
        private List<Sign> signs { get; set; }
        public ZodiacSummer()
        {
            using (StreamReader r = new StreamReader(@"Resources\vara.json"))
            {
                string json = r.ReadToEnd();
                signs = JsonConvert.DeserializeObject<List<Sign>>(json);
            }
        }

        public override Task<SummerZodiacSignReply> GetSummerZodiacSign(SummerZodiacSignRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SummerZodiacSignReply() { ZodiacSign = Helper.GetZodiac(request.Birthday, signs) });
        }
    }
}
