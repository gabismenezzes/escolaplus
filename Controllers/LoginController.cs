using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using EscolaPlus.Models;
using BCrypt.Net;
using EscolaPlus.Models.ViewModels;

namespace EscolaPlus.Controllers
{
    public class LoginController : Controller
    {
        // In-memory user store for testing
        private static readonly List<UsuarioViewModel> Users = new()
        {
            new UsuarioViewModel { Id = 1, Matricula = "ADM001", Nome = "Admin User", Email = "admin@escolaplus.com", Senha = BCrypt.Net.BCrypt.HashPassword("Admin123!"), TipoUsuario = TipoUsuario.Administrador },
            new UsuarioViewModel { Id = 2, Matricula = "ALU001", Nome = "Aluno User", Email = "aluno1@escolaplus.com", Senha = BCrypt.Net.BCrypt.HashPassword("Aluno123!"), TipoUsuario = TipoUsuario.Aluno },
            new UsuarioViewModel { Id = 3, Matricula = "PROF001", Nome = "Professor User", Email = "professor1@escolaplus.com", Senha = BCrypt.Net.BCrypt.HashPassword("Prof123!"), TipoUsuario = TipoUsuario.Professor },
            new UsuarioViewModel { Id = 4, Matricula = "SEC001", Nome = "Secretario User", Email = "secretario1@escolaplus.com", Senha = BCrypt.Net.BCrypt.HashPassword("Sec123!"), TipoUsuario = TipoUsuario.Secretario },
            new UsuarioViewModel { Id = 5, Matricula = "RESP001", Nome = "Responsavel User", Email = "responsavel1@escolaplus.com", Senha = BCrypt.Net.BCrypt.HashPassword("Resp123!"), TipoUsuario = TipoUsuario.Responsavel }
        };

        [HttpGet]
        public IActionResult Index(string returnUrl = "/")
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = "/")
        {
            if (!ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View(model);
            }

            var user = Users.Find(u => u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase));
            if (user != null && BCrypt.Net.BCrypt.Verify(model.Senha, user.Senha))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.TipoUsuario.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return LocalRedirect(returnUrl ?? "/");
            }

            ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos");
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}