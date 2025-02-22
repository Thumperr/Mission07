using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private Mission6Context _context;

    public HomeController(Mission6Context someName) // Constructor
    {
        _context = someName;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    
    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View(new Movie());
    }
    
    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // Adds record to the database
            _context.SaveChanges();
            
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Movies()
    {
        var movies = _context.Movies
            .Include(movie => movie.Category)
            .ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieEdit = _context.Movies
            .Single(movie => movie.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("AddMovie", movieEdit);
    }

    [HttpPost]
    public IActionResult Edit([FromForm] Movie updatedMovie)
    {
        _context.Update(updatedMovie);
        _context.SaveChanges();

        return RedirectToAction("Movies");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movieDelete = _context.Movies
            .Single(movie => movie.MovieId == id);
        
        return View(movieDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("Movies");
    }
}