using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ModuleContext>
    {
        public ModuleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ModuleContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-ES4JPS6;Database=ModuleContext;Trusted_Connection=True;TrustServerCertificate=True;");

            return new ModuleContext(optionsBuilder.Options);
        }
    }
}
