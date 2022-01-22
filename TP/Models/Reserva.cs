using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Check-in")]
        public DateTime Check_In { get; set; }

        [Required]
        [Display(Name = "Check-out")]
        public DateTime Check_Out { get; set; }

        [Display(Name = "Confirmação")]
        public bool Confirmacao { get; set; }

        [Display(Name = "Comentários após o Check-out")]
        public string Comentarios_Check_Out { get; set; }

        public int ImovelId { get; set; }
        public Imovel Imovel { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public virtual ICollection<Checklist> Verificacoes { get; set; }

        public virtual ICollection<Avaliacao_Imovel> Avaliacao_Imovel { get; set; }
    }
}
