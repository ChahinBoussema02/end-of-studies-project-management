using System.Diagnostics;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Gestion_Soutenances.Models;
using Gestion_Soutenances.Data;

namespace Gestion_Soutenances.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SoutenanceContext _context;

    public HomeController(ILogger<HomeController> logger, SoutenanceContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var teachers = _context.Enseignant.ToList();
        var pfeCountPerTeacher = teachers.Select(teacher => _context.PFE.Count(pfe => pfe.EncadrantId == teacher.Id)).ToList();

        ViewBag.Teachers = teachers.Select(teacher => $"{teacher.Nom} {teacher.Prenom}").ToList();
        ViewBag.PfeCountPerTeacher = JsonConvert.SerializeObject(pfeCountPerTeacher);

        return View();
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

