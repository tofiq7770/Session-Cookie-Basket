using Fiorella.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiorella.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CartController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            List<BasketVM> basketProducts = null;

            if (_contextAccessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_contextAccessor.HttpContext.Request.Cookies["basket"]);
            }

            return View(basketProducts);
        }

        [HttpPut]
        public async Task<IActionResult> Increase(int? id)
        {
            if (id is null) return BadRequest();

            List<BasketVM> basketProducts = null;

            if (_contextAccessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_contextAccessor.HttpContext.Request.Cookies["basket"]);
            }

            BasketVM dbBsket = basketProducts.FirstOrDefault(m => m.Id == id);

            dbBsket.Count++;

            _contextAccessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));

            int count = basketProducts.Sum(m => m.Count);
            int dbBasketCount = dbBsket.Count;
            decimal total = basketProducts.Sum(m => m.Count * m.Price);

            return Ok(new { count, total, dbBasketCount });
        }

        [HttpPut]
        public async Task<IActionResult> Decrease(int? id)
        {
            if (id is null) return BadRequest();

            List<BasketVM> basketProducts = null;

            if (_contextAccessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_contextAccessor.HttpContext.Request.Cookies["basket"]);
            }

            BasketVM dbBsket = basketProducts.FirstOrDefault(m => m.Id == id);

            if (dbBsket.Count > 0)
            {
                dbBsket.Count--;
            }

            _contextAccessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));

            int count = basketProducts.Sum(m => m.Count);
            int dbBasketCount = dbBsket.Count;
            decimal total = basketProducts.Sum(m => m.Count * m.Price);

            return Ok(new { count, total, dbBasketCount });
        }
    }
}
