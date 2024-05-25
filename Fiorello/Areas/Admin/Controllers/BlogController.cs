using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            return View(blogs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogsCreateVM create)
        {
            if (!ModelState.IsValid) return BadRequest();
            bool result = await _context.Blogs.AnyAsync(x => x.Title.Trim().ToLower() == create.Title.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Title", "This Title Does Exist");
                return View(create);
            }
            Blog blog = new()
            {
                Title = create.Title,
                Description = create.Description,
                Date = create.Date,
                Image = "blog-feature-img-1.jpg"
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

            BlogsUpdateVM updateVM = new()
            {
                Title = blog.Title,
                Description = blog.Description,
                Date = blog.Date
            };

            return View(updateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, BlogsUpdateVM update)
        {
            if (!ModelState.IsValid) return BadRequest();
            Blog blogs = _context.Blogs.FirstOrDefault(s => s.Id == id);
            if (blogs is null)
            {
                return NotFound();
            }
            blogs.Title = update.Title;
            blogs.Description = update.Description;
            blogs.Date = update.Date;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Blog blogs = _context.Blogs.FirstOrDefault(s => s.Id == id);
            if (blogs == null) return NotFound();

            BlogsDetailVM model = new()
            {
                Title = blogs.Title,
                Description = blogs.Description,
                Date = blogs.Date,
                Image = blogs.Image
            };
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            Blog blogs = _context.Blogs.FirstOrDefault(s => s.Id == id);
            if (blogs is null) return NotFound();

            _context.Remove(blogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
