using Fiorella.ViewModels.Baskets;
using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IInstagramService _instagramService;
        private readonly IBlogService _blogService;
        private readonly ISurprizeService _surprizeService;
        private readonly IExpertService _expertService;
        private readonly ISurprizeListService _surprizeListService;
        private readonly IHttpContextAccessor _accessor;


        public HomeController(IProductService productService, ICategoryService categoryService
                              , IBlogService blogService, IInstagramService instagramService
                               , ISurprizeService surprizeService, ISurprizeListService surprizeListService
                                , IExpertService expertService, IHttpContextAccessor accessor
                                 , AppDbContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _blogService = blogService;
            _instagramService = instagramService;
            _surprizeService = surprizeService;
            _expertService = expertService;
            _surprizeListService = surprizeListService;
            _accessor = accessor;
            _context = context;

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
        [HttpPost]

        public async Task<IActionResult> AddProductToBasket(int? id)
        {

            if (id is null) return BadRequest();

            List<BasketVM> basketProducts = null;

            if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basketProducts = new List<BasketVM>();
            }



            var datasdb = await _context.Products.Include(m => m.Category).Include(m => m.ProductImage).FirstOrDefaultAsync(m => m.Id == (int)id);

            var existProduct = basketProducts.FirstOrDefault(m => m.Id == (int)id);

            if (existProduct is not null)
            {
                existProduct.Count++;
            }
            else
            {
                basketProducts.Add(new BasketVM
                {
                    Id = (int)id,
                    Count = 1,
                    Price = datasdb.Price,
                    Name = datasdb.Name,
                    Description = datasdb.Description,
                    Category = datasdb.Category.Name,
                    Image = datasdb.ProductImage.FirstOrDefault(m => m.IsMain && !m.SoftDelete)?.Name


                });
            }

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));


            int count = basketProducts.Sum(m => m.Count);
            decimal total = basketProducts.Sum(m => m.Count * m.Price);

            return Ok(new { count, total });
        }
    }
}