using Bookproj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookproj.Controllers
{
    public class UsersController : Controller
    {
        OnlineLibraryDbContext _context;

        public UsersController(OnlineLibraryDbContext context)
        {
            _context = context;
        }
        // GET: UsersController
        public ActionResult Index()
        {
            // get all users from the database
            List<User> users = _context.Users.ToList();
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            // get the user with the given id
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            // get the user with the given id from the database
            User user = new User();

            return View(user);
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                // add the user to the database
                    _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);

            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {

            try
            {
                // update the user in the database
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                // delete the user from the database
                _context.Users.Remove(user);
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
