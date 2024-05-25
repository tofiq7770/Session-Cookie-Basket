using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM categoryVM)
        {
            if (!ModelState.IsValid) return View();
            bool result = await _context.Categories.AnyAsync(x => x.Name.Trim().ToLower() == categoryVM.Name.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Name", "This Name Does Exist");
                return View(categoryVM);
            }
            CategoryCreateVM model = new()
            {
                Name = categoryVM.Name
            };
            await _context.Categories.AddAsync(new Category { Name = categoryVM.Name });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();
            Category category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);

            CategoryUpdateVM model = new()
            {
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryUpdateVM categoryVM, int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            Category category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            category.Name = categoryVM.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Category category = await _context.Categories.Where(c => c.Id == id).Include(c => c.products).FirstOrDefaultAsync();
            if (category == null) return NotFound();

            CategoryDetailVM model = new()
            {
                Name = category.Name,
                ProductCount = category.products.Count
            };
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Category category = _context.Categories.FirstOrDefault(s => s.Id == id);

            if (category is null) return NotFound();

            _context.Remove(category);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
