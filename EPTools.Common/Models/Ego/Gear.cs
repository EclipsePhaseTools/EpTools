#pragma warning disable CS8618

namespace EPTools.Common.Models.Ego
{
    public class Gear
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public bool Restricted { get; set; }
        public string BlueprintType  { get; set; }
    }
}
