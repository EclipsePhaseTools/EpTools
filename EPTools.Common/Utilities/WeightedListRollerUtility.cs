using EPTools.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPTools.Common.Utilities
{
    public static class WeightedListRollerUtility
    {
        public static T GetRandomWeightedItem<T>(List<T> WeightedList) where T : IWeightedItem, new()
        {
            var totalWeight = WeightedList.Sum(x=>x.Weight);

            var random = new Random();

            var randomNumber = random.Next(0, totalWeight);

            T selectedItem = new();

            foreach (var item in WeightedList)
            {
                if (randomNumber < item.Weight)
                {
                    selectedItem = item;
                    break;
                }
                randomNumber -= item.Weight;
            }

            return selectedItem;
        }
    }
}
