using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Imovel
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        public string Tipologia { get; set; }

        public string Nome { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }

        public string Distrito { get; set; }

        public string Localidade { get; set; }

        [Display(Name = "Código Postal")]
        [DataType(DataType.PostalCode)]
        public string Codigo_Postal { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Extras { get; set; }

        [Display(Name = "Preço")]
        public double Preco { get; set; }

        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }

        public virtual ICollection<Checklist> Verificacoes { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
