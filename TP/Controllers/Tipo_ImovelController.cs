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
    public class Tipo_ImovelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tipo_ImovelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipo_Imovel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_Imovel.ToListAsync());
        }

        // GET: Tipo_Imovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Imovel = await _context.Tipo_Imovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo_Imovel == null)
            {
                return NotFound();
            }

            return View(tipo_Imovel);
        }

        // GET: Tipo_Imovel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Imovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo")] Tipo_Imovel tipo_Imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_Imovel);
        }

        // GET: Tipo_Imovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Imovel = await _context.Tipo_Imovel.FindAsync(id);
            if (tipo_Imovel == null)
            {
                return NotFound();
            }
            return View(tipo_Imovel);
        }

        // POST: Tipo_Imovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo")] Tipo_Imovel tipo_Imovel)
        {
            if (id != tipo_Imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_ImovelExists(tipo_Imovel.Id))
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
            return View(tipo_Imovel);
        }

        private bool Tipo_ImovelExists(int id)
        {
            return _context.Tipo_Imovel.Any(e => e.Id == id);
        }
    }
}
