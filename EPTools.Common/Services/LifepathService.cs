using EPTools.Common.Models.Ego;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPTools.Common.Services
{
    public class LifepathService
    {
        private Ego NewEgo { get; set; }
        private EPDataService _epDataservice;

        public LifepathService(EPDataService ePDataService)
        {
            NewEgo = new Ego();
            _epDataservice = ePDataService;
        }

        public async Task<Ego> GenerateEgo()
        {
            var rand = new Random();
            //1. Start with 1 point of Flex
            NewEgo.EgoFlex = 1;

            //2. Roll Aptitude Template
            var aptitudeCount = (await _epDataservice.GetAptitudeTemplates()).Count;
            var aptitude = (await _epDataservice.GetAptitudeTemplates())[rand.Next(aptitudeCount)];
            Console.WriteLine(aptitude.name);
            NewEgo.Cognition = aptitude.aptitudes.cognition;
            NewEgo.Intuition = aptitude.aptitudes.intuition;
            NewEgo.Reflex = aptitude.aptitudes.reflexes;
            NewEgo.Savvy = aptitude.aptitudes.savvy;
            NewEgo.Somatics = aptitude.aptitudes.somatics;
            NewEgo.Willpower  = aptitude.aptitudes.willpower;

            //3. Roll Native Tongue
            //4. Roll Background Path
            //5. Roll Youth Event
            //6. Roll Character’s Age
            //7. Roll Pre-Fall Life Event
            //8. The Fall: Roll Fall Event
            //9. Roll Career Path
            //10. Roll Interests Path
            //11. Determine Faction Alignment
            //12. Roll Post-Fall Life Event
            //13. Roll Further Development
            //14. Roll Crime/Firewall/Gatecrashing Event
            //15. Roll Gear
            //16. Final Stats and Details


            return NewEgo;
        }
    }
}
