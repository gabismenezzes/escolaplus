using EscolaPlus.Data;
using EscolaPlus.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class AtividadeController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public AtividadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de atividades
        public async Task<IActionResult> Index()
        {
            var atividades = await _context.Atividade.Include(a => a.Disciplina).Include(a => a.Turma).ToListAsync();
            return View(atividades);
        }

        // Exibe os detalhes de uma atividade específica
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var atividade = await _context.Atividade
                .Include(a => a.Disciplina)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (atividade == null) return NotFound();

            return View(atividade);
        }

        // Retorna o formulário para cadastrar nova atividade
        public IActionResult Create()
        {
            return View();
        }

        // ----------------------------- //
        //         AÇÕES POST            //
        // ----------------------------- //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atividade);
        }
    }
}