using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EscolaPlus.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        _logger.LogInformation("Usuário autenticado: {UserName}, Roles: {Roles}", 
            User.Identity.Name, string.Join(", ", User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value)));

        if (User.IsInRole("Admin"))
        {
            return View("Admin/Index");
        }
        else if (User.IsInRole("Aluno"))
        {
            return View("Aluno/Index");
        }
        else if (User.IsInRole("Professor"))
        {
            return View("Professor/Index");
        }
        else if (User.IsInRole("Responsavel"))
        {
            return View("Responsavel/Index");
        }
        else if (User.IsInRole("Secretario"))
        {
            return View("Secretario/Index");
        }
        else
        {
            _logger.LogWarning("Usuário sem role válida: {UserName}", User.Identity.Name);
            return RedirectToAction("Error");
        }
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}