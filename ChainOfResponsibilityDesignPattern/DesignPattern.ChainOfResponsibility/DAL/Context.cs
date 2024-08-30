using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-2PO14DN;initial catalog=DesignPattern1;integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<CustomerProcess> CustomerProcess { get; set; }
    }
}
