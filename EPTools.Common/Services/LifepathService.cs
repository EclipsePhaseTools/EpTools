using EPTools.Common.Extensions;
using EPTools.Common.Models.DTO;
using EPTools.Common.Models.Ego;
using EPTools.Common.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            var CharGenSteps = (await _epDataservice.GetCharacterGenTable("backgroundstep"));

            CharGenSteps.Reverse();

            CharGenSteps.ForEach(x=> NewEgo.CharacterGenerationNodes.Push(x));

            while (NewEgo.CharacterGenerationNodes.Any())
            {
                var node = NewEgo.CharacterGenerationNodes.Pop();
                Console.WriteLine($"{node.Name} {node.Description} {node.Value}");
                await ApplyBackgroundOption(NewEgo, node);
            }

            return NewEgo;
        }

        private async Task<Ego> ApplyBackgroundOption(Ego ego, CharacterGenerationNode option)
        {
            switch (option.Type)
            {
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
                case "Skip":
                    ego.SkipSections.Add(option.Value);
                    break;
                case "ChararacterGenStep":
                    if (NewEgo.SkipSections.Contains(option.Value))
                    {
                        break;
                    }
                    goto default;
                case "BackgroundPath":
                    ego.Background = option.Name;
                    goto default;
                case "BackgroundOption":
                    ego.Background += " - " + option.Name;
                    goto default;
                case "Table":
                    var nodes = await ProcessTableRequest(option.Name, option.Value);
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

        private async Task<List<CharacterGenerationNode>> ProcessTableRequest(string tablename, int tablemodifier)
        {
            List<CharacterGenerationNode> options = new();

            var table = (await _epDataservice.GetCharacterGenTable(tablename)).GetWeightedItem(tablemodifier);

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
