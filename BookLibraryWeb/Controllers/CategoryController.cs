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
}