using Microsoft.EntityFrameworkCore;

namespace BookDinVask.Pages
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Tilføj DbContext med en forbindelse til "BookDinVask"-databasen
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=BookDinVask;Trusted_Connection=True;"));

            // Registrer repository i DI containeren
            services.AddScoped<IBeboerRepository, BeboerRepository>();

            // Tilføj Razor Pages eller MVC afhængigt af hvad du bruger
            services.AddRazorPages();  // Hvis du bruger Razor Pages
        }

        // Resten af Startup-opsætningen...
    }
}

