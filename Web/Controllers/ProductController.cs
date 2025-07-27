using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Web.Responses;
using Web.DTOs;

namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : Controller
    {
       private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ProductDto>>>> GetAllProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Author = p.Author,
                    Price = p.Price,
                    CategoryName = p.Category.catName
                })
                .ToListAsync();

            return Ok(ApiResponse<List<ProductDto>>.Success(products));
        }



        [HttpPost]
        public async Task<ActionResult<ApiResponse<Product>>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, ApiResponse<Product>.Success(product, "Product created", 201));
        }
    }

}
