using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Web.Responses;
using Web.DTOs;
using Core.Interfaces;

namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ProductDto>>>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllWithCategoriesAsync();

            return Ok(ApiResponse<List<ProductDto>>.Success(products.Select(p => new ProductDto
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                CategoryName = p.Category?.catName
            }).ToList(), "Products retrieved successfully"));
        }



        [HttpPost]
        public async Task<ActionResult<ApiResponse<Product>>> CreateProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id },
                               ApiResponse<Product>.Success(product, "Product created successfully", 201));
        }
    }

}
