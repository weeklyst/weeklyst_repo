using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.WeekLyst.Models;

namespace Web.WeekLyst.Controllers
{
    [Authorize]
    public class ProgramaController : Controller
    {
        private readonly weeklystContext _context;

        public ProgramaController(weeklystContext context)
        {
            _context = context;
        }

        // GET: Programa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programas.ToListAsync());
        }

        // GET: Programa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas
                .FirstOrDefaultAsync(m => m.ProgramaId == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // GET: Programa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramaId,Nombre,Version,Codigo,Estado")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }

        // GET: Programa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas.FindAsync(id);
            if (programa == null)
            {
                return NotFound();
            }
            return View(programa);
        }

        // POST: Programa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramaId,Nombre,Version,Codigo,Estado")] Programa programa)
        {
            if (id != programa.ProgramaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaExists(programa.ProgramaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }

        // GET: Programa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas
                .FirstOrDefaultAsync(m => m.ProgramaId == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // POST: Programa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programa = await _context.Programas.FindAsync(id);
            _context.Programas.Remove(programa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaExists(int id)
        {
            return _context.Programas.Any(e => e.ProgramaId == id);
        }
    }
}
