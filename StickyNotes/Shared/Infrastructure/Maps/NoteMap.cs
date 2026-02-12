using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StickyNotes.Modules.Notes.Entities;

namespace StickyNotes.Shared.Infrastructure.Maps;

public class NoteMap : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("Notes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(x => x.Content)
            .HasMaxLength(4000);

        builder.Property(x => x.IsPinned)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        // Indexes
        builder.HasIndex(x => x.CreatedAt);
        builder.HasIndex(x => x.IsPinned);
        builder.HasIndex(x => new { x.IsPinned, x.CreatedAt });
    }
}