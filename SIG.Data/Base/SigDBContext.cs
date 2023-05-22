using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SIG.Core.Domain;

namespace SIG.Data.Base
{
    public class SigDBContext : IdentityDbContext
    {

        public SigDBContext(DbContextOptions<SigDBContext> contextOptions) : base(contextOptions)
        {

        }
  
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(SigDBContext).Assembly);
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("Varchar(100)");
            }
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(decimal))))
            {
                property.SetColumnType("Decimal(10,2)");
            }

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.ApplyConfigurationsFromAssembly(typeof(SigDBContext).Assembly);
            base.OnModelCreating(builder);
        }
     

        public DbSet<Computer> Computers { get; set; }
        public DbSet<ActingArea> ActingAreas { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Historic> Historics { get; set; }
        public DbSet<Locacity> Locacities { get; set; }

    }
}