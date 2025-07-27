using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using Models.Entities;
using Web.ViewModels.Product;

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
		public IActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(products);
		}
	}
}
