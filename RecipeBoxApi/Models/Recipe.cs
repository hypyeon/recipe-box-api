using System.ComponentModel.DataAnnotations;

namespace RecipeBoxApi.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    [Required]
    [StringLength(30)]
    public string Title { get; set; }
    [Required]
    public string Instruction { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }
  }
}