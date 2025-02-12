using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }
    
    [HttpPost]
    public IActionResult AddMovie(Application response)
    {
        _context.Applications.Add(response); // Adds record to the database
        _context.SaveChanges();
        
        return View("Confirmation");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}