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
    public async Task<ActionResult<IEnumerable<Recipe>>> Get(int catId, string title, string ing)
    {
      IQueryable<Recipe> query = _db.Recipes.AsQueryable();
      if (catId > 0)
      {
        query = query.Where(e => e.CategoryId == catId);
      }
      if (title != null)
      {
        query = query.Where(e => e.Title == title);
      }
      if (ing != null)
      {
        query = query.Where(e => e.RecipeIngredients.Any(ri => ri.Ingredient.Name == ing));
      }
      return await query.ToListAsync();
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

    [HttpPost("AddIngredient")]
    public async Task<IActionResult> AddIngredient(Recipe recipe, int ingredientId)
    {
      #nullable enable
      RecipeIngredient? join = await _db.RecipeIngredients
        .FirstOrDefaultAsync(ri => ri.IngredientId == ingredientId && ri.RecipeId == recipe.RecipeId );
      #nullable disable

      if (join == null && ingredientId != 0)
      {
        _db.RecipeIngredients.Add(new RecipeIngredient ()
        {
          IngredientId = ingredientId, RecipeId = recipe.RecipeId
        });
        await _db.SaveChangesAsync();
      }
      return NoContent();
    }
    [HttpDelete("DeleteJoin/{id}")]
    public async Task<IActionResult> DeleteJoin(int recipeId, int ingredientId)
    {
      RecipeIngredient entry = await _db.RecipeIngredients.
        FirstOrDefaultAsync(
          e => e.RecipeId == recipeId && e.IngredientId == ingredientId
        );
      if (entry != null)
      {
        _db.RecipeIngredients.Remove(entry);
        await _db.SaveChangesAsync();
        return Ok();
      }
      return NotFound();
    }
  }
}