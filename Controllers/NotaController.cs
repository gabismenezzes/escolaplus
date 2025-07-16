using EscolaPlus.Data;
using EscolaPlus.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class NotaController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public NotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de notas
        public async Task<IActionResult> Index()
        {
            var notas = await _context.Notas.ToListAsync();
            return View(notas);
        }

        // Exibe os detalhes de uma nota específica
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var nota = await _context.Notas.FirstOrDefaultAsync(n => n.Id == id);
            if (nota == null) return NotFound();

            return View(nota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotaViewModel nota)
        {
            // Verifica se os dados são válidos
            if (ModelState.IsValid)
            {
                // Adiciona a nota no banco e salva
                _context.Add(nota);
                await _context.SaveChangesAsync();
                // Redireciona para a lista de alunos
                return RedirectToAction(nameof(Index));
            }

            // Se houver erro, retorna o formulário com os dados preenchidos
            return View(nota);
        }

        // Retorna o formulário de edição de um aluno
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            // Busca o aluno no banco
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            return View(aluno);
        }

        // Recebe os dados do formulário de edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NotaViewModel nota)
        {
            // Verifica se o ID da URL bate com o do objeto
            if (id != nota.Id) return NotFound();

            if (ModelState.IsValid)
            {
                    // Atualiza os dados da nota
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(nota);
        }

        // Exibe a tela de confirmação de exclusão
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            // Busca a nota no banco
            var nota = await _context.Notas.FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null) return NotFound();

            return View(nota);
        }

        // Confirma e executa a exclusão
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Busca o aluno
            var nota = await _context.Notas.FindAsync(id);
            // Remove e salva
            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}