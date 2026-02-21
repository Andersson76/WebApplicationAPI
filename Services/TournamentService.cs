using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services;
public class TournamentService : ITournamentService
{
    private readonly AppDbContext _db;
    public TournamentService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Tournament>> GetAllAsync(string? search)
    {
        IQueryable<Tournament> query = _db.Tournaments;

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            query = query.Where(t => t.Title.ToLower().Contains(s));
        }

        return await query.OrderBy(t => t.Date).ToListAsync();
    }

    public async Task<Tournament?> GetByIdAsync(int id)
        => await _db.Tournaments.FirstOrDefaultAsync(t => t.Id == id);

    public async Task<Tournament> CreateAsync(Tournament tournament)
    {
        _db.Tournaments.Add(tournament);
        await _db.SaveChangesAsync();
        return tournament;
    }

    public async Task<bool> UpdateAsync(int id, Tournament updated)
    {
        var existing = await _db.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
        if (existing is null) return false;

        existing.Title = updated.Title;
        existing.Description = updated.Description;
        existing.MaxPlayers = updated.MaxPlayers;
        existing.Date = updated.Date;

        await _db.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
        if (existing is null) return false;

        _db.Tournaments.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}

