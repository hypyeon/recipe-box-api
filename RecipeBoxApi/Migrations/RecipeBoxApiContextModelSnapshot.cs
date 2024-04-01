﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeBoxApi.Models;

#nullable disable

namespace RecipeBoxApi.Migrations
{
    [DbContext(typeof(RecipeBoxApiContext))]
    partial class RecipeBoxApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RecipeBoxApi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Main Course"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Side Dish"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Dessert"
                        });
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("FavoriteId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Name = "Chicken breasts"
                        },
                        new
                        {
                            IngredientId = 2,
                            Name = "Rice"
                        },
                        new
                        {
                            IngredientId = 3,
                            Name = "Pasta"
                        },
                        new
                        {
                            IngredientId = 4,
                            Name = "Tomatoes"
                        },
                        new
                        {
                            IngredientId = 5,
                            Name = "Onions"
                        },
                        new
                        {
                            IngredientId = 6,
                            Name = "Garlic"
                        },
                        new
                        {
                            IngredientId = 7,
                            Name = "Bell peppers"
                        },
                        new
                        {
                            IngredientId = 8,
                            Name = "Spinach"
                        },
                        new
                        {
                            IngredientId = 9,
                            Name = "Beef mince"
                        },
                        new
                        {
                            IngredientId = 10,
                            Name = "Potatoes"
                        },
                        new
                        {
                            IngredientId = 11,
                            Name = "Carrots"
                        },
                        new
                        {
                            IngredientId = 12,
                            Name = "Broccoli"
                        },
                        new
                        {
                            IngredientId = 13,
                            Name = "Eggs"
                        },
                        new
                        {
                            IngredientId = 14,
                            Name = "Milk"
                        },
                        new
                        {
                            IngredientId = 15,
                            Name = "Flour"
                        },
                        new
                        {
                            IngredientId = 16,
                            Name = "Sugar"
                        },
                        new
                        {
                            IngredientId = 17,
                            Name = "Salt"
                        },
                        new
                        {
                            IngredientId = 18,
                            Name = "Black pepper"
                        },
                        new
                        {
                            IngredientId = 19,
                            Name = "Olive oil"
                        },
                        new
                        {
                            IngredientId = 20,
                            Name = "Soy sauce"
                        });
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RecipeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            CategoryId = 1,
                            Instruction = "Grill chicken and cook rice. Serve together with olive oil, salt, and black pepper.",
                            Title = "Grilled Chicken with Rice"
                        },
                        new
                        {
                            RecipeId = 2,
                            CategoryId = 1,
                            Instruction = "Cook pasta. Brown beef mince, onions, and garlic. Add tomatoes and simmer. Serve over cooked pasta.",
                            Title = "Spaghetti Bolognese"
                        },
                        new
                        {
                            RecipeId = 3,
                            CategoryId = 1,
                            Instruction = "Cook pasta. Sauté garlic in olive oil, then add diced tomatoes and basil. Toss with cooked pasta.",
                            Title = "Tomato and Basil Pasta"
                        },
                        new
                        {
                            RecipeId = 4,
                            CategoryId = 1,
                            Instruction = "Sauté onions, garlic, and bell peppers. Add curry powder and coconut milk. Simmer with diced chicken until cooked through.",
                            Title = "Chicken Curry"
                        },
                        new
                        {
                            RecipeId = 5,
                            CategoryId = 1,
                            Instruction = "Stir-fry beef mince with onions, bell peppers, and garlic. Add soy sauce and cook until beef is browned.",
                            Title = "Beef Stir-Fry"
                        },
                        new
                        {
                            RecipeId = 6,
                            CategoryId = 1,
                            Instruction = "Cook rice. Sauté carrots, bell peppers, and onions. Add cooked rice and eggs, then stir in soy sauce.",
                            Title = "Vegetable Fried Rice"
                        },
                        new
                        {
                            RecipeId = 7,
                            CategoryId = 1,
                            Instruction = "Brown beef mince. Add onions, carrots, and potatoes. Pour in beef broth and simmer until vegetables are tender.",
                            Title = "Beef Stew with Potatoes and Carrots"
                        },
                        new
                        {
                            RecipeId = 8,
                            CategoryId = 1,
                            Instruction = "Whisk eggs with milk, salt, and black pepper. Cook spinach and tomatoes, then pour in egg mixture and cook until set.",
                            Title = "Spinach and Tomato Omelette"
                        },
                        new
                        {
                            RecipeId = 9,
                            CategoryId = 1,
                            Instruction = "Steam broccoli. Make a cheese sauce with milk, flour, and butter. Mix with cooked broccoli and bake until bubbly.",
                            Title = "Broccoli and Cheese Casserole"
                        },
                        new
                        {
                            RecipeId = 10,
                            CategoryId = 2,
                            Instruction = "Cut potatoes into cubes. Toss with olive oil, minced garlic, salt, and pepper. Roast in the oven until crispy and golden brown.",
                            Title = "Garlic Roasted Potatoes"
                        },
                        new
                        {
                            RecipeId = 11,
                            CategoryId = 2,
                            Instruction = "Slice bell peppers, zucchini, and eggplant. Grill until tender. Serve with a drizzle of balsamic glaze.",
                            Title = "Grilled Vegetable Platter"
                        },
                        new
                        {
                            RecipeId = 12,
                            CategoryId = 2,
                            Instruction = "Boil potatoes until tender. Mash with butter, milk, salt, and pepper until smooth and creamy.",
                            Title = "Creamy Mashed Potatoes"
                        },
                        new
                        {
                            RecipeId = 13,
                            CategoryId = 2,
                            Instruction = "Toss carrots with olive oil, honey, and thyme. Roast in the oven until caramelized and tender.",
                            Title = "Roasted Carrots with Honey Glaze"
                        },
                        new
                        {
                            RecipeId = 14,
                            CategoryId = 2,
                            Instruction = "Slice cucumbers and tomatoes. Toss with olive oil, red wine vinegar, salt, pepper, and chopped fresh herbs.",
                            Title = "Cucumber Tomato Salad"
                        },
                        new
                        {
                            RecipeId = 15,
                            CategoryId = 3,
                            Instruction = "Cream butter and sugar. Mix in eggs, flour, and chocolate chips. Drop spoonfuls onto a baking sheet and bake until golden brown.",
                            Title = "Chocolate Chip Cookies"
                        },
                        new
                        {
                            RecipeId = 16,
                            CategoryId = 3,
                            Instruction = "Make pie crust. Fill with sliced apples, sugar, and cinnamon. Top with another pie crust and bake until golden brown.",
                            Title = "Classic Apple Pie"
                        },
                        new
                        {
                            RecipeId = 17,
                            CategoryId = 3,
                            Instruction = "Mix chocolate and butter, then add eggs, sugar, and flour. Bake until the edges are set but the center is still gooey.",
                            Title = "Chocolate Lava Cake"
                        });
                });

            modelBuilder.Entity("RecipeBoxApi.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeIngredientId")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Favorite", b =>
                {
                    b.HasOne("RecipeBoxApi.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeBoxApi.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Recipe", b =>
                {
                    b.HasOne("RecipeBoxApi.Models.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.RecipeIngredient", b =>
                {
                    b.HasOne("RecipeBoxApi.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeBoxApi.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Ingredient", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("RecipeBoxApi.Models.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
