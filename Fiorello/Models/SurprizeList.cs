namespace Fiorello.Models
{
    public class SurprizeList : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int SurprizeId { get; set; }
        public Surprize Surprize { get; set; }

    }
}
