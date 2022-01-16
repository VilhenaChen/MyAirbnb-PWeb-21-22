using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Item_Checklist
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public bool Validada { get; set; }

        public int ChecklistId { get; set; }
        public Checklist Checklist { get; set; }
    }
}
