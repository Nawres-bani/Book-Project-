using Bookproj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookproj.Controllers
{
    public class BorrowingsController : Controller
    {

        OnlineLibraryDbContext _context;

        public BorrowingsController(OnlineLibraryDbContext context)
        {
            _context = context;
        }
        // GET: BorrowingsController
        public ActionResult Index()
        {
            // lister les emprunts
            List<Borrowing> borrowings = _context.Borrowings.ToList();
                

            return View(borrowings);
        }

        // GET: BorrowingsController/Details/5
        public ActionResult Details(int id)
        {
            // get the borrowing with the given id
            Borrowing borrowing = _context.Borrowings.FirstOrDefault(b => b.Id == id);
            return View(borrowing);
            
        }

        // GET: BorrowingsController/Create
        public ActionResult Create()
        {
            // get borrowing from the database
            Borrowing borrowing = new Borrowing();
            borrowing.BorrowDate = DateTime.Now;
            borrowing.DueDate = DateTime.Now.AddDays(15);
            borrowing.Status = "Borrowed";
            borrowing.IsReturned = false;
            return View(borrowing);
            
        }

        // POST: BorrowingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Borrowing borrowing)
        {
            try
            {
                // add the borrowing to the database

                _context.Borrowings.Add(borrowing);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowingsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BorrowingsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowingsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BorrowingsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
