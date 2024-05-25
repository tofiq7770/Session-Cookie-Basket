using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class SliderInfosService : ISliderInfosService
    {
        private readonly AppDbContext _context;
        public SliderInfosService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SliderInfo> GetDataAsync()
        {
            return await _context.SliderInfos.FirstOrDefaultAsync();
        }
    }
}
