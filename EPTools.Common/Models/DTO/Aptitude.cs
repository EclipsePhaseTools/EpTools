using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EPTools.Common.Models.DTO
{
    public class Aptitude
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public string description { get; set; }
        public string short_name { get; set; }
        public string resource { get; set; }
        public string reference { get; set; }
        public string id { get; set; }
    }
}
