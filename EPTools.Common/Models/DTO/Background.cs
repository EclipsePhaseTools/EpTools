﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPTools.Common.Models.DTO
{
    public class Background
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<InterestSkill> skills { get; set; }
        public string resource { get; set; }
        public string reference { get; set; }
        public string id { get; set; }
    }
}
