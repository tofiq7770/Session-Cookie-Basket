namespace Fiorello.Models
{
    public class Surprize : BaseEntity
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<SurprizeList> SurprizeList { get; set; }

    }
}
