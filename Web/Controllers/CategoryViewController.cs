using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Models.Entities;
using Web.ViewModels.Category;

namespace Web.Controllers
{
    public class CategoryViewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryViewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
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
            {
                return View(model);
            }

            var category = new Category
            {
                catName = model.CatName,
                catOrder = model.CatOrder
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
