using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class SurprizeListService : ISurprizeListService
    {
        private readonly AppDbContext _context;
        public SurprizeListService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<SurprizeList>> GetAllAsync()
        {
            return await _context.SurprizeLists.ToListAsync();
        }
    }
}
