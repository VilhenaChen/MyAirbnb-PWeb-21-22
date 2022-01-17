using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;

namespace TP.Controllers
{
    public class ImovelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImovelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: Imovels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Imovel.Include(i => i.Gestor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Imovels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .Include(i => i.Gestor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        [Authorize(Roles = "Admin, Gestor")]
        // GET: Imovels/Create
        public IActionResult Create()
        {
            ViewData["GestorId"] = new SelectList(_context.Set<Gestor>(), "Id", "Id");
            return View();
        }

        // POST: Imovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Tipologia,Nome,Pais,Cidade,Codigo_Postal,Morada,Descricao,Extras,Preco,GestorId")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GestorId"] = new SelectList(_context.Set<Gestor>(), "Id", "Id", imovel.GestorId);
            return View(imovel);
        }

        [Authorize(Roles = "Admin, Gestor")]
        // GET: Imovels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["GestorId"] = new SelectList(_context.Set<Gestor>(), "Id", "Id", imovel.GestorId);
            return View(imovel);
        }

        // POST: Imovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Tipologia,Nome,Pais,Cidade,Codigo_Postal,Morada,Descricao,Extras,Preco,GestorId")] Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.Id))
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
            ViewData["GestorId"] = new SelectList(_context.Set<Gestor>(), "Id", "Id", imovel.GestorId);
            return View(imovel);
        }

        [Authorize(Roles = "Admin, Gestor")]
        // GET: Imovels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .Include(i => i.Gestor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imovel.FindAsync(id);
            _context.Imovel.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
