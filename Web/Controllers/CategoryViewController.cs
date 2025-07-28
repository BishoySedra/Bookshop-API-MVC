using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Models.Entities;
using Web.ViewModels.Category;

namespace Web.Controllers
{
    public class CategoryViewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryViewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var category = new Category
            {
                catName = model.CatName,
                catOrder = model.CatOrder
            };

            _unitOfWork.Categories.Add(category);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var category = await _unitOfWork.Categories.GetByIdAsync(model.Id);
            if (category == null) return NotFound();

            category.catName = model.catName;
            category.catOrder = model.catOrder;

            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return NotFound();

            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return NotFound();
            return PartialView("EditPartial", category);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsPartial(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return NotFound();
            return PartialView("DetailsPartial", category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var category = await _unitOfWork.Categories.GetByIdAsync(model.Id);
            if (category == null) return NotFound();

            category.catName = model.catName;
            category.catOrder = model.catOrder;
            category.markedAsDeleted = model.markedAsDeleted;

            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
