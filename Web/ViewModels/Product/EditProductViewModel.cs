using Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Product
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

    }
}