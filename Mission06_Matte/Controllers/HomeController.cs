using Microsoft.AspNetCore.Mvc;
using Mission06_Matte.Models;
using System.Diagnostics;

namespace Mission06_Matte.Controllers
{
    public class HomeController : Controller

    {

        private MovieEntriesContext _context;
        public HomeController(MovieEntriesContext temp)
        {
            _context = temp;

        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View("AddMovie");
        }
        [HttpPost]
        public IActionResult AddMovie(Application response)
        {
            _context.Applications.Add(response); // add record to database
            _context.SaveChanges();
            return View("Confirmation", response);
        }


    }
}
