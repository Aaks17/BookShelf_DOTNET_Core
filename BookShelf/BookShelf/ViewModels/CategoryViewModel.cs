using System.ComponentModel.DataAnnotations;

namespace BookShelf.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter the Category Name")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Required(ErrorMessage ="Please enter the display order")]
        public int DisplayOrder { get; set; }

    }
}
