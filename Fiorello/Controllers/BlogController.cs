using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;
        public BlogController(AppDbContext context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _blogService.GetShownDataAsync();
            return View(blogs);
        }
        [HttpGet]
        public async Task<IActionResult> ShowMore(int skip)
        {
            List<Blog> blogs = await _context.Blogs.Skip(3).Take(3).ToListAsync();
            return PartialView("_BlogsPartial", blogs);
        }
    }
}
