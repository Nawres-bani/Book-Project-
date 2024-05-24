using Bookproj.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookproj.Controllers
{
    public class GenresController : Controller
    {

    
           OnlineLibraryDbContext _context;

    public GenresController(OnlineLibraryDbContext context)
    {
        _context = context;
    }
    
        // GET: GenreController
        public ActionResult Index()
        {
            // get all genres from the database
            List<Genre> genres = _context.Genres.ToList();


            return View(genres);
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            // get the genre with the given id

            Genre genre = _context.Genres.FirstOrDefault(g => g.Id == id);
            return View(genre);
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            // get the genre with the given id from the database
            Genre genre = new Genre();
           List<Genre> genres = _context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Genres = genres;



            return View(genre);
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            try
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            // get the genre with the given id from the database
            Genre genre = _context.Genres.FirstOrDefault(g => g.Id == id);
                
            return View(genre);
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Genre genre)
        {
            try
            {
                _context.Genres.Update(genre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            // get the genre with the given id from the database
            Genre genre = _context.Genres.FirstOrDefault(g => g.Id == id);
            return View();
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Genre genre)
        {
            try
            {
                _context.Genres.Remove(genre);
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


