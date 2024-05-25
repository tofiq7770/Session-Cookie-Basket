using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class SurprizeService : ISurprizeService
    {
        private readonly AppDbContext _context;
        public SurprizeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Surprize>> GetAllAsync()
        {
            return await _context.Surprizes.ToListAsync();
        }
    }
}
