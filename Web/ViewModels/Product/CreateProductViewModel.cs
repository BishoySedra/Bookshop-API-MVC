using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Product
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(50, ErrorMessage = "Title must not exceed 50 characters.")]
        public string Title { get; set; }

        [MaxLength(250, ErrorMessage = "Description must not exceed 250 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [MaxLength(50, ErrorMessage = "Author name must not exceed 50 characters.")]
        public string Author { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
