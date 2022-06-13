using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter the Category Name")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Required(ErrorMessage = "Please enter the display order")]
        public int DisplayOrder { get; set; }
        [ValidateNever]
        public ICollection<Book> Book { get; set; }

    }
}
