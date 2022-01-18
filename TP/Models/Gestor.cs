using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Gestor
    {
        public int Id { get; set; }
        public string UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }

        public virtual ICollection<Imovel> Imoveis { get; set; }

        public virtual ICollection<Avaliacao_Cliente> Avaliacoes_Clientes { get; set; }

    }
}
