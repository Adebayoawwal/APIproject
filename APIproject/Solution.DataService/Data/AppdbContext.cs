using Microsoft.EntityFrameworkCore;
using Solution.Enitities.dbSet;

namespace Solution.DataService.Data
{
    public class AppdbContext: DbContext
    {
        public virtual DbSet<Driver> Drivers{get; set;}
        public virtual DbSet<Achievement> Achievements {get; set;}

        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options) 
         { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }


    }
}

