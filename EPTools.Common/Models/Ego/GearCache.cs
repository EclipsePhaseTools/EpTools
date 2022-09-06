#pragma warning disable CS8618

namespace EPTools.Common.Models.Ego
{
    public class GearCache
    {
        public string Location { get; set; }
        public List<Gear> Inventory { get; set; } = new List<Gear>();
    }
}
