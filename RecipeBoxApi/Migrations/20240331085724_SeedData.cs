using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBoxApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
