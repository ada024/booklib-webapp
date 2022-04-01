using BookLibWEb.Data;
using BookLibWEb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }


    // GET
    public IActionResult Index()
    {
        IEnumerable<Category> objectCategoryList = _db.Categories;
        return View(objectCategoryList);
    }

    // GET
    public IActionResult Create()
    {
        return View();
    }

// POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The Name cannot have same value as the Order");
        }

        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category was added";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    // GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c=>c.Id ==id);
        // var categoryFromDbSingle = _db.Categories.SingleOrDefault(c=>c.Id ==id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The Name cannot have same value as the Order");
        }

        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category was updated";
            return RedirectToAction("Index");
        }

        return View(obj);
    }
    
  
    // GET
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

    // POST
    [HttpPost, ActionName("Delete")] // Explicit-name
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Categories.Find(id);
        
        
        if (obj == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category was deleted!";
            return RedirectToAction("Index");
    }

    
    
    
}