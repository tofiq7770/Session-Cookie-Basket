using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface ISurprizeListService
    {
        Task<List<SurprizeList>> GetAllAsync();

    }
}
