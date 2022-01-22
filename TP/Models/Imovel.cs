using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Imovel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Tipo de Imóvel")]
        public int Tipo_ImovelId { get; set; }
        public Tipo_Imovel Tipo_Imovel { get; set; }

        [Required]
        [Display(Name = "Quarto(s)")]
        public int Tipologia { get; set; }

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
        [DataType(DataType.PostalCode)]
        [Display(Name = "Código Postal")]
        public string Codigo_Postal { get; set; }

        [Required]
        public string Morada { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [MinLength(25)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Casa(s) de Banho")]
        public int Wc { get; set; }

        public string Extras { get; set; }

        [Required]
        [Display(Name = "Preço por Noite")]
        public double Preco { get; set; }

        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }

        [Display(Name = "Imagem do Imovel")]
        [NotMapped]
        public IFormFile Img { get; set; }

        public int ImagemId { get; set; }
        public Imagem Imagem { get; set; }

        public virtual ICollection<Checklist> Verificacoes { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

    }
}
