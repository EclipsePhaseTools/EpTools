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
        public List<string> Motivations { get; set; } = new();

        //Aptitudes
        [JsonPropertyOrder(11)]
        public int Cognition { get; set; }
        [JsonPropertyOrder(12)]
        public int CognitionCheckMod { get; set; }
        [JsonPropertyOrder(13)]
        public int Intuition { get; set; }
        [JsonPropertyOrder(14)]
        public int IntuitionCheckMod { get; set; }
        [JsonPropertyOrder(15)]
        public int Reflex { get; set; }
        [JsonPropertyOrder(16)]
        public int ReflexCheckMod { get; set; }
        [JsonPropertyOrder(17)]
        public int Savvy { get; set; }
        [JsonPropertyOrder(18)]
        public int SavvyCheckMod { get; set; }
        [JsonPropertyOrder(19)]
        public int Somatics { get; set; }
        [JsonPropertyOrder(20)]
        public int SomaticsCheckMod { get; set; }
        [JsonPropertyOrder(21)]
        public int Willpower { get; set; }
        [JsonPropertyOrder(22)]
        public int WillpowerCheckMod { get; set; }
        [JsonPropertyOrder(23)]
        public int EgoFlex { get; set; }

        //Identity
        [JsonPropertyOrder(24)]
        public List<Identity> Identities { get; set; } = new();

        //Ego Traits
        [JsonPropertyOrder(25)]
        public List<Trait> EgoTraits { get; set; } = new();

        //Skills
        [JsonPropertyOrder(26)]
        public List<EgoSkill> Skills { get; set; } = new();

        //PSI
        [JsonPropertyOrder(27)]
        public string Substrain { get; set; }
        [JsonPropertyOrder(28)]
        public int InfectionRating { get; set; }
        [JsonPropertyOrder(29)]
        public List<string> InfectionEvents { get; set; } = new();
        [JsonPropertyOrder(30)]
        public List<Slight> Slights { get; set; } = new();

        //Morph
        [JsonPropertyOrder(31)]
        public List<Morph> Morphs { get; set; } = new();

        //inventory
        [JsonPropertyOrder(32)]
        public List<Gear> Inventory { get; set; } = new();

        //GearCaches
        [JsonPropertyOrder(33)]
        public List<GearCache> Caches { get; set; } = new();

        //lifepath Tracking Variables
        [JsonIgnore]
        public List<int> SkipSections { get; set; } = new();
        [JsonIgnore]
        public Stack<CharacterGenerationNode> CharacterGenerationNodes { get; set; } = new();
        [JsonPropertyOrder(34)]
        public List<string> CharacterGenerationOutput { get; set; } = new();
    }
}
