using Microsoft.EntityFrameworkCore;
using tutorial_MVC.Models;

namespace tutorial_MVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(dishIngredientInstance => new {
                dishIngredientInstance.DishId,
                dishIngredientInstance.IngredientId
            });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(dishInstance => dishInstance.Dish)
                .WithMany(dishIngredientInstance => dishIngredientInstance.DishIngredients)
                .HasForeignKey(dishInstance => dishInstance.Dish);
            modelBuilder.Entity<DishIngredient>()
                .HasOne(dishInstance => dishInstance.Ingredient)
                .WithMany(dishIngredientInstance => dishIngredientInstance.DishIngredients)
                .HasForeignKey(dishInstance => dishInstance.IngredientId);

            modelBuilder.Entity<Dish>()
                .HasData(new Dish
                {
                    Id = 1,
                    Name = "Margharita",
                    ImgUrl = "https://media-cdn.tripadvisor.com/media/photo-s/10/b1/0c/18/margharita.jpg",
                    Price = 3.99
                });
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1,Name = "Tomato Sauce"},
                new Ingredient { Id = 1, Name = "Mozzarela" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 }
    );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients {get; set;}
    }
}
