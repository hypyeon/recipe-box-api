using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBoxApi.Models;

namespace RecipeBoxApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RecipesController : ControllerBase
  {
    private readonly RecipeBoxApiContext _db;

    public RecipesController(RecipeBoxApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> Get()
    {
      return await _db.Recipes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetRecipe(int id)
    {
      Recipe recipe = await _db.Recipes.FindAsync(id);
      if (recipe == null)
      {
        return NotFound();
      }
      return recipe;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> Post(Recipe recipe)
    {
      _db.Recipes.Add(recipe);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetRecipe), new { id = recipe.RecipeId }, recipe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Recipe recipe)
    {
      if (id != recipe.RecipeId)
      {
        return BadRequest();
      }
      _db.Recipes.Update(recipe);
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RecipeExists(id))
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
    private bool RecipeExists(int id)
    {
      return _db.Recipes.Any(e => e.RecipeId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
      Recipe recipe = await _db.Recipes.FindAsync(id);
      if (recipe == null)
      {
        return NotFound();
      }
      _db.Recipes.Remove(recipe);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}