using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccesLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-01QE6IC;database=CoreAPIDemo; integrated security=true;");
        }
        public DbSet<Employe> Employess { get; set; }
    }
}
