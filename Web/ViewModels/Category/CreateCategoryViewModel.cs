using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name")]
        public string CatName { get; set; }

        [Required(ErrorMessage = "Category order is required")]
        [Display(Name = "Category Order")]
        public int CatOrder { get; set; }
    }
}
