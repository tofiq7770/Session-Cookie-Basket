using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IInstagramService _instagramService;
        private readonly IBlogService _blogService;
        private readonly ISurprizeService _surprizeService;
        private readonly IExpertService _expertService;
        private readonly ISurprizeListService _surprizeListService;

        public HomeController(IProductService productService, ICategoryService categoryService
                              , IBlogService blogService, IInstagramService instagramService
                               , ISurprizeService surprizeService, ISurprizeListService surprizeListService
                                , IExpertService expertService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _blogService = blogService;
            _instagramService = instagramService;
            _surprizeService = surprizeService;
            _expertService = expertService;
            _surprizeListService = surprizeListService;

        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            List<Product> products = await _productService.GetAllAsync();
            List<Surprize> surprizes = await _surprizeService.GetAllAsync();
            List<SurprizeList> surprizeLists = await _surprizeListService.GetAllAsync();
            List<Expert> experts = await _expertService.GetAllAsync();
            List<Blog> blogs = await _blogService.GetShownDataAsync();
            List<Instagram> instagrams = await _instagramService.GetAllAsync();

            HomeVM models = new()
            {
                Categories = categories,
                Products = products,
                Surprizes = surprizes,
                SurprizeLists = surprizeLists,
                Experts = experts,
                Blogs = blogs,
                Instagrams = instagrams
            };
            return View(models);
        }
    }
}