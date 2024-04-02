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
      /*modelBuilder.Entity<RecipeIngredient>()
        .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

      modelBuilder.Entity<RecipeIngredient>()
        .HasOne(ri => ri.Recipe)
        .WithMany(r => r.RecipeIngredients)
        .HasForeignKey(ri => ri.RecipeId);

      modelBuilder.Entity<RecipeIngredient>()
        .HasOne(ri => ri.Ingredient)
        .WithMany(i => i.RecipeIngredients)
        .HasForeignKey(ri => ri.IngredientId);*/

      modelBuilder.Entity<Category>()
        .HasData(
            new Category { CategoryId = 1, Name = "Main Course" },
            new Category { CategoryId = 2, Name = "Side Dish" },
            new Category { CategoryId = 3, Name = "Dessert" }
        );

      modelBuilder.Entity<Ingredient>()
        .HasData(
          new Ingredient { IngredientId = 1, Name = "Chicken breasts" },
          new Ingredient { IngredientId = 2, Name = "Rice" },
          new Ingredient { IngredientId = 3, Name = "Pasta" },
          new Ingredient { IngredientId = 4, Name = "Tomatoes" },
          new Ingredient { IngredientId = 5, Name = "Onions" },
          new Ingredient { IngredientId = 6, Name = "Garlic" },
          new Ingredient { IngredientId = 7, Name = "Bell peppers" },
          new Ingredient { IngredientId = 8, Name = "Spinach" },
          new Ingredient { IngredientId = 9, Name = "Beef mince" },
          new Ingredient { IngredientId = 10, Name = "Potatoes" },
          new Ingredient { IngredientId = 11, Name = "Carrots" },
          new Ingredient { IngredientId = 12, Name = "Broccoli" },
          new Ingredient { IngredientId = 13, Name = "Eggs" },
          new Ingredient { IngredientId = 14, Name = "Milk" },
          new Ingredient { IngredientId = 15, Name = "Flour" },
          new Ingredient { IngredientId = 16, Name = "Sugar" },
          new Ingredient { IngredientId = 17, Name = "Salt" },
          new Ingredient { IngredientId = 18, Name = "Black pepper" },
          new Ingredient { IngredientId = 19, Name = "Olive oil" },
          new Ingredient { IngredientId = 20, Name = "Soy sauce" }
        );
      modelBuilder.Entity<Recipe>()
        .HasData(
          new Recipe { RecipeId = 1, Title = "Grilled Chicken with Rice", Instruction = "Grill chicken and cook rice. Serve together with olive oil, salt, and black pepper.", CategoryId = 1 },
          new Recipe { RecipeId = 2, Title = "Spaghetti Bolognese", Instruction = "Cook pasta. Brown beef mince, onions, and garlic. Add tomatoes and simmer. Serve over cooked pasta.", CategoryId = 1 },
          new Recipe { RecipeId = 3, Title = "Tomato and Basil Pasta", Instruction = "Cook pasta. Sauté garlic in olive oil, then add diced tomatoes and basil. Toss with cooked pasta.", CategoryId = 1 },
          new Recipe { RecipeId = 4, Title = "Chicken Curry", Instruction = "Sauté onions, garlic, and bell peppers. Add curry powder and coconut milk. Simmer with diced chicken until cooked through.", CategoryId = 1 },
          new Recipe { RecipeId = 5, Title = "Beef Stir-Fry", Instruction = "Stir-fry beef mince with onions, bell peppers, and garlic. Add soy sauce and cook until beef is browned.", CategoryId = 1 },
          new Recipe { RecipeId = 6, Title = "Vegetable Fried Rice", Instruction = "Cook rice. Sauté carrots, bell peppers, and onions. Add cooked rice and eggs, then stir in soy sauce.", CategoryId = 1 },
          new Recipe { RecipeId = 7, Title = "Beef Stew with Potatoes and Carrots", Instruction = "Brown beef mince. Add onions, carrots, and potatoes. Pour in beef broth and simmer until vegetables are tender.", CategoryId = 1 },
          new Recipe { RecipeId = 8, Title = "Spinach and Tomato Omelette", Instruction = "Whisk eggs with milk, salt, and black pepper. Cook spinach and tomatoes, then pour in egg mixture and cook until set.", CategoryId = 1 },
          new Recipe { RecipeId = 9, Title = "Broccoli and Cheese Casserole", Instruction = "Steam broccoli. Make a cheese sauce with milk, flour, and butter. Mix with cooked broccoli and bake until bubbly.", CategoryId = 1 },
          new Recipe { RecipeId = 10, Title = "Garlic Roasted Potatoes", Instruction = "Cut potatoes into cubes. Toss with olive oil, minced garlic, salt, and pepper. Roast in the oven until crispy and golden brown.", CategoryId = 2 },
          new Recipe { RecipeId = 11, Title = "Grilled Vegetable Platter", Instruction = "Slice bell peppers, zucchini, and eggplant. Grill until tender. Serve with a drizzle of balsamic glaze.", CategoryId = 2 },
          new Recipe { RecipeId = 12, Title = "Creamy Mashed Potatoes", Instruction = "Boil potatoes until tender. Mash with butter, milk, salt, and pepper until smooth and creamy.", CategoryId = 2 },
          new Recipe { RecipeId = 13, Title = "Roasted Carrots with Honey Glaze", Instruction = "Toss carrots with olive oil, honey, and thyme. Roast in the oven until caramelized and tender.", CategoryId = 2 },
          new Recipe { RecipeId = 14, Title = "Cucumber Tomato Salad", Instruction = "Slice cucumbers and tomatoes. Toss with olive oil, red wine vinegar, salt, pepper, and chopped fresh herbs.", CategoryId = 2 },
          new Recipe { RecipeId = 15, Title = "Chocolate Chip Cookies", Instruction = "Cream butter and sugar. Mix in eggs, flour, and chocolate chips. Drop spoonfuls onto a baking sheet and bake until golden brown.", CategoryId = 3 },
          new Recipe { RecipeId = 16, Title = "Classic Apple Pie", Instruction = "Make pie crust. Fill with sliced apples, sugar, and cinnamon. Top with another pie crust and bake until golden brown.", CategoryId = 3 },
          new Recipe { RecipeId = 17, Title = "Chocolate Lava Cake", Instruction = "Mix chocolate and butter, then add eggs, sugar, and flour. Bake until the edges are set but the center is still gooey.", CategoryId = 3 }
        );
    }
  }
}
