using Microsoft.AspNetCore.Mvc;
using Odev.Models;
using Odev.Models.ViewModel;
using System.Diagnostics;

namespace Odev.Controllers
{
    public class HomeController : Controller
    {
        MovieCategoryDbContext db;
        MoviesVM movieViewModel=new MoviesVM();

        public HomeController(MovieCategoryDbContext _db)
        {
            db = _db;
        }
    
        public IActionResult Index()
        {
           movieViewModel.movieList = db.movies.Where(m => m.IsVision == true).Select(m=> new MoviesDto()
           {
               MovieID=m.ID,
               MovieName= m.MovieName,
               MovieDescription=m.MovieDescription,
               ReleaseDate=m.ReleaseDate,
               CategoryName=m.MovieCategory.CategoryName
           }).ToList();
            return View(movieViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}