using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Models.Entities;
using Web.Responses;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Category>>>> GetAllCategories()
        {
            var categories = await _unitOfWork.Categories.GetAllWithProductsAsync();
            return Ok(ApiResponse<List<Category>>.Success(categories));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Category>>> CreateCategory(Category category)
        {
            _unitOfWork.Categories.Add(category);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id },
                ApiResponse<Category>.Success(category, "Category created", 201));
        }
    }
}
