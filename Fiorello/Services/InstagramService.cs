

using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class InstagramService : IInstagramService
    {
        private readonly AppDbContext _context;
        public InstagramService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Instagram>> GetAllAsync()
        {
            return await _context.Instagrams.ToListAsync();
        }
    }
}
