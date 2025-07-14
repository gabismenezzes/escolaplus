using EscolaPlus.Data;
using EscolaPlus.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class DisciplinaController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public DisciplinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de disciplinas
        public async Task<IActionResult> Index()
        {
            var disciplinas = await _context.Disciplinas.ToListAsync();
            return View(disciplinas);
        }

        // Exibe os detalhes de uma disciplina específica
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);
            if (disciplina == null) return NotFound();

            return View(disciplina);
        }

        // Retorna o formulário para cadastrar nova disciplina
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisciplinaViewModel disciplina)
        {
            if (ModelState.IsValid)
            {

                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        // ----------------------------- //
        //         AÇÕES POST            //
        // ----------------------------- //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina == null) return NotFound();
            return View(disciplina);
        }
        
    }
}