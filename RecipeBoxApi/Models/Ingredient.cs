using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBoxApi.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    [Required]
    public string Name { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }
  }
}
