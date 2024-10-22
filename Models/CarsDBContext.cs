using Microsoft.EntityFrameworkCore;

namespace Unit_2_Project.Models
{
    public class CarsDBContext : DbContext
    {
        //Load DbContext for the rest of the class
        public CarsDBContext(DbContextOptions<CarsDBContext> options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cars>().HasData(
                new Cars
                {
                    Id = 1,
                    Make = "Mitsubishi",
                    Model = "Lancer Evolution",
                    Year = 2006
                },
                new Cars
                {
                    Id = 2,
                    Make = "Acura",
                    Model = "RL",
                    Year = 2008
                },
                new Cars
                {
                    Id = 3,
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 1969
                }
                );
        }

    }
}
