using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Utilizador : IdentityUser
    {
        [PersonalData]
        public string Nome { get; set; }

        [PersonalData]
        [Display(Name = "Data de Nascimento")]
        public DateTime Data_Nascimento { get; set; }

        public virtual ICollection<Gestor> Gestor { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }

    }
}
