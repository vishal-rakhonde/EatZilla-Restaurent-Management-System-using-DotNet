 using EatZilla.Models.CoreClasses;

using Microsoft.EntityFrameworkCore;
namespace EatZilla.Models.DataConnection
{
    public class ApplicationDatabaseContext :DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext>options) :base(options) 
        {
            
        }
      public  DbSet<User> Users { get; set; }
      public    DbSet<Resturant> resturants { get; set; }
      public    DbSet<Dish> dishes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Resturant>().HasData(
                new Resturant { Rid = 101, Name = "Taksh", type = "Veg" },
                new Resturant { Rid = 102, Name = "Nadbrhma", type = "Snacks" },
                new Resturant { Rid = 103, Name = "Mataji", type = "Sweet" },
                new Resturant { Rid = 104, Name = "Ashirwad", type = "NonVeg" }
            );
            modelBuilder.Entity<Dish>().HasData(
             new Dish { DishId = 1,Name = "Biryani",price=220},
             new Dish { DishId = 2, Name = "Dal-Khichadi", price = 120 },
             new Dish { DishId = 3, Name = "Rice-plate", price = 150 },
             new Dish { DishId = 4, Name = "Chicken-Thali", price = 300 },
             new Dish { DishId = 5, Name = "Panner", price = 180 }
       

           );
        }
        public DbSet<EatZilla.Models.CoreClasses.Admin> Admin { get; set; } = default!;


    }
}
