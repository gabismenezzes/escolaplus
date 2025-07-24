using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EscolaPlus.Models;
using Microsoft.AspNetCore.Authorization;

namespace EscolaPlus.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Admin()
    {
        return View("Admin/Index");
    }

    public IActionResult Aluno()
    {
        return View("Aluno/Index");
    }

    public IActionResult Professor()
    {
        return View("Professor/Index");
    }

    public IActionResult Responsavel()
    {
        return View("Responsavel/Index");
    }

    public IActionResult Secretario()
    {
        return View("Secretario/Index");
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
