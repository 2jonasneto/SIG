using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIG.Core.Domain.Interfaces;
using SIG.Data.Base;
using SIG.Data.Respositories;
using Microsoft.Extensions.DependencyInjection;

namespace SIG.UI
{
    public class Program
    {
     

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("Conn2") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<SigDBContext>(options =>
                options.UseSqlServer(connectionString));
            // builder.Services.AddDbContext<SigDBContext>();
         
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SigDBContext>();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<ILocacityRepository, LocacityRepository>();
            builder.Services.AddScoped<IActingAreaRepository, ActingAreaRepository>();
            builder.Services.AddScoped<ISectorRepository, SectorRepository>();
            builder.Services.AddScoped<IEquipTypeRepository, EquipTypeRepository>();
            builder.Services.AddMvc();
          
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
           app.UseMigrationsEndPoint();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapAreaControllerRoute(
               name: "areas",
               areaName:"Maintenance",
               pattern: "Maintenance/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
           
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<SigDBContext>();
                context.Database.Migrate();
            }

            app.Run();
        }
    }
}