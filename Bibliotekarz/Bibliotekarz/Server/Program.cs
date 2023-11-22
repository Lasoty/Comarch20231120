using Bibliotekarz.Server.Context;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext>(opt => 
            opt.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        using (IServiceScope scope = app.Services.CreateScope())
        {
            using (var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>())
                dbContext.Database.Migrate();
        }


        app.Run();
    }
}
