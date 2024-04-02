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
    public async Task<ActionResult<IEnumerable<Ingredient>>> Get(string name, string recipe)
    {
      IQueryable<Ingredient> query = _db.Ingredients.AsQueryable();
      if (name != null)
      {
        query = query.Where(e => e.Name == name);
      }
      if (recipe != null)
      {
        query = query.Where(e => e.RecipeIngredients.Any(ri => ri.Recipe.Title == recipe));
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredients(int id)
    {
      Ingredient ing = await _db.Ingredients
        .Include(ri => ri.RecipeIngredients)
        .ThenInclude(join => join.Recipe)
        .FirstOrDefaultAsync(ri => ri.IngredientId == id);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Ingredient ing)
    {
      if (id != ing.IngredientId)
      {
        return BadRequest();
      }
      _db.Ingredients.Update(ing);
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!IngredientExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    private bool IngredientExists(int id)
    {
      return _db.Ingredients.Any(e => e.IngredientId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(int id)
    {
      Ingredient ing = await _db.Ingredients.FindAsync(id);
      if (ing == null)
      {
        return NotFound();
      }
      _db.Ingredients.Remove(ing);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}