using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
