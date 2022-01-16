using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Checklist
    {
        public int Id { get; set; }

        public string Momento { get; set; }

        public string Nome { get; set; }

        public bool Completa { get; set; }

        public virtual ICollection<Item_Checklist> Items { get; set; }
    }
}
