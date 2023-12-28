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

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            base.OnModelCreating(optionsBuilder);
            optionsBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(d => d.Driver)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FX_Achievements_Driver");
            });
        }


    }
}

