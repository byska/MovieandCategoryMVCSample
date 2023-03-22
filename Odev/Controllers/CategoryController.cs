using Microsoft.AspNetCore.Mvc;
using Odev.Models;
using Odev.Models.ViewModel;

namespace Odev.Controllers
{
    public class CategoryController : Controller
    {
        MovieCategoryDbContext db;
        CategoriesVM categoryViewModel=new CategoriesVM();
        public CategoryController(MovieCategoryDbContext _db)
        {
            db = _db;
        }

        public IActionResult GetCategory()
        {
            categoryViewModel.categoryList = db.category.Select(c => new CategoriesDto()
            {
                CategoryID=c.Id,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription
            }).ToList();
            return View(categoryViewModel);
        }
        public IActionResult Details(int id)
        {
            categoryViewModel.Categories = db.category.FirstOrDefault(c => c.Id == id);
            return View(categoryViewModel);
        }
        [HttpPost]
        public IActionResult Update(int id,CategoriesVM categoryVM)
        {
            Category category = db.category.Find(id);
            category.CategoryName = categoryVM.Categories.CategoryName;
            category.CategoryDescription = categoryVM.Categories.CategoryDescription;
            db.SaveChanges();
            TempData["result"] = "The information of the category named" + categoryVM.Categories.CategoryName+ " has been successfully updated.";
            return RedirectToAction("GetCategory");
        }
        public IActionResult Update(int id)
        {
            categoryViewModel.Categories = db.category.Find(id);
            return View(categoryViewModel);
        }
        public IActionResult Delete(int id)
        {
            Category category =db.category.Find(id);
            db.category.Remove(category);
            TempData["result"] = "The information of the category named " + category.CategoryName + " has been successfully deleted.";
            return RedirectToAction("GetCategory");
            db.SaveChanges();
            
        }
        public IActionResult Create()
        {
            return View(categoryViewModel);
        }
        [HttpPost]
        public IActionResult Create(CategoriesVM categoryVM)
        {
            db.category.Add(categoryVM.Categories);
            db.SaveChanges();
            TempData["result"] = "The information of the category named" + categoryVM.Categories.CategoryName + " has been successfully added.";
            return RedirectToAction("GetCategory");
        }
    }
}
