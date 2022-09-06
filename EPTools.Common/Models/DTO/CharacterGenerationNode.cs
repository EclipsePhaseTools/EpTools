using EPTools.Common.Interfaces;

namespace EPTools.Common.Models.DTO
{
    public class CharacterGenerationNode : IWeightedItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; } = 0;

        public List<List<CharacterGenerationNode>> OptionLists { get; set; } = new List<List<CharacterGenerationNode>>();
    }

    public class LifepathNativeTongue : IWeightedItem
    {
        public string Name { get; set; }
        public int Weight { get; set; }
    }

    public class LifepathBackgroundPath : IWeightedItem
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public List<LifepathBackgroundPathOption> Options { get; set; }
    }

    public class LifepathBackgroundPathOption : IWeightedItem
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public string Description { get; set; }
        public List<LifepathBackgroundPathOptionItem> Items { get; set; }
        public List<string> Motivations { get; set; }
        public List<LifepathBackgroundPathOptionItem> Morphs { get; set; }
    }

    public class LifepathBackgroundPathOptionItem : IWeightedItem
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public int Weight { get; set; }
    }

    public class LifepathYouthEvent : IWeightedItem
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<LifepathBackgroundPathOptionItem> Options { get; set; } = new List<LifepathBackgroundPathOptionItem>();
    }

    public class LifepathAge : IWeightedItem
    {
        public int Weight { get; set; }
        public string Result { get; set; }
        public List<LifepathBackgroundPathOptionItem> Options { get; set; } = new List<LifepathBackgroundPathOptionItem>();
    }
}
