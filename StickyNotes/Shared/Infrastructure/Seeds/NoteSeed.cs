using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StickyNotes.Modules.Notes.Entities;

namespace StickyNotes.Shared.Infrastructure.Seeds;

public class NoteSeed : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        var welcomeId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        builder.HasData(new Note
        {
            Id = welcomeId,
            Title = "Welcome to Sticky Notes",
            Content = "This is your first note. You can edit or delete it.",
            IsPinned = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        });
    }
}