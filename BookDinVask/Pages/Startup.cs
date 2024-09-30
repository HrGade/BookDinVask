using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookDinVask.Pages
{
    public class Startup
    {

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=BookDinVask;Trusted_Connection=True;"));

            // Tilføj Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Tilføj Razor Pages og kræv login for booking
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizePage("/Index"); // Beskyt bookingsiden
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Hvor brugeren bliver omdirigeret ved login
            });
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            // Brug godkendelse og autorisation
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

        }

        }
    }

