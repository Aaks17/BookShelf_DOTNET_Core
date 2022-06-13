using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShelf.Models
{
    public class Book
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
        public int AuthorId { get; set; }

        [ValidateNever]
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [Required(ErrorMessage = "Please specify a Book Category")]
        [Display(Name = "Book Category")]
        public int CategoryId { get; set; }

        [ValidateNever]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
