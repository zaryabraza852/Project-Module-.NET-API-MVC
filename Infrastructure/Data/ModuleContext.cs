using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ModuleContext : DbContext
    {

      
        public ModuleContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        //    }
        //}
        public DbSet<Module> ProjectModules { get; set; }

    }
}
