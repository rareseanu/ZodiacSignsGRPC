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

        static private string GetZodiac()
        {
            using (StreamReader r = new StreamReader(@"Resources\primavara.json"))
            {
                string json = r.ReadToEnd();
                var jsonobject = JsonConvert.DeserializeObject<List<Sign>>(json);
                return jsonobject[0].Name;
            }
        }

        public override Task<SpringZodiacSignReply> GetSpringZodiacSign(SpringZodiacSignRequest request, ServerCallContext context)
        {
            string test = GetZodiac();
            return Task.FromResult(new SpringZodiacSignReply() { ZodiacSign=GetZodiac() });
        }
    }
}
