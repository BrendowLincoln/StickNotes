using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using StickyNotes.Components;
using StickyNotes.Modules.Notes.Repositories;
using StickyNotes.Modules.Notes.Services;
using StickyNotes.Shared.Infrastructure;

namespace StickyNotes;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(cs));
        
        builder.Services.AddScoped<INoteRepository, NoteRepository>();
        builder.Services.AddScoped<INoteService, NoteService>();
        
        builder.Services.AddMudServices();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}