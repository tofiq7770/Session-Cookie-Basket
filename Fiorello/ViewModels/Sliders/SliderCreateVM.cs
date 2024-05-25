using System.ComponentModel.DataAnnotations;

namespace Fiorello.ViewModels.Sliders
{
    public class SliderCreateVM
    {
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
