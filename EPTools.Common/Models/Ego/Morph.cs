#pragma warning disable CS8618

namespace EPTools.Common.Models.Ego
{
    public class Morph
    {
        public string Name { get; set; }
        public string MorphType { get; set; }
        public string MorphSex { get; set; }
        public string Size { get; set; }
        public int Vigor { get; set; }
        public int Insight { get; set; }
        public int Moxie { get; set; }
        public int MorphFlex { get; set; }
        public bool ActiveMorph { get; set; }
        

        public List<Trait> Traits { get; set; }
        public List<Ware> Wares { get; set; }
    }
}
