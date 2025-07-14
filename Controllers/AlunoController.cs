// Importa os namespaces necessários
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EscolaPlus.Data;
using EscolaPlus.Models;
using EscolaPlus.Models.ViewModels;

namespace EscolaPlus.Controllers
{
    public class AlunoController : Controller
    {
        // Campo privado para acessar o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o ApplicationContext via injeção de dependência
        public AlunoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------- //
        //          AÇÕES GET            //
        // ----------------------------- //

        // Exibe a lista de alunos
        public async Task<IActionResult> Index()
        {
            // Busca todos os alunos do banco
            var alunos = await _context.Alunos.ToListAsync();
            // Retorna a view com a lista de alunos
            return View(alunos);
        }

        // Exibe os detalhes de um aluno específico
        public async Task<IActionResult> Details(int? id)
        {
            // Se o ID não foi informado, retorna 404
            if (id == null) return NotFound();

            // Busca o aluno no banco pelo ID
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);
            if (aluno == null) return NotFound();

            // Retorna a view com os dados do aluno
            return View(aluno);
        }

        // Retorna o formulário para cadastrar novo aluno
        public IActionResult Create()
        {
            return View();
        }

        // ----------------------------- //
        //         AÇÕES POST            //
        // ----------------------------- //

        // Recebe os dados do formulário para cadastrar novo aluno
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoViewModel aluno)
        {
            // Verifica se os dados são válidos
            if (ModelState.IsValid)
            {
                // Adiciona o aluno no banco e salva
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                // Redireciona para a lista de alunos
                return RedirectToAction(nameof(Index));
            }

            // Se houver erro, retorna o formulário com os dados preenchidos
            return View(aluno);
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
        public async Task<IActionResult> Edit(int id, AlunoViewModel aluno)
        {
            // Verifica se o ID da URL bate com o do objeto
            if (id != aluno.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza os dados do aluno
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Se o aluno não existir mais, retorna 404
                    if (!AlunoExists(aluno.Id)) return NotFound();
                    else throw; // Lança o erro se for outro problema
                }
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
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
            // Busca o aluno
            var aluno = await _context.Alunos.FindAsync(id);
            // Remove e salva
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar que verifica se um aluno existe pelo ID
        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
