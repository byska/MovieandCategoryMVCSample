using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Odev.Models;
using Odev.Models.ViewModel;

namespace Odev.Controllers
{
    public class MovieController : Controller
    {
        MovieCategoryDbContext db;
        MoviesVM moviesViewModel = new MoviesVM();
        MoviesDto moviesDto= new MoviesDto();
        public MovieController(MovieCategoryDbContext _db)
        {
            db = _db;
        }
        public IActionResult GetMovies()
        {
            moviesViewModel.movieList = db.movies.Select(m => new MoviesDto()
            {
                MovieID=m.ID,
                MovieName= m.MovieName,
                IsVision= m.IsVision,
                MovieDescription= m.MovieDescription,
                ReleaseDate= m.ReleaseDate,
                CategoryName=m.MovieCategory.CategoryName
            }).ToList();
            return View(moviesViewModel);
        }
        public IActionResult Detail(int id)
        {
            moviesDto=db.movies.Where(m=>m.ID==id).Select(m=> new MoviesDto()
            {
                MovieID = m.ID,
                MovieName = m.MovieName,
                IsVision = m.IsVision,
                MovieDescription = m.MovieDescription,
                ReleaseDate = m.ReleaseDate,
                CategoryName = m.MovieCategory.CategoryName,
                ImageFile=m.ImageFile,
            }).FirstOrDefault();
            return View(moviesDto);
        }
        public IActionResult Delete(int id)
        {
            Movies movie = db.movies.Find(id);
            db.movies.Remove(movie);
            TempData["result"] = "The information of the movie named " + movie.MovieName + " has been successfully deleted.";
            db.SaveChanges();
            return RedirectToAction("GetMovies");
        }
        public IActionResult Update(int id)
        {
            moviesViewModel.Movies = db.movies.Find(id);
            moviesViewModel.CategoriesForDropDown = FillCategory();
            return View(moviesViewModel);
        }
        private List<SelectListItem> FillCategory()
        {
            return db.category.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.Id.ToString(),
            }).ToList();
        }
        [HttpPost]
        public IActionResult Update(MoviesVM moviesVM,int id)
        {
            Movies movie= db.movies.Find(id);
            movie.MovieName = moviesVM.Movies.MovieName;
            movie.IsVision = moviesVM.Movies.IsVision;
            movie.MovieDescription = moviesVM.Movies.MovieDescription;
            movie.ReleaseDate = moviesVM.Movies.ReleaseDate;
            movie.CategoryID = moviesVM.Movies.CategoryID;
            movie.ImageFile = moviesVM.Movies.ImageFile;
            db.SaveChanges();
            TempData["result"] = "The information of the movie named " + moviesVM.Movies.MovieName + " has been successfully updated.";
            return RedirectToAction("GetMovies");
        }
        
        public IActionResult Create()
        {
            moviesViewModel.CategoriesForDropDown = FillCategory();
            return View(moviesViewModel);
        }

        [HttpPost]
        public IActionResult Create(MoviesVM movieVM)
        {
            db.movies.Add(movieVM.Movies);
            db.SaveChanges();
            TempData["result"] = "The information of the movie named " + movieVM.Movies.MovieName + " has been successfully added.";
            return RedirectToAction("GetMovies");
        }
    }
}
