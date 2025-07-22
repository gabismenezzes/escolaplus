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

    public IActionResult Index()
    {
        if (User.IsInRole("Admin"))
        {
            return RedirectToAction("Index", "Usuario");
        }
        else if (User.IsInRole("Aluno"))
        {
            return RedirectToAction("Index", "Aluno");
        }
        else if (User.IsInRole("Professor"))
        {
            return RedirectToAction("Index", "Professor");
        }
        else if (User.IsInRole("Responsavel"))
        {
            return RedirectToAction("Index", "Responsavel");
        }
        else if (User.IsInRole("Secretario"))
        {
            return RedirectToAction("Index", "Secretaria");
        }
        else
        {
        return View("AccessDenied");
        }
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
