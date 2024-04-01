using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBoxApi.Models;

namespace RecipeBoxApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FavoritesController : ControllerBase
  {
    private readonly RecipeBoxApiContext _db;

    public FavoritesController(RecipeBoxApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Favorite>>> Get()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var favorites = await _db.Favorites
        .Where(f => f.UserId == userId)
        .ToListAsync();
      return Ok(favorites);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Favorite>> GetFavorite(int id)
    {
      Favorite fav = await _db.Favorites.FindAsync(id);
      if (fav == null)
      {
        return NotFound();
      }
      return fav;
    }

    [HttpPost]
    public async Task<ActionResult<Favorite>> AddFavorite(int recipeId, string userId)
    {
      Recipe recipe = await _db.Recipes.FindAsync(recipeId);
      if (recipe == null)
      {
        return NotFound("Recipe not found");
      }

      ApplicationUser user = await _db.ApplicationUsers.FindAsync(userId);
      if (user == null)
      {
        return NotFound("User not found");
      }

      Favorite existingFavorite = await _db.Favorites.FirstOrDefaultAsync(f => f.RecipeId == recipeId && f.UserId == userId);
      if (existingFavorite != null)
      {
        return Conflict("Recipe is already in favorites");
      }
      Favorite fav = new Favorite { IsFavorite = true, RecipeId = recipeId, UserId = userId };
      _db.Favorites.Add(fav);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetFavorite), new { id = fav.FavoriteId }, fav);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFavorite(int id)
    {
      Favorite fav = await _db.Favorites.FindAsync(id);
      if (fav == null)
      {
        return NotFound("Favorite not found");
      }
      _db.Favorites.Remove(fav);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}