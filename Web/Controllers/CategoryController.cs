using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Models.Entities;
using Web.Responses;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoints to manage book categories.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves all categories including their related products.
        /// </summary>
        /// <returns>A list of categories with related products.</returns>
        /// <response code="200">Returns the list of categories</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<Category>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<List<Category>>>> GetAllCategories()
        {
            var categories = await _unitOfWork.Categories.GetAllWithProductsAsync();
            return Ok(ApiResponse<List<Category>>.Success(categories));
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="category">The category object to create.</param>
        /// <returns>The created category object.</returns>
        /// <response code="201">Returns the newly created category</response>
        /// <response code="400">If the category is null or invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Category>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Category>>> CreateCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest(ApiResponse<string>.Fail("Invalid category data"));
            }

            _unitOfWork.Categories.Add(category);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id },
                ApiResponse<Category>.Success(category, "Category created", 201));
        }
    }
}
