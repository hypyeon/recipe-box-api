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

    [HttpPost("{recipeId}/AddIngredient")]
    public async Task<IActionResult> AddIngredient(int recipeId, int ingredientId)
    {
      Recipe recipe = await _db.Recipes.FindAsync(recipeId);
      if (recipe == null)
      {
        return NotFound("Recipe not found");
      }
      Ingredient ing = await _db.Ingredients.FindAsync(ingredientId);
      if (ing == null)
      {
        return NotFound("Ingredient not found");
      }
      if (!recipe.RecipeIngredients.Any(ri => ri.IngredientId == ingredientId))
      {
        recipe.RecipeIngredients.Add(new RecipeIngredient { IngredientId = ingredientId });
        await _db.SaveChangesAsync();
      }
      return Ok(recipe);
    }
    /*
    [HttpPost("{recipeId}/RemoveIngredient")]
    public async Task<IActionResult> RemoveIngredient(int recipeId, int ingredientId)
    {
      Recipe recipe = await _db.Recipes.FindAsync(recipeId);
      if (recipe == null)
      {
        return NotFound("Recipe not found");
      }
      RecipeIngredient ri = recipe.RecipeIngredients.FirstOrDefault(ri => ri.IngredientId == ingredientId);
      if (ri != null)
      {
        _db.RecipeIngredients.Remove(ri);
        await _db.SaveChangesAsync();
      }
      return Ok(recipe);
    }
    */
    [HttpDelete("DeleteJoin/{recipeId}/{ingredientId}")]
    public async Task<IActionResult> DeleteJoin(int recipeId, int ingredientId)
    {
      RecipeIngredient entry = await _db.RecipeIngredients.FirstOrDefaultAsync(e => e.RecipeId == recipeId && e.IngredientId == ingredientId);
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