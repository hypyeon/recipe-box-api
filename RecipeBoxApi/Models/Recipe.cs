namespace RecipeBoxApi.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    public string Title { get; set; }
    public string Instruction { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }
  }
}