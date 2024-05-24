using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookproj.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookproj.Controllers
{
    public class BooksController : Controller
    {

        OnlineLibraryDbContext _context;

        public BooksController(OnlineLibraryDbContext context)
        {
            _context = context;
        }
        // GET: BooksController
        public ActionResult Index()
        {
            // get all books from the database
            List<Book> books = _context.Books.Include(b => b.Author).Include(b => b.Genre).ToList();
            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            // get the book with the given id
            Book book = _context.Books.Include(b => b.Author).Include(b => b.Genre).FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            Book book = new Book();
            List<Author> authors = _context.Authors.OrderBy(a => a.Name).ToList();
            List<Genre> genres = _context.Genres.OrderBy(g => g.Name).ToList();

            ViewBag.Authors = authors;
            ViewBag.Genres = genres;


            return View(book);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            // get the book with the given id
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            List<Author> authors = _context.Authors.OrderBy(a => a.Name).ToList();
            List<Genre> genres = _context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Authors = authors;
            ViewBag.Genres = genres;
            return View(book);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                _context.Books.Update(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            // get the book with the given id
            Book book = _context.Books.Include(b => b.Author).Include(b => b.Genre).FirstOrDefault(b => b.Id == id);

            return View(book);
           
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(b => b.Id == id);
                _context.Books.Remove(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
