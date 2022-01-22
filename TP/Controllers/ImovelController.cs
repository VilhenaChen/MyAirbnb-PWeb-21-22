using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _hostEnvironment;
        public SelectList opcoes { get;   set; }

        public ImovelController(ApplicationDbContext context, UserManager<Utilizador> userManager, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [AllowAnonymous]
        // GET: Imovel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Imovel.Include(p => p.Tipo_Imovel).Include(p => p.Imagem);
            return View(await applicationDbContext.ToListAsync());
        }

        [AllowAnonymous]
        // GET: Imovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel.Include(p => p.Tipo_Imovel).Include(p => p.Imagem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        [Authorize(Roles = "Gestor")]
        // GET: Imovel/Create
        public IActionResult Create()
        {
            ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
            return View();
        }

        [Authorize(Roles = "Gestor")]
        // POST: Imovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo_ImovelId,Tipologia,Nome,Pais,Distrito,Localidade,Codigo_Postal,Morada,Descricao,Wc,Extras,Preco,Img")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                //Guardar imagem
                string rootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imovel.Img.FileName);
                string extension = Path.GetExtension(imovel.Img.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(rootPath + "/imgImoveis/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imovel.Img.CopyToAsync(fileStream);
                }

                Imagem image = new Imagem();
                image.nome = fileName;
                _context.Add(image);
                await _context.SaveChangesAsync();

                imovel.ImagemId = image.Id;

                Utilizador user = await _userManager.GetUserAsync(User);
                DbSet<Gestor> gestores = _context.Set<Gestor>();
                foreach (Gestor g in gestores)
                {
                    if (g.UtilizadorId == user.Id)
                        imovel.GestorId = g.Id;
                }
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
                return Redirect("~/Identity/Account/Manage/Portfolio");
            }
            ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
            return View(imovel);
        }

        [Authorize(Roles = "Gestor")]
        // GET: Imovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = _context.Imovel.Include(r => r.Imagem).Where(r => r.Id == id).FirstOrDefault();
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["Imagem"] = _context.Imagem.Where(i => i.Id == imovel.ImagemId).FirstOrDefault();
            ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
            return View(imovel);
        }

        [Authorize(Roles = "Gestor")]
        // POST: Imovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo_ImovelId,Tipologia,Nome,Pais,Distrito,Localidade,Codigo_Postal,Morada,Descricao,Wc,Extras,Preco,ImagemId")] Imovel imovel)
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
                ViewData["Imagem"] = _context.Imagem.Where(i => i.Id == imovel.ImagemId).FirstOrDefault();
                ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
                return Redirect("~/Identity/Account/Manage/Portfolio");
            }
            ViewData["Imagem"] = _context.Imagem.Where(i => i.Id == imovel.ImagemId).FirstOrDefault();
            ViewData["Tipo_ImovelId"] = new SelectList(_context.Tipo_Imovel, "Id", "Tipo");
            return View(imovel);
        }

        [Authorize(Roles = "Gestor")]
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

        [Authorize(Roles = "Gestor")]
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
