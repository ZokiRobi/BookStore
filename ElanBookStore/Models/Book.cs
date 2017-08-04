using ElanBookStore.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElanBookStore.Models
{
    public class Book
    {
        [Key]
        public Guid BookID { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        public bool IsDeleted { get; set; }

        public Book()
        {

        }
        public Book(BookViewModel model)
        {
            BookID = Guid.NewGuid();
            ISBN = model.ISBN;
            Title = model.Title;
            Author = model.Author;
            Genre = model.Genre;
            IsDeleted = false;
        }

    }
}