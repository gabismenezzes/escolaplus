using EscolaPlus.Data;
using EscolaPlus.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class ProfessorController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public ProfessorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de professores
        public async Task<IActionResult> Index()
        {
            var professores = await _context.Professores.ToListAsync();
            return View(professores);
        }

        // Exibe os detalhes de um professor específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == id);
            if (professor == null) return NotFound();

            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessorViewModel professor)
        {
            // Verifica se os dados são válidos
            if (ModelState.IsValid)
            {
                // Adiciona o aluno no banco e salva
                _context.Add(professor);
                await _context.SaveChangesAsync();
                // Redireciona para a lista de alunos
                return RedirectToAction(nameof(Index));
            }

            // Se houver erro, retorna o formulário com os dados preenchidos
            return View(professor);
        }

        // Retorna o formulário de edição de um professor
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            // Busca o professor no banco
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null) return NotFound();

            return View(professor);
        }

        // Recebe os dados do formulário de edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProfessorViewModel professor)
        {
            // Verifica se o ID da URL bate com o do objeto
            if (id != professor.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza os dados do aluno
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Se o professor não existir mais, retorna 404
                    if (!ProfessorExists(professor.Id)) return NotFound();
                    else throw; // Lança o erro se for outro problema
                }
                return RedirectToAction(nameof(Index));
            }

            return View(professor);
        }

        // Exibe a tela de confirmação de exclusão
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            // Busca o aluno no banco
            var aluno = await _context.Alunos.FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        // Confirma e executa a exclusão
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Busca o professor
            var professor = await _context.Professores.FindAsync(id);
            // Remove e salva
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar que verifica se um professor existe pelo ID
        private bool ProfessorExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}