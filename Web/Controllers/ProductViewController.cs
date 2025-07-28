using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Entities;
using Core.Interfaces;

namespace Web.Controllers
{
	public class ProductViewController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;

		public ProductViewController(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
            var products = await _unitOfWork.Products.GetAllWithCategoriesAsync();
            return View(products);
		}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Products.Remove(product);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DetailsPartial(int id)
        {
            var product = await _unitOfWork.Products.GetByIdWithCategoryAsync(id);

            if (product == null)
                return NotFound();

            return PartialView("DetailsPartial", product);
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            ViewBag.CategoryList = new SelectList(await _unitOfWork.Categories.GetAllAsync(), "Id", "catName", product.CategoryId);

            return PartialView("EditPartial", product);
        }

        [HttpPost]
        public async Task<IActionResult> EditPartial(Product model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryList = new SelectList(await _unitOfWork.Products.GetAllAsync(), "Id", "catName", model.CategoryId);
                return PartialView("EditPartial", model);
            }

            var product = await _unitOfWork.Products.GetByIdAsync(model.Id);
            if (product == null) return NotFound();

            product.Title = model.Title;
            product.Description = model.Description;
            product.Author = model.Author;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

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
                var categories = await _unitOfWork.Categories.GetAllAsync();
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

            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
