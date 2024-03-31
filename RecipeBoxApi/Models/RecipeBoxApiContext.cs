using Microsoft.EntityFrameworkCore;

namespace RecipeBoxApi.Models
{
  public class RecipeBoxApiContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    // Add DbSet for ApplicationUser if it's not already included
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public RecipeBoxApiContext(DbContextOptions<RecipeBoxApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<RecipeIngredient>()
          .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

      modelBuilder.Entity<RecipeIngredient>()
          .HasOne(ri => ri.Recipe)
          .WithMany(r => r.RecipeIngredients)
          .HasForeignKey(ri => ri.RecipeId);

      modelBuilder.Entity<RecipeIngredient>()
          .HasOne(ri => ri.Ingredient)
          .WithMany(i => i.RecipeIngredients)
          .HasForeignKey(ri => ri.IngredientId);
    }
  }
}
