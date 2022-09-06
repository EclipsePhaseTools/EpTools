using EPTools.Common.Extensions;
using EPTools.Common.Models.DTO;
using EPTools.Common.Models.Ego;
using EPTools.Common.Utilities;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace EPTools.Common.Services
{
    public class LifepathService
    {
        private Ego NewEgo { get; set; }
        private EPDataService _epDataservice;

        public LifepathService(EPDataService ePDataService)
        {
            NewEgo = new Ego {
                Identities = new List<Identity> { new Identity() }
            };
            _epDataservice = ePDataService;
        }

        public async Task<Ego> GenerateEgo()
        {
            NewEgo = new Ego
            {
                Identities = new List<Identity> { new Identity() }
            };

            var CharGenSteps = (await _epDataservice.GetCharacterGenTable("charactergenstep"));

            CharGenSteps.Reverse();

            CharGenSteps.ForEach(x=> NewEgo.CharacterGenerationNodes.Push(x));

            while (NewEgo.CharacterGenerationNodes.Any())
            {
                var node = NewEgo.CharacterGenerationNodes.Pop();
                //Console.WriteLine($"{node.Name} {node.Description} {node.Value}");
                await ApplyBackgroundOption(NewEgo, node);
            }

            return NewEgo;
        }

        private async Task<Ego> ApplyBackgroundOption(Ego ego, CharacterGenerationNode option)
        {
            ego.CharacterGenerationOutput.Add($"{option.Name} {option.Description}".Trim());
            switch (option.Type)
            {

                case "Morph":
                    var selectedMorph = (await _epDataservice.GetMorphs()).FirstOrDefault(x => x.Name == option.Name);
                    if (selectedMorph != null)
                    {
                        ego.Morphs.Add(new Models.Ego.Morph
                        {
                            Name = option.Name,
                            ActiveMorph = false,
                            Insight = selectedMorph.pools.insight,
                            Moxie = selectedMorph.pools.moxie,
                            Vigor = selectedMorph.pools.vigor,
                            MorphFlex = selectedMorph.pools.flex,
                            MorphType = selectedMorph.type,
                            MorphSex = "",
                            Traits = selectedMorph.morph_traits.Select(x => new Models.Ego.Trait { Name = x.name, Level = x.level }).ToList(),
                            Wares = selectedMorph.ware.Select(x=> new Models.Ego.Ware { Name = x}).ToList()
                        });
                    }
                    break;
                case "Skill":
                    ego.Skills.Add(new EgoSkill { Name = option.Name.Split("-")[0], Rank = option.Value, Specializaion = option.Name.Split("-").Length > 1 ? option.Name.Split("-")[1] : "" });
                    break;
                case "Trait":
                    var trait = (await _epDataservice.GetTraitsAsync()).FirstOrDefault(x => x.name == option.Name.Split("-")[0]);
                    ego.EgoTraits.Add(new Models.Ego.Trait { Name = option.Name, Description = trait?.description ?? "", Level = option.Value, Type = "Ego" });
                    break;
                case "Language":
                    if (ego.Languages == null || ego.Languages.Length == 0)
                    {
                        ego.Languages = option.Name;
                    }
                    else
                    {
                        ego.Languages += ", " + option.Name;
                    }
                    break;
                case "Pool":
                    switch (option.Name)
                    {
                        case "Flex":
                            ego.EgoFlex += option.Value;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Reputation":
                    var repnetwork = typeof(Identity).GetProperty(option.Name);
                    if (repnetwork != null)
                    {
                        repnetwork.SetValue(ego.Identities[0], option.Value);
                    }
                    break;
                case "Aptitude":
                    string aptitudeToChange = (await _epDataservice.GetAptitudes()).FirstOrDefault(x => x.short_name == option.Name.ToUpper())?.Name ?? "";
                    aptitudeToChange = char.ToUpper(aptitudeToChange[0]) + aptitudeToChange[1..];

                    var aptitudeProperty = typeof(Ego).GetProperty(aptitudeToChange);
                    if (aptitudeProperty != null)
                    {
                        aptitudeProperty.SetValue(ego, option.Value + (int)aptitudeProperty?.GetValue(NewEgo));
                    }
                    break;
                case "Slight":
                    for (int i = 0; i < option.Value; i++)
                    {
                        ego.Slights.Add(new Models.Ego.Slight { Name = "Random or chosen" });
                    }
                    break;
                case "Faction":
                    ego.Faction = option.Name;
                    break;
                case "Interest":
                    ego.Interest = option.Name;
                    goto default;
                case "Career":
                    ego.Career = option.Name;
                    goto default;
                case "Age":
                    ego.EgoAge = option.Value;
                    break;
                case "Motivation":
                    ego.Motivations.Add(option.Name);
                    break;
                case "Skip":
                    ego.SkipSections.Add(option.Value);
                    break;
                case "ChararacterGenStep":
                    if (NewEgo.SkipSections.Contains(option.Value))
                    {
                        break;
                    }
                    goto default;
                case "BackgroundOption":
                    ego.Background = option.Name;
                    goto default;
                case "Table":
                    var nodes = await ProcessTableRequest(option.Name, option.Value, ego);
                    nodes.ForEach(x=>ego.CharacterGenerationNodes.Push(x));
                    break;
                default:
                    foreach (var list in option.OptionLists)
                    {
                        if (list.Sum(x => x.Weight) > 0)
                        {
                            NewEgo.CharacterGenerationNodes.Push(list.GetWeightedItem());
                        }
                        else
                        {
                            foreach (var item in list)
                            {
                                NewEgo.CharacterGenerationNodes.Push(item);
                            }
                        }
                    }
                    break;
            }

            return ego;
        }

        private async Task<List<CharacterGenerationNode>> ProcessTableRequest(string tablename, int tablemodifier, Ego ego)
        {
            List<CharacterGenerationNode> options = new();

            var table = (await _epDataservice.GetCharacterGenTable(tablename)).GetWeightedItem(tablemodifier);

            //Console.WriteLine($"{table.Name} {table.Description}");
            ego.CharacterGenerationOutput.Add($"{table.Name} {table.Description}".Trim());

            foreach (var nodeList in table.OptionLists)
            {
                if (nodeList.Sum(x=>x.Weight) > 0)
                {
                    options.Add(nodeList.GetWeightedItem());
                }
                else
                {
                    options.AddRange(nodeList);
                }
            }

            return options;
        }
    }
}
