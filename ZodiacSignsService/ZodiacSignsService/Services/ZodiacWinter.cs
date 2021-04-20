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
    public class ZodiacWinter : WintergZodiacSign.WintergZodiacSignBase
    {
        private List<Sign> signs { get; set; }
        public ZodiacWinter()
        {
            using (StreamReader r = new StreamReader(@"Resources\iarna.json"))
            {
                string json = r.ReadToEnd();
                signs = JsonConvert.DeserializeObject<List<Sign>>(json);
            }
        }

        public override Task<WinterZodiacSignReply> GetWinterZodiacSign(WinterZodiacSignRequest request, ServerCallContext context)
        {
            return Task.FromResult(new WinterZodiacSignReply() { ZodiacSign = Helper.GetZodiac(request.Birthday, signs) });
        }
    }
}
