using EPTools.Common.Interfaces;
using EPTools.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EPTools.Common.Services
{
    public class EPDataService
    {
        private readonly IFetchService _fetchService;

        public EPDataService(IFetchService fetchService)
        {
            _fetchService = fetchService;
        }

        private List<Aptitude> _aptitudes = new();
        private List<Aptitude_Template> _aptitude_templates = new();
        private List<Background> _backgrounds = new();
        private List<Career> _careers = new();
        private List<CharGen> _chargen = new();
        private List<Faction> _factions = new();
        private List<GearArmor> _gear_armors = new();
        private List<GearBot> _gear_bots = new();
        private List<GearCategories> _gear_categories = new();
        private List<GearComms> _gear_comms = new();
        private List<GearCreature> _gear_creatures = new();
        private List<GearDrug> _gear_drugs = new();
        private List<GearItem> _gear_items = new();
        private List<GearMission> _gear_mission = new();
        private List<GearNano> _gear_nano = new();
        private List<GearPack> _gear_packs = new();
        private List<GearSecurity> _gear_security = new();
        private List<GearSoftware> _gear_software = new();
        private List<GearSwarm> _gear_swarms = new();
        private List<GearVehicle> _gear_vehicles = new();
        private List<GearWare> _gear_ware = new();
        private List<Morph> _morphs = new();

        private List<Trait> _traits = new();
        private List<CharacterGenerationNode> _lifepathNativeTongue = new();
        private List<CharacterGenerationNode> _lifepathBackgroundPath = new();
        private List<CharacterGenerationNode> _lifepathYouthEvents  = new();
        private List<CharacterGenerationNode> _lifepathAges = new();
        private List<CharacterGenerationNode> _lifepathAdvancedAges = new();

        public async Task<List<Aptitude>> GetAptitudes()
        {
            if (_aptitudes.Count == 0)
            {
                _aptitudes = await _fetchService.GetTFromEPFileAsync<List<Aptitude>>("aptitudes");
            }
            return _aptitudes;
        }

        public async Task<List<Aptitude_Template>> GetAptitudeTemplates()
        {
            if (_aptitude_templates.Count == 0)
            {
                _aptitude_templates = await _fetchService.GetTFromEPFileAsync<List<Aptitude_Template>>("aptitude_templates");
            }
            return _aptitude_templates;
        }

        public async Task<List<Background>> GetBackgrounds()
        {
            if (_backgrounds.Count == 0)
            {
                _backgrounds = await _fetchService.GetTFromEPFileAsync<List<Background>>("backgrounds");
            }
            return _backgrounds;
        }

        public async Task<List<Career>> GetCareers()
        {
            if (_careers.Count == 0)
            {
                _careers = await _fetchService.GetTFromEPFileAsync<List<Career>>("careers");
            }
            return _careers;
        }

        public async Task<List<CharGen>> GetCharGen()
        {
            if (_chargen.Count == 0)
            {
                _chargen = await _fetchService.GetTFromEPFileAsync<List<CharGen>>("chargen");
            }
            return _chargen;
        }

        public async Task<List<Faction>> GetFactions()
        {
            if (_factions.Count == 0)
            {
                _factions = await _fetchService.GetTFromEPFileAsync<List<Faction>>("factions");
            }
            return _factions;
        }

        public async Task<List<GearArmor>> GetGearArmors()
        {
            if (_gear_armors.Count == 0)
            {
                _gear_armors = await _fetchService.GetTFromEPFileAsync<List<GearArmor>>("gear_armor");
            }
            return _gear_armors;
        }

        public async Task<List<GearBot>> GetGearBots()
        {
            if (_gear_bots.Count == 0)
            {
                _gear_bots = await _fetchService.GetTFromEPFileAsync<List<GearBot>>("gear_bots");
            }
            return _gear_bots;
        }

        public async Task<List<GearCategories>> GetGearCategories()
        {
            if (_gear_categories.Count == 0)
            {
                _gear_categories = await _fetchService.GetTFromEPFileAsync<List<GearCategories>>("gear_categories");
            }
            return _gear_categories;
        }

        public async Task<List<GearComms>> GetGearComms()
        {
            if (_gear_comms.Count == 0)
            {
                _gear_comms = await _fetchService.GetTFromEPFileAsync<List<GearComms>>("gear_comms");
            }
            return _gear_comms;
        }

        public async Task<List<GearCreature>> GetGearCreatures()
        {
            if (_gear_creatures.Count == 0)
            {
                _gear_creatures = await _fetchService.GetTFromEPFileAsync<List<GearCreature>>("gear_creatures");
            }
            return _gear_creatures;
        }

        public async Task<List<GearDrug>> GetGearDrugs()
        {
            if (_gear_drugs.Count == 0)
            {
                _gear_drugs = await _fetchService.GetTFromEPFileAsync<List<GearDrug>>("gear_drugs");
            }
            return _gear_drugs;
        }

        public async Task<List<GearItem>> GetGearItems()
        {
            if (_gear_items.Count == 0)
            {
                _gear_items = await _fetchService.GetTFromEPFileAsync<List<GearItem>>("gear_items");
            }
            return _gear_items;
        }

        public async Task<List<GearMission>> GetGearMission()
        {
            if (_gear_mission.Count == 0)
            {
                _gear_mission = await _fetchService.GetTFromEPFileAsync<List<GearMission>>("gear_mission");
            }
            return _gear_mission;
        }

        public async Task<List<GearNano>> GetGearNano()
        {
            if (_gear_nano.Count == 0)
            {
                _gear_nano = await _fetchService.GetTFromEPFileAsync<List<GearNano>>("gear_nano");
            }
            return _gear_nano;
        }

        public async Task<List<GearPack>> GetGearPacks()
        {
            if (_gear_packs.Count == 0)
            {
                _gear_packs = await _fetchService.GetTFromEPFileAsync<List<GearPack>>("gear_packs");
            }
            return _gear_packs;
        }

        public async Task<List<GearSecurity>> GetGearSecurity()
        {
            if (_gear_security.Count == 0)
            {
                _gear_security = await _fetchService.GetTFromEPFileAsync<List<GearSecurity>>("gear_security");
            }
            return _gear_security;
        }

        public async Task<List<GearSoftware>> GetGearSoftware()
        {
            if (_gear_software.Count == 0)
            {
                _gear_software = await _fetchService.GetTFromEPFileAsync<List<GearSoftware>>("gear_software");
            }
            return _gear_software;
        }

        public async Task<List<GearSwarm>> GetGearSwarms()
        {
            if (_gear_swarms.Count == 0)
            {
                _gear_swarms = await _fetchService.GetTFromEPFileAsync<List<GearSwarm>>("gear_swarms");
            }
            return _gear_swarms;
        }

        public async Task<List<GearVehicle>> GetGearVehicles()
        {
            if (_gear_vehicles.Count == 0)
            {
                _gear_vehicles = await _fetchService.GetTFromEPFileAsync<List<GearVehicle>>("gear_vehicles");
            }
            return _gear_vehicles;
        }

        public async Task<List<GearWare>> GetGearWare()
        {
            if (_gear_ware.Count == 0)
            {
                _gear_ware = await _fetchService.GetTFromEPFileAsync<List<GearWare>>("gear_ware");
            }
            return _gear_ware;
        }

        public async Task<List<Morph>> GetMorphs()
        {
            if (_morphs.Count == 0)
            {
                _morphs = await _fetchService.GetTFromEPFileAsync<List<Morph>>("morphs");
            }
            return _morphs;
        }

        public async Task<List<Trait>> GetTraitsAsync()
        {
            if (_traits.Count == 0)
            {
                _traits = await _fetchService.GetTFromEPFileAsync<List<Trait>>("traits");
            }
            return _traits;
        }

        public async Task<List<CharacterGenerationNode>> GetLifepathNativeTonguesAsync()
        {
            if (_lifepathNativeTongue.Count == 0)
            {
                _lifepathNativeTongue = await _fetchService.GetTFromEPFileAsync<List<CharacterGenerationNode>>("lifepath_nativetongue");
            }
            return _lifepathNativeTongue;
        }

        public async Task<List<CharacterGenerationNode>> GetLifepathBackgroundPathAsync()
        {
            if (_lifepathBackgroundPath.Count == 0)
            {
                _lifepathBackgroundPath = await _fetchService.GetTFromEPFileAsync<List<CharacterGenerationNode>>("lifepath_nativetongue");
            }
            return _lifepathBackgroundPath;
        }

        public async Task<List<CharacterGenerationNode>> GetLifepathYouthEvents()
        {
            if (_lifepathYouthEvents.Count == 0)
            {
                _lifepathYouthEvents = await _fetchService.GetTFromFileAsync<List<CharacterGenerationNode>>("lifepath_youthevent");
            }
            return _lifepathYouthEvents;
        }

        public async Task<List<CharacterGenerationNode>> GetLifepathAges()
        {
            if (_lifepathAges.Count == 0)
            {
                _lifepathAges = await _fetchService.GetTFromEPFileAsync<List<CharacterGenerationNode>>("lifepath_age");
            }
            return _lifepathAges;
        }

        public async Task<List<CharacterGenerationNode>> GetLifepathAdvancedAges()
        {
            if (_lifepathAdvancedAges.Count == 0)
            {
                _lifepathAdvancedAges = await _fetchService.GetTFromEPFileAsync<List<CharacterGenerationNode>>("lifepath_advancedage");
            }
            return _lifepathAdvancedAges;
        }





        public async Task<List<CharacterGenerationNode>> GetCharacterGenTable(string tableName)
        {
            return await _fetchService.GetTFromEPFileAsync<List<CharacterGenerationNode>>(tableName);
        }

    }
}
