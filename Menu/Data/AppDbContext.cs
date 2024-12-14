using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredients>().HasKey(di => new
            {
                di.DishID,
                di.IngredientsID
            });
            modelBuilder.Entity<DishIngredients>().HasOne(d=>d.Dish).WithMany(di =>di.DishIngredients).HasForeignKey(d=>d.DishID);
            modelBuilder.Entity<DishIngredients>().HasOne(i=>i.Ingredients).WithMany(i =>i.DishIngredients).HasForeignKey(i=>i.IngredientsID);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margheritta" , Price = 7.50, ImageUrl = "https://bakewithzoha.com/wp-content/uploads/2023/08/pizza-margherita-featured.jpg" }
                );
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { Id = 1, Name = "Tomato Sauce"},
                new Ingredients { Id = 2, Name = "Mozzarella"}
                );
            modelBuilder.Entity<DishIngredients>().HasData(
                new DishIngredients { DishID = 1, IngredientsID = 1},
                new DishIngredients { DishID = 1, IngredientsID = 2}
                );

            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<DishIngredients> DishIngredients { get; set; }
    }
    
}
