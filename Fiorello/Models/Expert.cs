namespace Fiorello.Models
{
    public class Expert : BaseEntity
    {
        public string Fullname { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int PositionId { get; set; }
        public Position Positions { get; set; }

    }
}
