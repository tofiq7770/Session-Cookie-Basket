using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface ISurprizeService
    {
        Task<List<Surprize>> GetAllAsync();
    }
}
