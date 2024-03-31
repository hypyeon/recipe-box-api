using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBoxApi.Models;

namespace RecipeBoxApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly RecipeBoxApiContext _db;

    public CategoriesController(RecipeBoxApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> Get(string name)
    {
      IQueryable<Category> query = _db.Categories.AsQueryable();
      if (name != null)
      {
        query = query.Where(e => e.Name == name);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
      Category cat = await _db.Categories
        .Include(c => c.Recipes)
        .FirstOrDefaultAsync(c => c.CategoryId == id);
      if (cat == null)
      {
        return NotFound();
      }
      return cat;
    }
  }
}