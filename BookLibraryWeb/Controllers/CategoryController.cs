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
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(obj);
    }
}