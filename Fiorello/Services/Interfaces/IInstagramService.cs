using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface IInstagramService
    {
        Task<List<Instagram>> GetAllAsync();
    }
}
