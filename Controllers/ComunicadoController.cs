using Comunicados.Models.Entities;
using EscolaPlus.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class ComunicadoController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public ComunicadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de comunicados
        public async Task<IActionResult> Index()
        {
            var comunicados = await _context.Comunicado.ToListAsync();
            return View(comunicados);
        }

        // Exibe os detalhes de um comunicado específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var comunicado = await _context.Comunicado.FirstOrDefaultAsync(c => c.Id == id);
            if (comunicado == null) return NotFound();

            return View(comunicado);
        }

        // Retorna o formulário para cadastrar novo comunicado
        public IActionResult Create()
        {
            return View();
        }

        // ----------------------------- //
        //         AÇÕES POST            //
        // ----------------------------- //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comunicado comunicado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comunicado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comunicado);
        }
        
    }
}