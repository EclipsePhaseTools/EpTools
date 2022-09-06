using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPTools.Common.Models.DTO
{
    public class WeaponMelee : Gear
    {
        public string waretype { get; set; }
        public string damage { get; set; }
        public string damage_avg { get; set; }
        public string notes { get; set; }
    }
}
