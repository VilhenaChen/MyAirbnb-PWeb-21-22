using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        public virtual ICollection<Avaliacao_Imovel> Avaliacoes_Imoveis { get; set; }

        public virtual ICollection<Avaliacao_Cliente> Minhas_Avaliacoes { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }


    }
}
