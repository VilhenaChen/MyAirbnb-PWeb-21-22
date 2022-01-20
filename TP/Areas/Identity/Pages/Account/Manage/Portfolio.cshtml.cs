using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;

namespace TP.Areas.Identity.Pages.Account.Manage
{
    public class PortfolioModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly ApplicationDbContext _context;
        public PortfolioModel(UserManager<Utilizador> userManager, SignInManager<Utilizador> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public IQueryable<Imovel> Imoveis { get; set; }

        /*[BindProperty]
        public OutputModel Output { get; set; }

        public class OutputModel
        {
            [Display(Name = "Tipo")]
            public string Tipo { get; set; }

            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Display(Name = "País")]
            public string Pais { get; set; }

            [Display(Name = "Distrito")]
            public string Distrito { get; set; }

            [Display(Name = "Localidade")]
            public string Localidade { get; set; }

            [Display(Name = "Preco")]
            public double Preco { get; set; }
        }

        private async Task LoadAsync(Imovel imovel)
        {
            Output = new OutputModel
            {
                Nome = user.Nome,
                Data_Nascimento = user.Data_Nascimento,
                PhoneNumber = phoneNumber
            };
        }*/

        /*public async Task<IActionResult> OnGet()
        {
            int idGestor = 0;
            Utilizador user = await _userManager.GetUserAsync(User);
            DbSet<Gestor> gestores = _context.Set<Gestor>();
            foreach (Gestor g in gestores)
            {
                if (g.UtilizadorId == user.Id) { 
                    idGestor = g.Id;
                    break;
                }
            }
            var applicationDbContext = _context.Imovel.Where(e => e.GestorId == idGestor);
            return View(await applicationDbContext.ToListAsync());
        }*/

        public async Task OnGetAsync()
        {
            int idGestor = 0;
            Utilizador user = await _userManager.GetUserAsync(User);
            DbSet<Gestor> gestores = _context.Set<Gestor>();
            foreach (Gestor g in gestores)
            {
                if (g.UtilizadorId == user.Id)
                {
                    idGestor = g.Id;
                    break;
                }
            }
            Imoveis = _context.Imovel.Where(e => e.GestorId == idGestor);
        }
    }
}
