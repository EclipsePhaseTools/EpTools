#pragma warning disable CS8618
using EPTools.Common.Models.DTO;
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
        [JsonPropertyOrder(0)]
        public string Name { get; set; }
        [JsonPropertyOrder(1)]
        public string EgoSex { get; set; }
        [JsonPropertyOrder(2)]
        public string EgoGender { get; set; }
        [JsonPropertyOrder(4)]
        public int EgoAge { get; set; }
        [JsonPropertyOrder(5)]
        public string Background { get; set; }
        [JsonPropertyOrder(6)]
        public string Career { get; set; }
        [JsonPropertyOrder(7)]
        public string Interest { get; set; }
        [JsonPropertyOrder(8)]
        public string Faction { get; set; }
        [JsonPropertyOrder(9)]
        public string Languages { get; set; }
        [JsonPropertyOrder(10)]
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
        public List<Identity> Identities { get; set; } = new List<Identity>();

        //Ego Traits
        public List<Trait> EgoTraits { get; set; } = new List<Trait>();

        //Skills
        public List<EgoSkill> Skills { get; set; } = new List<EgoSkill>();

        //PSI
        public string Substrain { get; set; }
        public int InfectionRating { get; set; }
        public List<string> InfectionEvents { get; set; } = new List<string>();
        public List<Slight> Slights { get; set; } = new List<Slight>();

        //Morph
        public List<Morph> Morphs { get; set; } = new List<Morph>();

        //inventory
        public List<Gear> Inventory { get; set; } = new List<Gear>();

        //GearCaches
        public List<GearCache> Caches { get; set; } = new List<GearCache>();

        //lifepath Tracking Variables
        [JsonIgnore]
        public List<int> SkipSections { get; set; } = new();
        [JsonIgnore]
        public Stack<CharacterGenerationNode> CharacterGenerationNodes { get; set; } = new Stack<CharacterGenerationNode>();
    }
}
