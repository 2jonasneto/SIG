using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SIG.Core.Domain;

namespace SIG.Data.Base
{
    public class SigDBContext : DbContext
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
    }
}