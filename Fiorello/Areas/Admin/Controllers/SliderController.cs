using Fiorello.DAL;
using Fiorello.Helpers.Extentions;
using Fiorello.Models;
using Fiorello.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM create)
        {
            if (!ModelState.IsValid) return View();
            foreach (var item in create.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Images", "File must be Image Format");
                    return View();
                }
                if (!item.CheckFileSize(200))
                {

                    ModelState.AddModelError("Images", "Max File Capacity mut be 300KB");
                    return View();
                }
            }
            foreach (var item in create.Images)
            {
                string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;
                string path = Path.Combine(_env.WebRootPath, "img", fileName);
                await item.SaveFileToLocalAsync(path);
                await _context.Sliders.AddAsync(new Slider { Name = fileName });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Slider slider = await _context.Sliders.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (slider == null) return NotFound();
            SliderDetailVM model = new()
            {
                Id = slider.Id,
                Name = slider.Name

            };
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Slider slide = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slide is null) return NotFound();

            slide.Name.DeleteFile(_env.WebRootPath, "img");

            _context.Sliders.Remove(slide);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id <= 0) return BadRequest();

            Slider slide = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slide is null) return NotFound();

            return View(new SliderUpdateVM { Images = slide.Name });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM request)
        {
            if (id <= 0) return BadRequest();

            Slider slide = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slide is null) return NotFound();

            if (request.NewImage is null) return RedirectToAction(nameof(Index));


            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "File must be Image Format");
                request.Images = slide.Name;
                return View(request);
            }
            if (!request.NewImage.CheckFileSize(200))
            {

                ModelState.AddModelError("NewImage", "Max File Capacity mut be 300KB");
                request.Images = slide.Name;
                return View(request);
            }

            //string oldPath = Path.Combine(_env.WebRootPath, "img", slide.Name);

            //oldPath.DeleteFile(oldPath);

            slide.Name.DeleteFile(_env.WebRootPath, "img");

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string newPath = Path.Combine(_env.WebRootPath, "img", fileName);


            await request.NewImage.SaveFileToLocalAsync(newPath);

            slide.Name = fileName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
