using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Avaliacao_Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }

        [Display(Name = "Comentários")]
        public string Comentarios { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }
    }
}
