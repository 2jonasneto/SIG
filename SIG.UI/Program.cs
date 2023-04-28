using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIG.Core.Domain.Interfaces;
using SIG.Data;
using SIG.Data.Respositories;

namespace SIG.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<SigDBContext>(options =>
                options.UseSqlServer(connectionString));
            // builder.Services.AddDbContext<SigDBContext>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SigDBContext>();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<DbContext, SigDBContext>();
            builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
            builder.Services.AddControllersWithViews();
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}