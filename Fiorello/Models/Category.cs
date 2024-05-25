using System.ComponentModel.DataAnnotations;

namespace Fiorello.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(25, ErrorMessage = "Max length of Name Should be 25")]
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
