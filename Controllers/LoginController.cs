using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EscolaPlus.Models.ViewModels;
using EscolaPlus.Models;
using System.Security.Cryptography;
using System.Text;


public class LoginController : Controller
{
    // Função para criar hash da senha
    private static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    // Função para verificar senha
    private static bool VerifyPassword(string password, string hash)
    {
        var hashOfInput = HashPassword(password);
        return hashOfInput.Equals(hash);
    }

    // In-memory user store for testing
    private static readonly List<UsuarioViewModel> Users = new()
    {
        new UsuarioViewModel { Id = 1, Matricula = "ADM001", Nome = "Admin User", Email = "admin@escolaplus.com", Senha = HashPassword("Admin123!"), TipoUsuario = TipoUsuario.Administrador },
        new UsuarioViewModel { Id = 2, Matricula = "ALU001", Nome = "Aluno User", Email = "aluno1@escolaplus.com", Senha = HashPassword("Aluno123!"), TipoUsuario = TipoUsuario.Aluno },
        new UsuarioViewModel { Id = 3, Matricula = "PROF001", Nome = "Professor User", Email = "professor1@escolaplus.com", Senha = HashPassword("Prof123!"), TipoUsuario = TipoUsuario.Professor },
        new UsuarioViewModel { Id = 4, Matricula = "SEC001", Nome = "Secretario User", Email = "secretario1@escolaplus.com", Senha = HashPassword("Sec123!"), TipoUsuario = TipoUsuario.Secretario },
        new UsuarioViewModel { Id = 5, Matricula = "RESP001", Nome = "Responsavel User", Email = "responsavel1@escolaplus.com", Senha = HashPassword("Resp123!"), TipoUsuario = TipoUsuario.Responsavel },
        new UsuarioViewModel { Id = 6, Matricula = "DIR001", Nome = "Diretor User", Email = "diretor1@escolaplus.com", Senha = HashPassword("Dir123!"), TipoUsuario = TipoUsuario.Diretor }
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
        if (user != null && VerifyPassword(model.Senha, user.Senha))
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

            // Redirecionar baseado no tipo de usuário
            return user.TipoUsuario switch
            {
                TipoUsuario.Administrador => RedirectToAction("Admin", "Home"),
                TipoUsuario.Aluno => RedirectToAction("Aluno", "Home"),
                TipoUsuario.Professor => RedirectToAction("Professor", "Home"),
                TipoUsuario.Responsavel => RedirectToAction("Responsavel", "Home"),
                TipoUsuario.Secretario => RedirectToAction("Secretario", "Home"),
                TipoUsuario.Diretor => RedirectToAction("Diretor", "Home"),
                _ => LocalRedirect(returnUrl ?? "/")
            };
        }

        ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos");
        ViewData["ReturnUrl"] = returnUrl;
        return View(model);
    }

    [HttpGet]
    public IActionResult Registrar()
    {
        return View(new RegistraUsuarioViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registrar(RegistraUsuarioViewModel model, string userType)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        UsuarioViewModel newUser = null;

        switch (model.UserType)
        {
            case "Aluno":
                if (string.IsNullOrEmpty(model.Aluno.Nome) || string.IsNullOrEmpty(model.Aluno.Email) || string.IsNullOrEmpty(model.Aluno.Senha))
                {
                    ModelState.AddModelError(string.Empty, "Preencha todos os campos obrigatórios do Aluno");
                    return View(model);
                }
                newUser = new UsuarioViewModel
                {
                    Nome = model.Aluno.Nome,
                    Email = model.Aluno.Email,
                    Senha = HashPassword(model.Aluno.Senha),
                    Matricula = model.Aluno.Matricula ?? $"ALU{Users.Count + 1:D3}",
                    TipoUsuario = TipoUsuario.Aluno,
                    Id = Users.Max(u => u.Id) + 1
                };
                break;

            case "Professor":
                if (string.IsNullOrEmpty(model.Professor.Nome) || string.IsNullOrEmpty(model.Professor.Email) || string.IsNullOrEmpty(model.Professor.Senha))
                {
                    ModelState.AddModelError(string.Empty, "Preencha todos os campos obrigatórios do Professor");
                    return View(model);
                }
                newUser = new UsuarioViewModel
                {
                    Nome = model.Professor.Nome,
                    Email = model.Professor.Email,
                    Senha = HashPassword(model.Professor.Senha),
                    Matricula = model.Professor.Matricula ?? $"PROF{Users.Count + 1:D3}",
                    TipoUsuario = TipoUsuario.Professor,
                    Id = Users.Max(u => u.Id) + 1
                };
                break;

            case "Responsavel":
                if (string.IsNullOrEmpty(model.Diretor.Nome) || string.IsNullOrEmpty(model.Diretor.Email) || string.IsNullOrEmpty(model.Diretor.Senha))
                {
                    ModelState.AddModelError(string.Empty, "Preencha todos os campos obrigatórios do Responsável");
                    return View(model);
                }
                newUser = new UsuarioViewModel
                {
                    Nome = model.Diretor.Nome,
                    Email = model.Diretor.Email,
                    Senha = HashPassword(model.Diretor.Senha),
                    Matricula = $"RESP{Users.Count + 1:D3}",
                    TipoUsuario = TipoUsuario.Responsavel,
                    Id = Users.Max(u => u.Id) + 1
                };
                break;

            case "Diretor":
                if (string.IsNullOrEmpty(model.Diretor.Nome) || string.IsNullOrEmpty(model.Diretor.Email) || string.IsNullOrEmpty(model.Diretor.Senha))
                {
                    ModelState.AddModelError(string.Empty, "Preencha todos os campos obrigatórios do Diretor");
                    return View(model);
                }
                newUser = new UsuarioViewModel
                {
                    Nome = model.Diretor.Nome,
                    Email = model.Diretor.Email,
                    Senha = HashPassword(model.Diretor.Senha),
                    Matricula = $"DIR{Users.Count + 1:D3}",
                    TipoUsuario = TipoUsuario.Diretor,
                    Id = Users.Max(u => u.Id) + 1
                };
                break;

            case "Secretario":
                if (string.IsNullOrEmpty(model.Diretor.Nome) || string.IsNullOrEmpty(model.Diretor.Email) || string.IsNullOrEmpty(model.Diretor.Senha))
                {
                    ModelState.AddModelError(string.Empty, "Preencha todos os campos obrigatórios do Secretário");
                    return View(model);
                }
                newUser = new UsuarioViewModel
                {
                    Nome = model.Diretor.Nome,
                    Email = model.Diretor.Email,
                    Senha = HashPassword(model.Diretor.Senha),
                    Matricula = $"SEC{Users.Count + 1:D3}",
                    TipoUsuario = TipoUsuario.Secretario,
                    Id = Users.Max(u => u.Id) + 1
                };
                break;

            default:
                ModelState.AddModelError(string.Empty, "Tipo de usuário inválido");
                return View(model);
        }

        // Check if email already exists
        if (Users.Any(u => u.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(string.Empty, "Este e-mail já está registrado");
            return View(model);
        }

        // Add new user to in-memory store
        Users.Add(newUser);

        // Sign in the new user
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, newUser.Email),
            new Claim(ClaimTypes.Role, newUser.TipoUsuario.ToString())
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        // Redirecionar baseado no tipo de usuário
        return newUser.TipoUsuario switch
        {
            TipoUsuario.Administrador => RedirectToAction("Admin", "Home"),
            TipoUsuario.Aluno => RedirectToAction("Aluno", "Home"),
            TipoUsuario.Professor => RedirectToAction("Professor", "Home"),
            TipoUsuario.Responsavel => RedirectToAction("Responsavel", "Home"),
            TipoUsuario.Secretario => RedirectToAction("Secretario", "Home"),
            TipoUsuario.Diretor => RedirectToAction("Admin", "Home"),
            _ => RedirectToAction("Aluno", "Home")
        };
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Login");
    }
}