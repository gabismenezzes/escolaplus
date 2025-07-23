using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index(string returnUrl = "/")
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string username, string password, string returnUrl = "/")
    {
        if (username == "admin" && password == "123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, 
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) 
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            switch (username.ToLower())
{
    case "admin":
        return RedirectToAction("Admin", "Home");
    case "aluno":
        return RedirectToAction("Aluno", "Home");
    case "professor":
        return RedirectToAction("Professor", "Home");
    case "secretario":
        return RedirectToAction("Secretario", "Home");
    case "responsavel":
        return RedirectToAction("Responsavel", "Home");
    default:
        return RedirectToAction("Index", "Home");
}
        }

        ViewData["ReturnUrl"] = returnUrl;
        ModelState.AddModelError("", "Usuário ou senha inválidos");
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}