using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Entities;

namespace Web.Controllers
{
	public class ProductViewController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductViewController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
		}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DetailsPartial(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return PartialView("_DetailsPartial", product);
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            var categories = await _context.Categories.ToListAsync();

            var viewModel = new EditProductViewModel
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Author = product.Author,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return PartialView("_EditPartial", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPartial(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_EditPartial", model);
            }

            var product = await _context.Products.FindAsync(model.Id);
            if (product == null) return NotFound();

            product.Title = model.Title;
            product.Description = model.Description;
            product.Author = model.Author;
            product.Price = model.Price;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.ToListAsync();

            ViewBag.CategoryList = new SelectList(categories, "Id", "catName");

            // Return empty Product object so view still uses @model Product
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _context.Categories.ToListAsync();
                ViewBag.CategoryList = new SelectList(categories, "Id", "catName", model.CategoryId);

                // Returning Product entity so view model stays the same
                return View(new Product
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = model.Author,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                });
            }

            var product = new Product
            {
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
