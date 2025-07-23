using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            // Fetch all categories from the database asynchronously
            var categories = await _context.Categories.ToListAsync();

            // Return the list of categories
            return Ok(categories);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            // Validate the incoming category object
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            // Add the new category to the database
            _context.Categories.Add(category);

            // Save changes asynchronously
            await _context.SaveChangesAsync();

            // Return the created category with a 201 Created response
            return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id }, category);
        }
    }
}
