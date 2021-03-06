using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TP.Data;
using TP.Models;

namespace TP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly UserManager<Utilizador> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private ApplicationDbContext _context;


        public RegisterModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, 
            ApplicationDbContext context
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Data de Nascimento")]
            public DateTime Data_Nascimento { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Nº de Telemóvel")]
            public string PhoneNumber { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Utilizador { UserName = Input.Username, Email = Input.Email, Nome = Input.Nome, PhoneNumber = Input.PhoneNumber, Data_Nascimento = Input.Data_Nascimento};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //Dar role ao user
                    if (User.IsInRole("Gestor"))
                    {
                        await _userManager.AddToRoleAsync(user, "Funcionario");
                        Funcionario funcionario = new Funcionario();
                        funcionario.UtilizadorId = user.Id;
                        var utilizador = await _userManager.GetUserAsync(User);
                        var gestor = _context.Gestor.Where(g => g.UtilizadorId == utilizador.Id).FirstOrDefault();
                        funcionario.GestorId = gestor.Id;
                        _context.Add(funcionario);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var r = Request.Form["Role"];

                        //Criar um elemento de gestor ou cliente na tabela de base de dados respetiva
                        if (r == "Gestor")
                        {
                            await _userManager.AddToRoleAsync(user, r);
                            Gestor gestor = new Gestor();
                            gestor.UtilizadorId = user.Id;
                            _context.Add(gestor);
                            await _context.SaveChangesAsync();
                        }
                        else if (r == "Cliente")
                        {
                            await _userManager.AddToRoleAsync(user, r);
                            Cliente cliente = new Cliente();
                            cliente.UtilizadorId = user.Id;
                            _context.Add(cliente);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            ModelState.AddModelError("Erro", "Role Inexistente");
                            return Page();
                        }
                    }

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirmar Email",
                        $"Para confirmar a sua conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clique aqui</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
