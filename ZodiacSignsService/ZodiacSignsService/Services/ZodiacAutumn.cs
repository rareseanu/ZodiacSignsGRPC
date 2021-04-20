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
    public class ZodiacAutumn : AutumnZodiacSign.AutumnZodiacSignBase
    {
        private List<Sign> signs { get; set; }
        public ZodiacAutumn()
        {
            using (StreamReader r = new StreamReader(@"Resources\toamna.json"))
            {
                string json = r.ReadToEnd();
                signs = JsonConvert.DeserializeObject<List<Sign>>(json);
            }
        }

        public override Task<AutumnZodiacSignReply> GetAutumnZodiacSign(AutumnZodiacSignRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AutumnZodiacSignReply() { ZodiacSign = Helper.GetZodiac(request.Birthday, signs) });
        }
    }
}
