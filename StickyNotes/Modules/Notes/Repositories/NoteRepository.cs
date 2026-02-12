using Microsoft.EntityFrameworkCore;
using StickyNotes.Modules.Notes.Entities;
using StickyNotes.Shared.Infrastructure;

namespace StickyNotes.Modules.Notes.Repositories;

public interface INoteRepository
{
    Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken ct);
    Task<Note?> GetByIdAsync(Guid id, CancellationToken ct);

    Task AddAsync(Note note, CancellationToken ct);
    Task UpdateAsync(Note note, CancellationToken ct);
    Task DeleteAsync(Note note, CancellationToken ct);
}

public class NoteRepository : INoteRepository
{
    private readonly AppDbContext _db;

    public NoteRepository(AppDbContext db) => _db = db;

    public async Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken ct)
    {
        return await _db.Notes
            .AsNoTracking()
            .OrderByDescending(x => x.IsPinned)
            .ThenByDescending(x => x.UpdatedAt ?? x.CreatedAt)
            .ToListAsync(ct);
    }

    public Task<Note?> GetByIdAsync(Guid id, CancellationToken ct)
        => _db.Notes.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task AddAsync(Note note, CancellationToken ct)
    {
        _db.Notes.Add(note);
        await _db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Note note, CancellationToken ct)
    {
        _db.Notes.Update(note);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Note note, CancellationToken ct)
    {
        _db.Notes.Remove(note);
        await _db.SaveChangesAsync(ct);
    }
}
