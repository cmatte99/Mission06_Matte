using Microsoft.AspNetCore.Mvc;
using Mission06_Matte.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Matte.Controllers
{
    // Controller for handling movie-related actions
    public class HomeController : Controller
    {
        // Database context for accessing movie data
        private MovieEntriesContext _context;

        // Constructor to inject MovieEntriesContext
        public HomeController(MovieEntriesContext temp)
        {
            _context = temp;
        }

        // Action method for the home page
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method to display the form for adding a new movie (HTTP GET)
        [HttpGet]
        public IActionResult AddMovie()
        {
            // Retrieve categories for dropdown and pass an empty movie model to the view
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View("AddMovie", new Movies());
        }

        // Action method to handle the form submission for adding a new movie (HTTP POST)
        [HttpPost]
        public IActionResult AddMovie(Movies response)
        {
            if (ModelState.IsValid)
            {
                // Add valid movie record to the database
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else // Invalid data, redisplay the form with error messages
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();
                return View(response);
            }
        }

        // Action method to display the list of movies in the waitlist
        [HttpGet]
        public IActionResult Waitlist()
        {
            // Retrieve movies from the database, including category information
            var applications = _context.Movies
                .Include("Category")
                .ToList();
            return View(applications);
        }

        // Action method to display the form for editing a movie (HTTP GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the movie to be edited and categories for dropdown
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }

        // Action method to handle the form submission for editing a movie (HTTP POST)
        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            // Update the movie information in the database and redirect to the waitlist
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("Waitlist");
        }

        // Action method to display the confirmation page before deleting a movie (HTTP GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Retrieve the movie to be deleted
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        // Action method to handle the form submission for deleting a movie (HTTP POST)
        [HttpPost]
        public IActionResult Delete(Movies updatedInfodel)
        {
            // Remove the movie from the database and redirect to the waitlist
            _context.Movies.Remove(updatedInfodel);
            _context.SaveChanges();
            return RedirectToAction("Waitlist");
        }
    }
}
