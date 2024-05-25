using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();
            Product product = await _productService.GetByIdAsync((int)id);
            List<Product> products = await _productService.GetAllAsync();

            if (product is null) return NotFound();


            ProductVM models = new()
            {
                Products = products,
                Product = product
            };


            return View(models);
        }
    }
}
