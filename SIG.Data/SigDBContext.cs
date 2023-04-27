using Microsoft.EntityFrameworkCore;
using SIG.Core.Domain;

namespace SIG.Data
{
    public class SigDBContext:DbContext
    {
        public string conn = "";// ConfigurationManager.ConnectionStrings["SqlConn2"].ConnectionString;

        public SigDBContext(DbContextOptions<SigDBContext> contextOptions):base(contextOptions)
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
                optionsBuilder.UseSqlServer(conn);
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Computer> Computers { get; set; }
    }
}