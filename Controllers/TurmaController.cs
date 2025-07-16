using EscolaPlus.Data;
using EscolaPlus.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class TurmaController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public TurmaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de turmas
        public async Task<IActionResult> Index()
        {
            var turmas = await _context.Turmas.ToListAsync();
            return View(turmas);
        }

        // Exibe os detalhes de uma turma específica
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var turma = await _context.Turmas.FirstOrDefaultAsync(t => t.Id == id);
            if (turma == null) return NotFound();

            return View(turma);
        }

        // Retorna o formulário para cadastrar nova turma
        public IActionResult Create()
        {
            return View();
        }

        // ----------------------------- //
        //         AÇÕES POST            //
        // ----------------------------- //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TurmaViewModel turma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(turma);
        }
    }
}