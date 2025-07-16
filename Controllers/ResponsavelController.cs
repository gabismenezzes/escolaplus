using EscolaPlus.Data;
using EscolaPlus.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaPlus.Controllers
{
    public class ResponsavelController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ResponsavelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var responsaveis = await _context.Responsavel.ToListAsync();
            return View(responsaveis);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var responsavel = await _context.Responsavel.FirstOrDefaultAsync(r => r.Id == id);
            if (responsavel == null) return NotFound();

            return View(responsavel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResponsavelViewModel responsavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(responsavel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var responsavel = await _context.Responsavel.FirstOrDefaultAsync(r => r.Id == id);
            if (responsavel == null) return NotFound();

            return View(responsavel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ResponsavelViewModel responsavel)
        {
            if (id != responsavel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(responsavel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(responsavel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var responsavel = await _context.Responsavel.FirstOrDefaultAsync(r => r.Id == id);
            if (responsavel == null) return NotFound();

            return View(responsavel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsavel = await _context.Responsavel.FindAsync(id);
            _context.Responsavel.Remove(responsavel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}