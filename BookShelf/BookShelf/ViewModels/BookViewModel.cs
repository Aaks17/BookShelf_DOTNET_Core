using BookShelf.Models;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter the Book Name")]
        [Display(Name = "Book Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the Book Summary")]
        [Display(Name = "Book Summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Please specify the Author")]
        [Display(Name = "Author")]
        public Author Author { get; set; }

        [Required(ErrorMessage = "Please specify a Book Category")]
        [Display(Name = "Book Category")]
        public Category Category { get; set; }
    }
}
