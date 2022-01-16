using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
