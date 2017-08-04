using ElanBookStore.Models;
using ElanBookStore.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace ElanBookStore.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index(string order, int page = 1)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = db.Books.ToList().OrderBy(x => x.Title).ToPagedList(page, 5);
                switch (order)
                {
                    case "ISBN":
                        model = db.Books.ToList().OrderBy(x => x.ISBN).ToPagedList(page, 5);
                        break;
                    case "Title":
                        model = db.Books.ToList().OrderBy(x => x.Title).ToPagedList(page, 5);
                        break;
                    case "Author":
                        model = db.Books.ToList().OrderBy(x => x.Author).ToPagedList(page, 5);
                        break;
                    case "Genre":
                        model = db.Books.ToList().OrderBy(x => x.Genre).ToPagedList(page, 5);
                        break;
                    default:
                        break;
                }
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Table", model);
                }
                return View(model);
            }

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Book book = new Book(model);
                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(Guid id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var book = db.Books.FirstOrDefault(x => x.BookID == id);
                if (book != null)
                {
                    var model = new BookViewModel(book);
                    return PartialView("_ModalPartial", model);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Guid id, BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var bookdto = db.Books.FirstOrDefault(x => x.BookID == id);
                if (bookdto != null)
                {
                    bookdto.Author = model.Author;
                    bookdto.Title = model.Title;
                    bookdto.ISBN = model.ISBN;
                    bookdto.Genre = model.Genre;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(Guid id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var book = db.Books.FirstOrDefault(x => x.BookID == id);

                if (book != null)
                {
                    book.IsDeleted = true;
                    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}