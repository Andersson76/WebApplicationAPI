using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITournamentService
    {
        Task<List<Tournament>> GetAllAsync(string? search);
        Task<Tournament?> GetByIdAsync(int id);
        Task<Tournament> CreateAsync(Tournament tournament);
        Task<bool> UpdateAsync(int id, Tournament updated);
        Task<bool> DeleteAsync(int id);
    }
}
