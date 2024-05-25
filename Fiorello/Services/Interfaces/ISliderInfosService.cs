using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface ISliderInfosService
    {
        Task<SliderInfo> GetDataAsync();
    }
}
