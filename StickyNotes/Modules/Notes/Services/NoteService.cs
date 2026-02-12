using StickyNotes.Modules.Notes.Entities;
using StickyNotes.Modules.Notes.Repositories;

namespace StickyNotes.Modules.Notes.Services;

public interface INoteService
{
    Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken ct);
    Task CreateAsync(string title, string content, bool isPinned, CancellationToken ct);
    Task UpdateAsync(Guid id, string title, string content, bool isPinned, CancellationToken ct);
    Task DeleteAsync(Guid id, CancellationToken ct);
    Task TogglePinAsync(Guid id, CancellationToken ct);
}

public class NoteService : INoteService
{
    private readonly INoteRepository _repo;

    public NoteService(INoteRepository repo) => _repo = repo;

    public Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken ct)
        => _repo.GetAllAsync(ct);

    public async Task CreateAsync(string title, string content, bool isPinned, CancellationToken ct)
    {
        title = (title ?? "").Trim();
        if (string.IsNullOrWhiteSpace(title))
            throw new InvalidOperationException("Title is required.");

        var note = new Note
        {
            Title = title,
            Content = (content ?? "").Trim(),
            IsPinned = isPinned,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(note, ct);
    }

    public async Task UpdateAsync(Guid id, string title, string content, bool isPinned, CancellationToken ct)
    {
        var note = await _repo.GetByIdAsync(id, ct) ?? throw new InvalidOperationException("Note not found.");

        title = (title ?? "").Trim();
        if (string.IsNullOrWhiteSpace(title))
            throw new InvalidOperationException("Title is required.");

        note.Title = title;
        note.Content = (content ?? "").Trim();
        note.IsPinned = isPinned;
        note.UpdatedAt = DateTime.UtcNow;

        await _repo.UpdateAsync(note, ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        var note = await _repo.GetByIdAsync(id, ct);
        if (note == null)
            return;
        await _repo.DeleteAsync(note, ct);
    }

    public async Task TogglePinAsync(Guid id, CancellationToken ct)
    {
        var note = await _repo.GetByIdAsync(id, ct) ?? throw new InvalidOperationException("Note not found.");
        note.IsPinned = !note.IsPinned;
        note.UpdatedAt = DateTime.UtcNow;
        await _repo.UpdateAsync(note, ct);
    }
}