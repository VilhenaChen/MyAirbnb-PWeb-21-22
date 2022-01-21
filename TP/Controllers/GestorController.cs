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
    [Authorize(Roles = "Admin")]
    public class GestorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gestor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Gestor.Include(g => g.Utilizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Gestor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .Include(g => g.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // GET: Gestor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .Include(g => g.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestor == null)
            {
                return NotFound();
            }
            ViewData["Username"] = new SelectList(_context.Users, "Id", "Id", gestor.Utilizador.UserName);
            ViewData["Nome"] = new SelectList(_context.Users, "Id", "Id", gestor.Utilizador.Nome);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Id", gestor.Utilizador.Email);
            ViewData["PhoneNumber"] = new SelectList(_context.Users, "Id", "Id", gestor.Utilizador.PhoneNumber);
            return View(gestor);
        }

        // POST: Gestor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtilizadorId")] Gestor gestor)
        {
            if (id != gestor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestorExists(gestor.Id))
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
            ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "Id", gestor.UtilizadorId);
            return View(gestor);
        }

        private bool GestorExists(int id)
        {
            return _context.Gestor.Any(e => e.Id == id);
        }
    }
}
