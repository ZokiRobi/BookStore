using ElanBookStore.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElanBookStore.ViewModels
{
    public class BookViewModel
    {
        public Guid BookID { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"[0-9]{3}-[0-9]{2}-[0-9]{4}-[0-9]{3}-[0-9]{1}", ErrorMessage = "ISBN number must be in format: xxx-xx-xxxx-xxx-x")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MaxLength(256)]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        public BookViewModel()
        {

        }
        public BookViewModel(Book book)
        {
            ISBN = book.ISBN;
            Title = book.Title;
            Author = book.Author;
            Genre = book.Genre;
            BookID = book.BookID;
        }
    }
}