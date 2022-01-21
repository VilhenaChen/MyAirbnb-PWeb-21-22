using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;

namespace TP.Controllers
{
    public class ImovelController : Controller
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly ApplicationDbContext _context;
        public SelectList opcoes { get;   set; }

        public ImovelController(ApplicationDbContext context, UserManager<Utilizador> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Imovel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Imovel.Include(p => p.Tipo_Imovel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Imovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovel/Create
        public IActionResult Create()
        {
            ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
            return View();
        }

        // POST: Imovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo_ImovelId,Tipologia,Nome,Pais,Distrito,Localidade,Codigo_Postal,Morada,Descricao,Extras,Preco")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                Utilizador user = await _userManager.GetUserAsync(User);
                DbSet<Gestor> gestores = _context.Set<Gestor>();
                foreach (Gestor g in gestores)
                {
                    if (g.UtilizadorId == user.Id)
                        imovel.GestorId = g.Id;
                }
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return Redirect("~/Identity/Account/Manage/Portfolio");
            }
            ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
            return View(imovel);
        }

        // GET: Imovel/Edit/5
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
            return View(imovel);
        }

        // POST: Imovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Tipologia,Nome,Pais,Distrito,Localidade,Codigo_Postal,Morada,Descricao,Extras,Preco")] Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Utilizador user = await _userManager.GetUserAsync(User);
                    DbSet<Gestor> gestores = _context.Set<Gestor>();
                    foreach (Gestor g in gestores)
                    {
                        if (g.UtilizadorId == user.Id)
                            imovel.GestorId = g.Id;
                    }
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
                return Redirect("~/Identity/Account/Manage/Portfolio");
            }
            return View(imovel);
        }

        // GET: Imovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imovel.FindAsync(id);
            _context.Imovel.Remove(imovel);
            await _context.SaveChangesAsync();
            return Redirect("~/Identity/Account/Manage/Portfolio");
        }

        private bool ImovelExists(int id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
