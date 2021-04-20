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

        public override Task<SpringZodiacSignReply> GetSpringZodiacSign(SpringZodiacSignRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SpringZodiacSignReply() { ZodiacSign = Helper.GetZodiac(request.Birthday, signs) });
        }
    }
}
