using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBoxApi.Migrations
{
    public partial class AddEverything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instruction = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsFavorite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favorites_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.RecipeIngredientId);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Main Course" },
                    { 2, "Side Dish" },
                    { 3, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name" },
                values: new object[,]
                {
                    { 1, "Chicken breasts" },
                    { 2, "Rice" },
                    { 3, "Pasta" },
                    { 4, "Tomatoes" },
                    { 5, "Onions" },
                    { 6, "Garlic" },
                    { 7, "Bell peppers" },
                    { 8, "Spinach" },
                    { 9, "Beef mince" },
                    { 10, "Potatoes" },
                    { 11, "Carrots" },
                    { 12, "Broccoli" },
                    { 13, "Eggs" },
                    { 14, "Milk" },
                    { 15, "Flour" },
                    { 16, "Sugar" },
                    { 17, "Salt" },
                    { 18, "Black pepper" },
                    { 19, "Olive oil" },
                    { 20, "Soy sauce" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CategoryId", "Instruction", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Grill chicken and cook rice. Serve together with olive oil, salt, and black pepper.", "Grilled Chicken with Rice" },
                    { 2, 1, "Cook pasta. Brown beef mince, onions, and garlic. Add tomatoes and simmer. Serve over cooked pasta.", "Spaghetti Bolognese" },
                    { 3, 1, "Cook pasta. Sauté garlic in olive oil, then add diced tomatoes and basil. Toss with cooked pasta.", "Tomato and Basil Pasta" },
                    { 4, 1, "Sauté onions, garlic, and bell peppers. Add curry powder and coconut milk. Simmer with diced chicken until cooked through.", "Chicken Curry" },
                    { 5, 1, "Stir-fry beef mince with onions, bell peppers, and garlic. Add soy sauce and cook until beef is browned.", "Beef Stir-Fry" },
                    { 6, 1, "Cook rice. Sauté carrots, bell peppers, and onions. Add cooked rice and eggs, then stir in soy sauce.", "Vegetable Fried Rice" },
                    { 7, 1, "Brown beef mince. Add onions, carrots, and potatoes. Pour in beef broth and simmer until vegetables are tender.", "Beef Stew with Potatoes and Carrots" },
                    { 8, 1, "Whisk eggs with milk, salt, and black pepper. Cook spinach and tomatoes, then pour in egg mixture and cook until set.", "Spinach and Tomato Omelette" },
                    { 9, 1, "Steam broccoli. Make a cheese sauce with milk, flour, and butter. Mix with cooked broccoli and bake until bubbly.", "Broccoli and Cheese Casserole" },
                    { 10, 2, "Cut potatoes into cubes. Toss with olive oil, minced garlic, salt, and pepper. Roast in the oven until crispy and golden brown.", "Garlic Roasted Potatoes" },
                    { 11, 2, "Slice bell peppers, zucchini, and eggplant. Grill until tender. Serve with a drizzle of balsamic glaze.", "Grilled Vegetable Platter" },
                    { 12, 2, "Boil potatoes until tender. Mash with butter, milk, salt, and pepper until smooth and creamy.", "Creamy Mashed Potatoes" },
                    { 13, 2, "Toss carrots with olive oil, honey, and thyme. Roast in the oven until caramelized and tender.", "Roasted Carrots with Honey Glaze" },
                    { 14, 2, "Slice cucumbers and tomatoes. Toss with olive oil, red wine vinegar, salt, pepper, and chopped fresh herbs.", "Cucumber Tomato Salad" },
                    { 15, 3, "Cream butter and sugar. Mix in eggs, flour, and chocolate chips. Drop spoonfuls onto a baking sheet and bake until golden brown.", "Chocolate Chip Cookies" },
                    { 16, 3, "Make pie crust. Fill with sliced apples, sugar, and cinnamon. Top with another pie crust and bake until golden brown.", "Classic Apple Pie" },
                    { 17, 3, "Mix chocolate and butter, then add eggs, sugar, and flour. Bake until the edges are set but the center is still gooey.", "Chocolate Lava Cake" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_RecipeId",
                table: "Favorites",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
