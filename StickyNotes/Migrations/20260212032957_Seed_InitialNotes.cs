using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StickyNotes.Migrations
{
    /// <inheritdoc />
    public partial class Seed_InitialNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedAt", "IsPinned", "Title", "UpdatedAt" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "This is your first note. You can edit or delete it.", new DateTime(2026, 2, 12, 3, 29, 56, 918, DateTimeKind.Utc).AddTicks(1151), true, "Welcome to Sticky Notes", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
