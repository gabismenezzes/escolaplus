using EscolaPlus.Data;
using EscolaPlus.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class EventoCalendarioController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public EventoCalendarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de eventos do calendário
        public async Task<IActionResult> Index()
        {
            var eventos = await _context.EventoCalendario.ToListAsync();
            return View(eventos);
        }

        // Exibe os detalhes de um evento específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var evento = await _context.EventoCalendario.FirstOrDefaultAsync(e => e.Id == id);
            if (evento == null) return NotFound();

            return View(evento);
        }

        // Retorna o formulário para cadastrar novo evento
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventoCalendarioViewModel evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var evento = await _context.EventoCalendario.FindAsync(id);
            if (evento == null) return NotFound();

            if (await TryUpdateModelAsync(evento))
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }
    }
}