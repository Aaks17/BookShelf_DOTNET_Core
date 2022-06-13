using System.ComponentModel.DataAnnotations;

namespace BookShelf.ViewModels
{
    public class AuthorViewModel
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter the Author Name")]
        [Display(Name = "Author Name")]
        public string Name { get; set; }
    }
}
