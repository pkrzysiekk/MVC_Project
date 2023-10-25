using GreenBookWeb.Data;
using GreenBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _db;

        public CategoryController(AplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList=_db.Categories;
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            var obj = _db.Categories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
            
        }

    }
}
