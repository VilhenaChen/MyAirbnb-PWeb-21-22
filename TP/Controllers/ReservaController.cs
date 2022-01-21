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
    public class ReservaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public ReservaController(ApplicationDbContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Funcionario).Include(r => r.Imovel);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .Include(r => r.Imovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create(int id)
        {
            ViewData["Imovel"] = _context.Imovel.Include(t => t.Tipo_Imovel).Where(i => i.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("Id,Check_In,Check_Out")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                Imovel imov = _context.Imovel.Where(i => i.Id == id).FirstOrDefault();
                var funcs = _context.Funcionario.Where(f => f.GestorId == imov.GestorId);
                int count = _context.Funcionario.Where(f => f.GestorId == imov.GestorId).Count();
                Random rand = new Random();
                int result = rand.Next(1, count);
                int volta = 0;
                foreach(Funcionario f in funcs) {
                    if(volta == result)
                    {
                        reserva.FuncionarioId = f.Id;
                        break;
                    }
                    volta++;
                }
                Utilizador myUser = await _userManager.GetUserAsync(User);
                Cliente cliente = _context.Cliente.Where(c=> c.UtilizadorId == myUser.Id).FirstOrDefault();
                reserva.ClienteId = cliente.Id;
                reserva.ImovelId = id;
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", reserva.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", reserva.FuncionarioId);
            ViewData["ImovelId"] = new SelectList(_context.Imovel, "Id", "Codigo_Postal", reserva.ImovelId);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estado,Check_In,Check_Out,Confirmacao,Comentarios_Check_Out,ImovelId,FuncionarioId,ClienteId")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", reserva.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", reserva.FuncionarioId);
            ViewData["ImovelId"] = new SelectList(_context.Imovel, "Id", "Codigo_Postal", reserva.ImovelId);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .Include(r => r.Imovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }
    }
}
