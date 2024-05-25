using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly ISliderInfosService _sliderInfosService;
        public SliderViewComponent(ISliderService sliderService, ISliderInfosService sliderInfosService)
        {
            _sliderService = sliderService;
            _sliderInfosService = sliderInfosService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliderData = new SliderVMVC()
            {
                Sliders = await _sliderService.GetAllAsync(),
                SliderInfos = await _sliderInfosService.GetDataAsync()
            };
            return await Task.FromResult(View(sliderData));
        }
    }
    public class SliderVMVC
    {
        public List<Slider> Sliders { get; set; }
        public SliderInfo SliderInfos { get; set; }
    }
}
