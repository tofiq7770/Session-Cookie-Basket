using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface IExpertService
    {
        Task<List<Expert>> GetAllAsync();

    }
}
