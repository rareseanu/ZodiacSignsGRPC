using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacSignsService
{
    public class Sign
    {
        public string Name { get; set; }
        [JsonProperty]
        public TimeInterval Interval { get; }

    }
    public class RootObject
    {
        public List<Sign> signs { get; set; }
    }
}
