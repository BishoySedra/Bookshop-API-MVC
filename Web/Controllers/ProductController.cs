using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Web.Responses;
using Web.DTOs;
using Core.Interfaces;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoints to manage products.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves all products with their category names.
        /// </summary>
        /// <returns>List of product DTOs with category names.</returns>
        /// <response code="200">Returns the list of products</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<ProductDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<List<ProductDto>>>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllWithCategoriesAsync();

            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Description = p.Description,
                Author = p.Author,
                CategoryName = p.Category?.catName
            }).ToList();

            return Ok(ApiResponse<List<ProductDto>>.Success(productDtos, "Products retrieved successfully"));
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product object to create.</param>
        /// <returns>The created product object.</returns>
        /// <response code="201">Returns the newly created product</response>
        /// <response code="400">If the product data is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Product>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Product>>> CreateProduct(Product product)
        {
            if (product == null)
                return BadRequest(ApiResponse<string>.Fail("Invalid product data"));

            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id },
                ApiResponse<Product>.Success(product, "Product created successfully", 201));
        }
    }
}
