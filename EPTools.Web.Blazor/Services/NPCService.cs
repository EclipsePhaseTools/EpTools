using EPTools.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPTools.Web.Blazor.Services
{
    public class NPCService
    {
        private readonly EPDataService EPData;

        public NPCService(EPDataService dataService)
        {
            EPData = dataService;
        }


		public NPC GenerateNPC()
        {
			//Generation Steps
			//1. Choose Archtype
			//2. Choose Morph
			//3. Calculate Derived Stats
			//4. Choose Skill Ranges
			//5. Generate Skills (Archtype Skills allowed to hit upper end of range)
			//6. Choose Gear
			//7. Choose Ware
			//8. Calculate Attacks



			throw new NotImplementedException();
        }
    }

    public class NPC
    {
        public string Name { get; set; }
        public int Initiative { get; set; }
        public int WoundThreshold { get; set; }
        public int Durability { get; set; }
        public int DamageRating { get; set; }
        public int ThreatPool { get; set; }
        public List<string> Movement { get; set; }
        public List<KeyValuePair<string, int>> Skills { get; set; }
        public List<CharacterAptitude> Aptitudes { get; set; }
        public List<string> Ware { get; set; }
        public List<string> Traits { get; set; }
        public String Notes { get; set; }
    }

	public class CharacterAptitude
	{
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public int Score { get; set; }
		public int CheckRating { get { return Score * 3; } }

		public static List<CharacterAptitude> GetAptitudes()
		{
			return GetAptitudes(0, 0, 0, 0, 0, 0);
		}

		public static List<CharacterAptitude> GetAptitudes(int cog, int intu, int refl, int sav, int som, int wil)
		{
			var ls = new List<CharacterAptitude>();

			ls.Add(new CharacterAptitude { Name = "Cognition", Abbreviation = "COG", Score = cog });
			ls.Add(new CharacterAptitude { Name = "Intuition", Abbreviation = "INT", Score = intu });
			ls.Add(new CharacterAptitude { Name = "Reflexes", Abbreviation = "REF", Score = refl });
			ls.Add(new CharacterAptitude { Name = "Savvy", Abbreviation = "SAV", Score = sav });
			ls.Add(new CharacterAptitude { Name = "Somatics", Abbreviation = "SOM", Score = som });
			ls.Add(new CharacterAptitude { Name = "Willpower", Abbreviation = "WIL", Score = wil });

			return ls;
		}

		public static List<CharacterAptitude> GetAptitudeTemplates(Aptitude_Template template)
		{
			return GetAptitudes(template.aptitudes.cognition,
								template.aptitudes.intuition,
								template.aptitudes.reflexes,
								template.aptitudes.savvy,
								template.aptitudes.somatics,
								template.aptitudes.willpower);
		}
	}
}
