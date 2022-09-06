using EPTools.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPTools.Common.Extensions
{
    public static class MyExtensions
    {
        public static T GetWeightedItem<T>(this IEnumerable<T> weightedList, int WeightedListModifier = 0) where T : IWeightedItem, new()
        {
            var totalWeight = weightedList.Sum(x => x.Weight) + Math.Max(WeightedListModifier, 0);

            var random = new Random();

            var randomNumber = random.Next(0, totalWeight);

            T selectedItem = new();

            foreach (var item in weightedList)
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
