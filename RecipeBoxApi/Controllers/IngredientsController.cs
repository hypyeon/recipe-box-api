using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBoxApi.Models;

namespace RecipeBoxApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class IngredientsController : ControllerBase
  {
    private readonly RecipeBoxApiContext _db;

    public IngredientsController(RecipeBoxApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> Get()
    {
      return await _db.Ingredients.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredients(int id)
    {
      Ingredient ing = await _db.Ingredients.FindAsync(id);
      if (ing == null)
      {
        return NotFound();
      }
      return ing;
    }

    [HttpPost]
    public async Task<ActionResult<Ingredient>> Post(Ingredient ing)
    {
      _db.Ingredients.Add(ing);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetIngredients), new { id = ing.IngredientId }, ing);
    }
  }
}