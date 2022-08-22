using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
namespace CRUDelicious.Controllers;

public class DishController : Controller
{
    private DishContext _context;

    public DishController(DishContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();

        return View("Index", AllDishes);
    }

    [HttpGet("/dish/new")]
    public IActionResult New()
    {
        return View("AddDish");
    }

    [HttpPost("/dish/create")]
    public IActionResult Create(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return New();
    }

    [HttpGet("/{dishId}")]
    public IActionResult DetailPage(int dishId)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if(dish == null)
        {
            return RedirectToAction("Index");
        }
        return View("Detail", dish);
    }

    [HttpPost("/dish/delete/{deletedDishId}")]
    public IActionResult Delete(int deletedDishId)
    {
        Dish? deletedDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == deletedDishId);

        if(deletedDish != null)
        {
            _context.Dishes.Remove(deletedDish);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpGet("dish/edit/{editedDishId}")]
    public IActionResult EditDish(int editedDishId)
    {
        Dish? editDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == editedDishId);

        // if(editDish == null)
        // {
        //     return RedirectToAction("Index");
        // }

        return View("Edit", editDish);
    }

    [HttpPost("/dish/update/{upDishId}")]
    public IActionResult UpdateDish(int upDishId, Dish upDish)
    {
        //can change return to upDishId
        if(ModelState.IsValid == false)
        {
            return EditDish(upDishId);
        }

        Dish? dbDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == upDishId);

        if(dbDish == null)
        {
            Console.WriteLine("dbDish is null");
            return RedirectToAction("Index");
        }

        dbDish.Name = upDish.Name;
        dbDish.Chef = upDish.Chef;
        dbDish.Tastiness = upDish.Tastiness;
        dbDish.Calories = upDish.Calories;
        dbDish.Description = upDish.Description;
        dbDish.UpdatedAt = DateTime.Now;

        _context.Dishes.Update(dbDish);
        _context.SaveChanges();

        return RedirectToAction("DetailPage", new { dishId = dbDish.DishId});
    }
}