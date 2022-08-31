#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EPTools.Common.Models.Ego
{
    public class Ego
    {
        //General Information
        public string Name { get; set; }
        public string EgoSex { get; set; }
        public string EgoGender { get; set; }
        public string Background { get; set; }
        public string Career { get; set; }
        public string Interest { get; set; }
        public string Faction { get; set; }
        public string Languages { get; set; }
        public List<string> Motivations { get; set; }

        //Aptitudes
        public int Cognition { get; set; }
        public int CognitionCheckMod { get; set; }
        public int Intuition { get; set; }
        public int IntuitionCheckMod { get; set; }
        public int Reflex { get; set; }
        public int ReflexCheckMod { get; set; }
        public int Savvy { get; set; }
        public int SavvyCheckMod { get; set; }
        public int Somatics { get; set; }
        public int SomaticsCheckMod { get; set; }
        public int Willpower { get; set; }
        public int WillpowerCheckMod { get; set; }
        public int EgoFlex { get; set; }

        //Identity
        public List<Identity> Identities { get; set; }

        //Ego Traits
        public List<Trait> EgoTraits { get; set; }

        //Skills
        public List<EgoSkill> Skills { get; set; }

        //PSI
        public string Substrain { get; set; }
        public int InfectionRating { get; set; }
        public List<string> InfectionEvents { get; set; }
        public List<Slight> Slights { get; set; }

        //Morph
        public List<Morph> Morphs { get; set; }

        //inventory
        public List<Gear> Inventory { get; set; }

        //GearCaches
        public List<GearCache> Caches { get; set; }
    }
}
