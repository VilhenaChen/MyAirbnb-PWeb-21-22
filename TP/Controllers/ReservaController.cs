using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;

namespace TP.Controllers
{
    [Authorize(Roles = "Gestor, Funcionario, Cliente")]
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
        public async Task<IActionResult> Index(int? id)
        {
            if(User.IsInRole("Funcionario"))
            {
                Utilizador myUser = await _userManager.GetUserAsync(User);
                Funcionario funcionario = _context.Funcionario.Where(c => c.UtilizadorId == myUser.Id).FirstOrDefault();
                var applicationDbContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Funcionario).Include(r => r.Cliente.Utilizador).Include(r => r.Imovel).Where(g => g.FuncionarioId == funcionario.Id);
                return View(await applicationDbContext.ToListAsync());
            }
            else if(User.IsInRole("Cliente"))
            {
                Utilizador myUser = await _userManager.GetUserAsync(User);
                Cliente cliente = _context.Cliente.Where(c => c.UtilizadorId == myUser.Id).FirstOrDefault();
                var applicationDbContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Funcionario).Include(r => r.Funcionario.Utilizador).Include(r => r.Imovel).Where(g => g.ClienteId == cliente.Id);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                Utilizador myUser = await _userManager.GetUserAsync(User);
                Gestor gestor = _context.Gestor.Where(c => c.UtilizadorId == myUser.Id).FirstOrDefault();
                var applicationDbContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Cliente.Utilizador).Include(r => r.Funcionario).Include(r => r.Funcionario.Utilizador).Include(r => r.Imovel).Where(g => g.Imovel.Id == id);
                return View(await applicationDbContext.ToListAsync());
            }

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
        public async Task<IActionResult> Create([Bind("ImovelId,Check_In,Check_Out")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                DateTime hoje = DateTime.Now;
                if (DateTime.Compare(reserva.Check_In,hoje) < 0 || DateTime.Compare(reserva.Check_Out, hoje) < 0 || DateTime.Compare(reserva.Check_In, reserva.Check_Out) > 0) {
                    ViewData["Imovel"] = _context.Imovel.Include(t => t.Tipo_Imovel).Where(i => i.Id == reserva.ImovelId).FirstOrDefault();
                    return View(reserva);
                }

                Imovel imov = _context.Imovel.Include(t => t.Gestor).Where(i => i.Id == reserva.ImovelId).FirstOrDefault();
                Console.WriteLine(imov.Nome);
                var funcs = _context.Funcionario.Include(t => t.Gestor);
                int count = 0;
                foreach (Funcionario f in funcs)
                {
                    if (f.GestorId == imov.GestorId)
                    {
                        count++;
                    }
                }
                Random rand = new Random();
                int result = rand.Next(0, count);
                int volta = 0;
                foreach(Funcionario f in funcs) {
                    if (f.GestorId == imov.GestorId)
                    { 
                        if(volta == result)
                        {
                            reserva.FuncionarioId = f.Id;
                            break;
                        }
                        volta++;
                    }
                }
                Utilizador myUser = await _userManager.GetUserAsync(User);
                Cliente cliente = _context.Cliente.Where(c=> c.UtilizadorId == myUser.Id).FirstOrDefault();
                reserva.ClienteId = cliente.Id;
                reserva.ImovelId = imov.Id;
                reserva.Estado = "Por confirmar";
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Imovel"] = _context.Imovel.Include(t => t.Tipo_Imovel).Where(i => i.Id == reserva.ImovelId).FirstOrDefault();
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = _context.Reserva.Include(r => r.Cliente).Include(r => r.Imovel).Where(r => r.Id == id).FirstOrDefault();
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["Cliente"] = _context.Cliente.Include(r => r.Utilizador).Where(i => i.Id == reserva.ClienteId).FirstOrDefault();
            ViewData["Funcionario"] = _context.Funcionario.Include(r => r.Utilizador).Where(i => i.Id == reserva.FuncionarioId).FirstOrDefault();
            ViewData["Imovel"] = _context.Imovel.Where(i => i.Id == reserva.ImovelId).FirstOrDefault();
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
            ViewData["Cliente"] = _context.Cliente.Include(r => r.Utilizador).Where(i => i.Id == reserva.ClienteId).FirstOrDefault();
            ViewData["Funcionario"] = _context.Funcionario.Include(r => r.Utilizador).Where(i => i.Id == reserva.FuncionarioId).FirstOrDefault();
            ViewData["Imovel"] = _context.Imovel.Where(i => i.Id == reserva.ImovelId).FirstOrDefault();
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
