using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter the Author Name")]
        [Display(Name = "Author Name")]
        public string Name { get; set; }
        [ValidateNever]
        public ICollection<Book> Book{ get; set; }
    }
}
