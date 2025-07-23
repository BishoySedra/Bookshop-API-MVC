using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Web.Responses;

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

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Category>>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(ApiResponse<List<Category>>.Success(categories));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Category>>> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id },
                ApiResponse<Category>.Success(category, "Category created", 201));
        }
    }


}
