using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Tipo_Imovel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Tipo de Imóvel")]
        public string Tipo { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
