using System.Collections.Generic;

namespace RecipeBoxApi.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }
  }
}
