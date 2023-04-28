using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SIG.Core.Domain;

namespace SIG.Data
{
    public class SigDBContext:DbContext
    {
        private readonly string strConn = @"Server=(localdb)\\mssqllocaldb;Database=aspnet-SIG.UI-e578ea46-d54d-49d0-be1e-51e4bd7ccd36;Trusted_Connection=True;MultipleActiveResultSets=true";

        public SigDBContext(DbContextOptions contextOptions):base(contextOptions)
        {
            
        }
        public SigDBContext()
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
                property.SetColumnType("Decimal(15,2)");
            }

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.ApplyConfigurationsFromAssembly(typeof(SigDBContext).Assembly);
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(strConn);
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Computer> Computers { get; set; }
    }
}