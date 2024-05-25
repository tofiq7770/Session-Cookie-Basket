using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllAsync();
    }
}
