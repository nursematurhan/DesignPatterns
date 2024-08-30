using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-2PO14DN;initial catalog=DesignPattern2;integrated security=true;TrustServerCertificate=True;")
                .LogTo(Console.WriteLine, LogLevel.Debug);
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure precision and scale for the Price property
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)"); // Sets precision to 18 and scale to 2

            base.OnModelCreating(modelBuilder);
        }
    }
}
