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

        [Required]
        public int Tipo_ImovelId { get; set; }
        public Tipo_Imovel Tipo_Imovel { get; set; }

        [Required]
        public string Tipologia { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Required]
        public string Distrito { get; set; }

        [Required]
        public string Localidade { get; set; }

        [Required]
        [Display(Name = "Código Postal")]
        public string Codigo_Postal { get; set; }

        [Required]
        public string Morada { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        public string Extras { get; set; }

        [Required]
        [Display(Name = "Preço por Noite")]
        public double Preco { get; set; }

        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }

        public virtual ICollection<Checklist> Verificacoes { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
